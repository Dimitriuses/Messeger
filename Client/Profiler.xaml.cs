using Client.Server;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for Profiler.xaml
    /// </summary>
    public partial class Profiler : UserControl
    {
        public Profiler()
        {
            InitializeComponent();
        }

        public void Set(UserDTO user)
        {
            if (user != null)
            {
                if (user.Name != String.Empty && user.SurName != String.Empty) 
                {
                    Names.Text = user.Name + " " + user.SurName;
                }
                else if(user.Name != String.Empty || user.SurName != String.Empty)
                {
                    Names.Text = (user.Name != String.Empty) ? user.Name : user.SurName;
                }
                if(user.Email != String.Empty)
                {
                    Email.Text = user.Email;
                }
                if(user.Phone != String.Empty)
                {
                    Phone.Text = user.Phone;
                }
            }
        }
    }
}
