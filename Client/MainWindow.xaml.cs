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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Loger UserLoger;
        public MainWindow()
        {
            UserLoger = new Loger(); 
            InitializeComponent();
            listBoxChats.ItemsSource = new List<string>() { " test message ", " helow blet " };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingIN dlg = new SingIN();
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] tmp;
                UserLoger = dlg.User;
                Service1Client client = new Service1Client();
                tmp = client.GetChatList(UserLoger);
                client.Close();
                listBoxChats.Items.Add(tmp);
                //foreach (string item in tmp)
                //{

                //}
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            if(e.AddedItems[0] == " helow blet ")
            {
                //MessageBox.Show("EEEE boyy");
                UserLoger.Login = "Test_User";
                RenderMessage(bletMassage());
                UserLoger.Login = null;
            }
            
            
        }

        private void RenderMessage(List<Message> messages)
        {
            Messages.Blocks.Clear();
            foreach (Message item in messages)
            {
                Paragraph paragraph = new Paragraph(new Run(item.Sender.Login +": " + item.Text));
                if(item.Sender.Login == UserLoger.Login)
                {
                    paragraph.FlowDirection = FlowDirection.RightToLeft;
                    
                }
                else
                {
                    paragraph.FlowDirection = FlowDirection.LeftToRight;
                }
                Messages.Blocks.Add(paragraph);
            }
        }

        private List<Message> bletMassage()
        {
            User TestUser = new User() { Login = "VASA_TEST" };
            User user = new User() { Login = UserLoger.Login };
            List<Message> messages = new List<Message>
            {
                new Message { Id = 0 , Reciver = new User[] { TestUser } , Sender = user, Text = "Hello" },
                new Message { Id = 1 , Reciver = new User[] { user } , Sender = TestUser, Text = "Hello" },
                new Message { Id = 2 , Reciver = new User[] { TestUser } , Sender = user, Text = "Чо за НА**Й" },
                new Message { Id = 3 , Reciver = new User[] { user } , Sender = TestUser, Text = "???" }
            };
            return messages;
        }

    }
}
