using Client.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AddNewChat : Form
    {
        public AddNewChat()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            List<LogerDTO> logers = new List<LogerDTO>();
            Service1Client service = new Service1Client();
            logers = service.GetUserListByFindMode(textBox2.Text).ToList();
            service.Close();
            dataGridView1.Rows.Clear();
            foreach (LogerDTO item in logers)
            {
                if (item.Id != -1)
                {
                    object[] row =
                    {
                        item.Login,
                        "-->"
                    };
                    dataGridView1.Rows.Add(row);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
                }
                else
                {
                    object[] row =
                    {
                        item.Login,
                        " "
                    };
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
