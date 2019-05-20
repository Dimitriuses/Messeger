using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using MaterialDesignThemes.Wpf;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserValidator userValidator;
        Loger UserLoger;
        int idChat = -1;
        public MainWindow()
        {
            UserLoger = new Loger(); 
            InitializeComponent();
            userValidator = new UserValidator();
            this.DataContext = userValidator;
            //listBoxChats.ItemsSource = new List<string>() { " test message ", " helow blet " };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingIN dlg = new SingIN();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserLoger = dlg.User;
                Update_Chat_List();
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
                    UpdateMessages();
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
            
            UpdateMessages();
            
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
            RenderMessage(messages);
        }

        private void RenderMessage(MessageDTO[] messages)
        {
            Messages.Blocks.Clear();
            if(messages == null ||messages.Length == 0)
            {
                return;
            }
            Service1Client client = new Service1Client();
            foreach (MessageDTO item in messages)
            {
                string SenderLogin = client.GetLoginById(item.SenderId);
                //SenderLogin = (SenderLogin == null) ? "Server" : SenderLogin;
                Paragraph paragraph = new Paragraph(new Run(SenderLogin + ": " + item.Text));
                ThicknessConverter tc = new ThicknessConverter();
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
            listBoxChats.Items.Clear();
            foreach (string item in tmp)
            {
                listBoxChats.Items.Add(item);
            }
            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (UserLoger.Login != null)
            {
                AddNewChat dlg = new AddNewChat();
                if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Update_Chat_List();
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
            LoginDialogHost.IsOpen = true;
             
            DialogHost.Show(LoginDialogHost);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterDialogHost.IsOpen = true;
            DialogHost.Show(RegisterDialogHost);
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
