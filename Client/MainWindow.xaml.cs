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
    }
}
