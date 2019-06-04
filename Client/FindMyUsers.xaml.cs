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
    /// Interaction logic for FindMyUsers.xaml
    /// </summary>
    public partial class FindMyUsers : UserControl
    {
        List<SelectableVievModel> selectables;
        public FindMyUsers()
        {
            InitializeComponent();
            selectables = new List<SelectableVievModel>();
            //DataContext = selectables;
        }

        public void SetValues(List<ListBoxItem> items, Loger loger)
        {
            Service1Client client = new Service1Client();
            HashSet<UserDTO> exist = new HashSet<UserDTO>();//= client.GetChatParticipant(UserLoger, idChat).ToList();
            items.ForEach(a => exist.UnionWith(client.GetChatParticipant(loger, (int)a.Tag)));
            //foreach (ListBoxItem item in items)
            //{
            //    exist.UnionWith(client.GetChatParticipant(loger, (int)item.Tag));
            //}
            client.Close();
            List<SelectableVievModel> tmp = new List<SelectableVievModel>();
            foreach (UserDTO item in exist)
            {
                tmp.Add(new SelectableVievModel(item));
            }
            pararara.Items.Clear();
            int max = tmp.Count;
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].Description != loger.Login && FindIdenticalItemForList(tmp, tmp[i]))
                {
                    pararara.Items.Add(tmp[i]);
                    selectables.Add(tmp[i]);
                }
                else if (FindIdenticalItemForList(tmp, tmp[i]))
                {
                    tmp.Remove(tmp[i]);
                    i--;
                    max--;
                }
                if (i == max - 1) 
                {
                    break;
                }
            }
            //foreach (SelectableVievModel item in tmp)
            //{
            //    if(item.Description != loger.Login&&!FindIdenticalItemForList(tmp,item))
            //    {
            //        pararara.Items.Add(item);
            //        selectables.Add(item);
            //    }
            //    else if(FindIdenticalItemForList(tmp, item))
            //    {
            //        tmp.Remove(item);
            //    }
            //}
        }

        private bool FindIdenticalItemForList(List<SelectableVievModel> list, SelectableVievModel Finditem)
        {
            int num = 0;
            foreach (SelectableVievModel item in list)
            {
                if (Finditem.Id == item.Id)
                {
                    num++;
                }
            }
            if (num > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FindUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            string findStr = FindUsers.Text;
            pararara.Items.Clear();
            if(findStr != String.Empty)
            {
                foreach (SelectableVievModel item in selectables)
                {
                    if (item.Description.Contains(findStr) || item.Name.Contains(findStr))
                    {
                        pararara.Items.Add(item);
                    }
                }
                
            }
            else
            {
                foreach (SelectableVievModel item in selectables)
                {
                    pararara.Items.Add(item);
                }
            }

        }
    }
}
