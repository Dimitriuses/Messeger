using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.Server;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum DesignColor
        {
            PrimaryLight,
            PrimaryMid,
            PrimaryDark,
            Accent
        }
        //UserValidator userValidator;
        Loger UserLoger;
        int idChat = -1;
        Brush DefaultStackPanelColor;
        Thread thread;
        //bool Closet = false;
        public MainWindow()
        {
            InitializeComponent();
            UserLoger = new Loger(); //{ Login = "Dmitrius"}; 
            //thread = new Thread(new ThreadStart(Updater));
            //thread.IsBackground = true;
            //thread.Start();
            //using (MD5 md5Hash = MD5.Create())
            //{
            //    UserLoger.PasswordHash = GetMd5Hash(md5Hash, "PAROL");
            //}
            //userValidator = new UserValidator();
            //this.DataContext = userValidator;
            DefaultStackPanelColor = EmailStackPanel.Background;
            UpdateCardProfile();
            //Update_Chat_List();
            //listBoxChats.ItemsSource = new List<string>() { " test message ", " helow blet " };
        }

        //~MainWindow()
        //{
        //    Closet = true;
        //    Thread.Sleep(1000);
        //}

        private void Updater()
        {
            while (true)
            {
                Thread.Sleep(1000);
                bool login = false;
                //if (!this.Dispatcher.Invoke(() => { Application.Current.Windows.OfType<MainWindow>().Any(); }))
                //{
                //    return;
                //}
                //if (Closet)
                //{
                //    return;
                //}

                try
                {
                    Service1Client client = new Service1Client();
                    login = client.UserLogin(UserLoger);
                    client.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("error conection :" + e);
                    //throw;
                }
                
                if (login)
                {
                    Update_Chat_List();
                    UpdateMessages();
                }
            }
        }

        //public bool IsWindowOpen<T>(string name = "") where T : Window
        //{
        //    bool rezult = true;
        //    this.Dispatcher.Invoke(() =>
        //    {
        //        rezult = string.IsNullOrEmpty(name)
        //           ? Application.Current.Windows.OfType<T>().Any()
        //           : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        //    });
        //    return rezult;
        //}

        private void UpdateCardProfile()
        {
            if(UserLoger.Login == null)
            {
                ProfileCard.Background = new SolidColorBrush(Colors.LightCoral);
                //CardButtonProfile.Click = TextBlock_PreviewMouseDown;
                CardButtonProfile.Background = new SolidColorBrush(Colors.LightCoral);
                CardButtonProfile.BorderBrush = new SolidColorBrush(Colors.Red);
                CardButtonProfile.Content = new PackIcon { Kind = PackIconKind.AccountWarning};
                CardLoginProfile.Text = "Ви не авторизовані";
            }
            else
            {
                ProfileCard.Background = GetDesignColorBrush(DesignColor.PrimaryMid);
                CardButtonProfile.Background = GetDesignColorBrush(DesignColor.PrimaryDark);
                CardButtonProfile.BorderBrush = GetDesignColorBrush(DesignColor.PrimaryDark);
                CardButtonProfile.Content = $"{UserLoger.Login[0]}{UserLoger.Login[1]}".ToUpper();
                CardLoginProfile.Text = UserLoger.Login;
            }
        }

        private SolidColorBrush GetDesignColorBrush(DesignColor color)
        {
            var palette = new PaletteHelper().QueryPalette();
            Hue hue;
            switch (color)
            {
                case DesignColor.PrimaryLight:
                    hue = palette.PrimarySwatch.PrimaryHues.ToArray()[palette.PrimaryLightHueIndex];
                    break;
                case DesignColor.PrimaryMid:
                    hue = palette.PrimarySwatch.PrimaryHues.ToArray()[palette.PrimaryMidHueIndex];
                    break;
                case DesignColor.PrimaryDark:
                    hue = palette.PrimarySwatch.PrimaryHues.ToArray()[palette.PrimaryDarkHueIndex];
                    break;
                case DesignColor.Accent:
                    hue = palette.AccentSwatch.AccentHues.ToArray()[palette.AccentHueIndex];
                    break;
                default:
                    hue = palette.PrimarySwatch.PrimaryHues.ToArray()[palette.PrimaryMidHueIndex];
                    break;
            }
            return new SolidColorBrush(hue.Color);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingIN dlg = new SingIN();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserLoger = dlg.User;
                //Update_Chat_List();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (idChat != -1 && UserLoger != null)
            {
                Service1Client client = new Service1Client();
                bool CompleteOparation = client.PushMessage(textBox.Text, UserLoger, idChat);
                client.Close();
                if (CompleteOparation)
                {
                    //UpdateMessages();
                    textBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Error push message");
                }

            }
            
        }

        private void ListBoxChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idChat = listBoxChats.SelectedIndex;
            //Update_Chat_List();
            //UpdateMessages();
            
            //if(e.AddedItems[0] == " helow blet ")
            //{
            //    //MessageBox.Show("EEEE boyy");
            //    UserLoger.Login = "Test_User";
            //    //RenderMessage(bletMassage());
            //    UserLoger.Login = null;
            //}  
        }

        private void UpdateMessages()
        {

            MessageDTO[] messages;
            Service1Client client = new Service1Client();
            messages = client.GetMessages(UserLoger, idChat);
            client.Close();
            if(messages != null)
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        RenderMessage(messages);
                    });

                }
                catch (Exception)
                {

                    //throw;
                }

            }
        }

        private void RenderMessage(MessageDTO[] messages)
        {
            Messages.Blocks.Clear();
            if(messages == null || messages.Length == 0)
            {
                return;
            }
            Service1Client client = new Service1Client();
            foreach (MessageDTO item in messages)
            {
                string SenderLogin = client.GetLoginById(item.SenderId);
                //SenderLogin = (SenderLogin == null) ? "Server" : SenderLogin;
                ThicknessConverter tc = new ThicknessConverter();
                Card card = new Card {
                    Background = GetDesignColorBrush(DesignColor.PrimaryDark),
                    Foreground = new SolidColorBrush(Colors.White),
                    Padding = (Thickness)tc.ConvertFromString("8px"),
                    UniformCornerRadius = 6,
                    Content = new TextBlock { Text = $"{item.Text}", TextWrapping = TextWrapping.Wrap }
                };
                Paragraph paragraph = new Paragraph(new InlineUIContainer( card ));
                paragraph.BorderThickness = (Thickness)tc.ConvertFromString("1px");
                if (SenderLogin == UserLoger.Login)
                {
                    paragraph.FlowDirection = FlowDirection.RightToLeft;
                    //paragraph.BorderBrush = Brushes.Red;
                }
                else
                {
                    paragraph.FlowDirection = FlowDirection.LeftToRight;
                    //paragraph.BorderBrush = Brushes.Blue;
                }
                Messages.Blocks.Add(paragraph);
            }
            client.Close();
        }

        private void Update_Chat_List()
        {
            string[] tmp;
            Service1Client client = new Service1Client();
            tmp = client.GetChatList(UserLoger);
            client.Close();
            //int tmpIdSelected = idChat;
            //listBoxChats.Items.Clear();
            //foreach (string item in tmp)
            //{
            //    listBoxChats.Items.Add(item);
            //}
            ////idChat = tmpIdSelected;
            //listBoxChats.SelectedIndex = tmpIdSelected;
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    int tmpIdSelected = idChat;
                    listBoxChats.Items.Clear();
                    foreach (string item in tmp)
                    {
                        listBoxChats.Items.Add(item);
                    }
                    //idChat = tmpIdSelected;
                    listBoxChats.SelectedIndex = tmpIdSelected;
                });
            }
            catch (Exception)
            {

                //throw;
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (UserLoger.Login != null)
            {
                AddNewChat dlg = new AddNewChat();
                if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Update_Chat_List();
                }
            }

        }

        private void ToggleIn_Click(object sender, RoutedEventArgs e)
        {
            ToggleOn.IsChecked = false;
        }

        private void ToggleOn_Click(object sender, RoutedEventArgs e)
        {
            ToggleIn.IsChecked = true;
        }

        private void TextBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!textBox.IsEnabled)
            {
                ToggleOn.IsChecked = false;
                ToggleIn.IsChecked = false;
            }
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //StackPanel first = new StackPanel();
            //StackPanel panel1 = new StackPanel();
            //StackPanel panel2 = new StackPanel();
            //StackPanel panel3 = new StackPanel();
            //panel1.Orientation = Orientation.Horizontal;
            //panel2.Orientation = Orientation.Horizontal;
            //panel3.Orientation = Orientation.Horizontal;
            //PackIcon icon1 = new PackIcon { Width = 60, Height = 60 };
            //PackIcon icon2 = new PackIcon { Width = 60, Height = 60 };
            //icon1.Kind = PackIconKind.Account;
            //icon2.Kind = PackIconKind.Key;
            //TextBox textBoxLogin = new TextBox { AcceptsReturn = true, TextWrapping = TextWrapping.Wrap, MinWidth = 200 };
            //textBoxLogin.Resources.Add(Resources, "MaterialDesignFilledTextFieldTextBox");
            //PasswordBox passwordBox = new PasswordBox { MinWidth = 200 };
            //passwordBox.Resources.Add(Resources, "MaterialDesignFilledPasswordFieldPasswordBox");
            if(UserLoger.Login != null)
            {

            }
            else
            {
                LoginDialogHost.IsOpen = true;
            }

             
            //DialogHost.Show(LoginDialogHost);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterDialogHost.IsOpen = true;
            //DialogHost.Show(RegisterDialogHost);
        }

        bool[] IsValid = new bool[4] { false, false, false, false };
        

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            Service1Client client = new Service1Client();
            bool Exist = client.UserExists(new Loger { Login = Login.Text });
            client.Close();
            if (!Exist && Login.Text != String.Empty && Login.Text.Length >= 3) 
            {
                LoginStackPanel.Background = GetDesignColorBrush(DesignColor.Accent);
                LoginStackPanel.ToolTip = "";
                IsValid[0] = true;
            }
            else
            {
                LoginStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                if (Exist)
                {
                    LoginStackPanel.ToolTip = "Даний логін вже існує";
                }
                else if (Login.Text == String.Empty) 
                {
                    LoginStackPanel.ToolTip = "Поле обов'язково має бути заповнене";
                }
                else if(Login.Text.Length < 3)
                {
                    LoginStackPanel.ToolTip = "Логін черезчур малий";
                }
                IsValid[0] = false;
            }
        }

        private void PassConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(Pass.Password == PassConfirm.Password)
            {
                PasswordStackPanel.Background = GetDesignColorBrush(DesignColor.Accent);
                PasswordStackPanel.ToolTip = "";
                IsValid[1] = true;
            }
            else
            {
                PasswordStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                PasswordStackPanel.ToolTip = "Паролі неспівпадають";
                IsValid[1] = false;
            }
        }

        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PassConfirm.Password != String.Empty)
            {
                if (Pass.Password == PassConfirm.Password)
                {
                    PasswordStackPanel.Background = GetDesignColorBrush(DesignColor.Accent);
                    PasswordStackPanel.ToolTip = "";
                    IsValid[1] = true;
                }
                else
                {
                    PasswordStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                    PasswordStackPanel.ToolTip = "Паролі неспівпадають";
                    IsValid[1] = false;
                }
            }
            else
            {
                PasswordStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                PasswordStackPanel.ToolTip = "Поля обов'язково мають бути заповненими";
                IsValid[1] = false;
            }
        }

        private void EmailTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if(EmailTextBlock.Text != String.Empty)
            {
                try
                {
                    MailAddress m = new MailAddress(EmailTextBlock.Text);
                }
                catch (Exception error)
                {
                    EmailStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                    EmailStackPanel.ToolTip = "Неправильний Email Error: " + error.Message;
                    IsValid[2] = true;
                    return;
                }
                EmailStackPanel.Background = GetDesignColorBrush(DesignColor.Accent);
                EmailStackPanel.ToolTip = "";
                IsValid[2] = false;
                return;
            }

            EmailStackPanel.Background = DefaultStackPanelColor;
            EmailTextBlock.ToolTip = "";
            IsValid[2] = true;
        }

        private void PhoneTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneTextBlock.Text != String.Empty && ValidPhone(PhoneTextBlock.Text)) 
            {
                PhoneStackPanel.Background = GetDesignColorBrush(DesignColor.Accent);
                PhoneStackPanel.ToolTip = "";
                IsValid[3] = true;
            }
            else if(PhoneTextBlock.Text == String.Empty) 
            {
                PhoneStackPanel.Background = DefaultStackPanelColor;
                PhoneStackPanel.ToolTip = "";
                IsValid[3] = true;
            }
            else if(!ValidPhone(PhoneTextBlock.Text))
            {
                PhoneStackPanel.Background = new SolidColorBrush(Colors.LightCoral);
                PhoneTextBlock.ToolTip = "Неправильний формат телефону";
                IsValid[3] = false;
            }
        }

        private bool ValidEmail(string Email)
        {
            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ValidPhone(string Phone) => Regex.IsMatch(Phone, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$");
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (IsValid[0] && IsValid[1] && IsValid[2] && IsValid[3])
            {
                bool Complete = false;
                Loger user = new Loger();
                user.Login = Login.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    user.PasswordHash = GetMd5Hash(md5Hash, Pass.Password);
                }
                Service1Client client = new Service1Client();
                Complete = client.AddNewUser(user, EmailTextBlock.Text, PhoneTextBlock.Text);
                client.Close();
                if (Complete)
                {
                    Brush tmp = RegisterForm.Background;
                    RegisterForm.Background = GetDesignColorBrush(DesignColor.Accent);
                    System.Threading.Thread.Sleep(3000);
                    RegisterForm.Background = tmp;
                    Login.Text = "";
                    Pass.Password = "";
                    PassConfirm.Password = "";
                    EmailTextBlock.Text = "";
                    PhoneTextBlock.Text = "";
                    RegisterDialogHost.IsOpen = false;
                    //MessageBox.Show("Complete");
                    //DialogResult = DialogResult.OK;
                }
                else
                {
                    //MessageBox.Show("Error");
                }
            }
            else
            {
                if (!IsValid[0])
                {
                    Login_TextChanged(null, null);
                }
                if (!IsValid[1])
                {
                    PassConfirm_PasswordChanged(null, null);
                    Pass_PasswordChanged(null, null);
                }
                if (!IsValid[2])
                {
                    EmailTextBlock_TextChanged(null, null);
                }
                if (!IsValid[3])
                {
                    PhoneTextBlock_TextChanged(null, null);
                }

            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            return false;
        }

        UserDTO ProfileDTO = new UserDTO();

        private void CardButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            if(UserLoger.Login != null)
            {
                ProfileDialogHost.IsOpen = true;

                Service1Client client = new Service1Client();
                ProfileDTO = client.GetUserProfile(UserLoger);
                ProfileEditEmail.Text = client.GetEmail(UserLoger);
                ProfileEditPhone.Text = client.GetPhone(UserLoger);
                client.Close();
                ProfileEditName.Text = ProfileDTO.Name;
                ProfileEditSurName.Text = ProfileDTO.SurName;
            }
            else
            {
                LoginDialogHost.IsOpen = true;
            }
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(UserLoger.Login != null)
            {
                NewChatDialodHost.IsOpen = true;
            }
            else
            {
                LoginDialogHost.IsOpen = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(LogerLogin.Text != String.Empty &&LogerPassword.Password != String.Empty)
            {
                Loger User = new Loger();
                User.Login = LogerLogin.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    User.PasswordHash = GetMd5Hash(md5Hash, LogerPassword.Password);
                }
                Service1Client client = new Service1Client();
                bool LoginComplete = client.UserLogin(User);
                client.Close();
                if (LoginComplete)
                {
                    LoginDialogHost.IsOpen = false;
                    UserLoger = User;
                    UpdateCardProfile();
                    //Update_Chat_List();
                }
                else
                {
                   
                }
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Button1_Click(null, null);
            }
        }

        string Name = "";
        string SurName = "";
        bool[] ProfileEditValidator = new bool[3] { false, false, false }; 

        private void ProfileEditName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = ProfileEditName.Text;
            UpdateNames();
        }

        private void ProfileEditSurName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SurName = ProfileEditSurName.Text;
            UpdateNames();
        }

        void UpdateNames()
        {
            ProfileNames.Text = $"{Name} {SurName}";
            if (Name != ProfileDTO.Name || SurName != ProfileDTO.SurName) 
            {
                ProfileNamesPanel.Background = new SolidColorBrush(Colors.LightYellow);
                ProfileEditValidator[0] = true;
            }
            else
            {
                ProfileNamesPanel.Background = DefaultStackPanelColor;
                ProfileEditValidator[0] = false;
            }
            UpdateEditButton();
        }

        void UpdateEditButton()
        {
            if (ProfileEditValidator[0] || ProfileEditValidator[1] || ProfileEditValidator[2])
            {
                ProfileButtonSave.IsEnabled = true;
            }
            else
            {
                ProfileButtonSave.IsEnabled = false;
            }
        }

        private void ProfileEditEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ValidEmail(ProfileEditEmail.Text)||ProfileEditEmail.Text == String.Empty)
            {
                Service1Client client = new Service1Client();
                string realEmail = client.GetEmail(UserLoger);
                client.Close();
                if(realEmail != ProfileEditEmail.Text)
                {
                    ProfileEmailPanel.Background = new SolidColorBrush(Colors.LightYellow);
                    ProfileEditValidator[1] = true;
                }
                else
                {
                    ProfileEmailPanel.Background = DefaultStackPanelColor;
                    ProfileEditValidator[1] = false;
                }
            }
            else
            {
                ProfileEmailPanel.Background = new SolidColorBrush(Colors.LightCoral);
                ProfileEditValidator[1] = false;
            }
            UpdateEditButton();
        }

        private void ProfileEditPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ValidPhone(ProfileEditPhone.Text) || ProfileEditPhone.Text == String.Empty)
            {
                Service1Client client = new Service1Client();
                string realPhone = client.GetEmail(UserLoger);
                client.Close();
                if (realPhone != ProfileEditPhone.Text)
                {
                    ProfilePhonePanel.Background = new SolidColorBrush(Colors.LightYellow);
                    ProfileEditValidator[2] = true;
                }
                else
                {
                    ProfilePhonePanel.Background = DefaultStackPanelColor;
                    ProfileEditValidator[2] = false;
                }
            }
            else
            {
                ProfilePhonePanel.Background = new SolidColorBrush(Colors.LightCoral);
                ProfileEditValidator[2] = false;
            }
            UpdateEditButton();
        }

        private void ProfileButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            if (ProfileEditValidator[0])
            {
                client.RenameUser(UserLoger, ProfileEditName.Text, ProfileEditSurName.Text);
            }
            if (ProfileEditValidator[1])
            {
                client.ReloadEmailUser(UserLoger, ProfileEditEmail.Text);
            }
            if (ProfileEditValidator[2])
            {
                client.ReloadPhonelUser(UserLoger, ProfileEditPhone.Text);
            }
            ProfileDTO = client.GetUserProfile(UserLoger);
            ProfileEditEmail.Text = client.GetEmail(UserLoger);
            ProfileEditPhone.Text = client.GetPhone(UserLoger);
            client.Close();
            ProfileEditName.Text = ProfileDTO.Name;
            ProfileEditSurName.Text = ProfileDTO.SurName;
            ProfileEditName_TextChanged(null, null);
            ProfileEditSurName_TextChanged(null, null);
            ProfileEditEmail_TextChanged(null, null);
            ProfileEditPhone_TextChanged(null, null);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            bool complete = client.AddNewChat(UserLoger, ChatName.Text);
            client.Close();
            //Update_Chat_List();
            if (complete)
            {
                NewChatDialodHost.IsOpen = false;
            }
        }

        private void ChatName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ChatName.Text != String.Empty)
            {
                CreateNewChat.IsEnabled = true;
                ChatNamePanel.Background = DefaultStackPanelColor;
            }
            else
            {
                CreateNewChat.IsEnabled = false;
                ChatNamePanel.Background = new SolidColorBrush(Colors.LightCoral);
            }
        }
        private void AdderParticipant_Selected(object sender, RoutedEventArgs e)
        {
            if(idChat != -1 && UserLoger != null)
            {
                AddParticipantsDialogHost.IsOpen = true;
            }
        }
        private void FindUsersByParticipans_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<SelectableVievModel> TMP = new List<SelectableVievModel>();
            if (pararara.Items.Count > 0)
            {
                foreach (SelectableVievModel item in pararara.Items)
                {
                    if (item != null && item.IsSelected)
                    {
                        TMP.Add(item);
                    }
                }
            }
            pararara.Items.Clear();
            foreach (SelectableVievModel item in TMP)
            {
                pararara.Items.Add(item);
            }
            Service1Client client = new Service1Client();
            List<UserDTO> find = client.GetUserListByFindMode(FindUsersByParticipans.Text).ToList();
            List<UserDTO> exist = client.GetChatParticipant(UserLoger, idChat).ToList();
            client.Close();
            List<SelectableVievModel> selectables = new List<SelectableVievModel>();
            List<SelectableVievModel> tableExist = new List<SelectableVievModel>();
            find.ForEach(f => selectables.Add(new SelectableVievModel(f)));
            exist.ForEach(f => tableExist.Add(new SelectableVievModel(f)));
            if(selectables.Count > 0)
            {
                foreach (SelectableVievModel item in selectables)
                {
                    if (item != null && !FindIdenticalItemForList(TMP, item) && !FindIdenticalItemForList(tableExist, item))
                    {
                        pararara.Items.Add(item);
                    }
                }
            }
        }

        private bool FindIdenticalItemForList(List<SelectableVievModel> list, SelectableVievModel Finditem)
        {
            foreach (SelectableVievModel item in list)
            {
                if (Finditem.Id == item.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
           List<int> selectables = new List<int>();
            foreach (SelectableVievModel item in pararara.Items)
            {
                if (item.IsSelected)
                {
                    selectables.Add(item.Id);
                }
            }
            Service1Client client = new Service1Client();
            client.AddChatToParticipants(UserLoger, selectables.ToArray(), idChat);
            client.Close();
            AddParticipantsDialogHost.IsOpen = false;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (idChat != -1)
            {
                string path;
                System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
                openFile.Filter = "All files (*.*)|*.*";
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = openFile.FileName;
                    //RemoteFileInfo
                    MessageBox.Show($"{openFile.SafeFileName} /n{openFile.FileName} /n{openFile.ValidateNames}");
                }
            }
        }

        private void StackPanel_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ColorChange change = new ColorChange();
            change.Show();
        }



        //private List<Message> bletMassage()
        //{
        //    User TestUser = new User() { Login = "VASA_TEST" };
        //    User user = new User() { Login = UserLoger.Login };
        //    List<Message> messages = new List<Message>
        //    {
        //        new Message { Id = 0 , Reciver = new User[] { TestUser } , Sender = user, Text = "Hello" },
        //        new Message { Id = 1 , Reciver = new User[] { user } , Sender = TestUser, Text = "Hello" },
        //        new Message { Id = 2 , Reciver = new User[] { TestUser } , Sender = user, Text = "Чо за НА**Й" },
        //        new Message { Id = 3 , Reciver = new User[] { user } , Sender = TestUser, Text = "???" }
        //    };
        //    return messages;
        //}

    }
}
