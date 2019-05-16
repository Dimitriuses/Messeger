using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Server;

namespace Client
{
    public partial class Registr: Form
    {
        bool login = false;
        bool pass = false;
        public Registr()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (login && pass)
            {
                bool Complete = false;
                Loger user = new Loger();
                user.Login = textBox1.Text;
                using (MD5 md5Hash = MD5.Create())
                {
                    user.PasswordHash = GetMd5Hash(md5Hash, textBox2.Text);
                }
                Service1Client client = new Service1Client();
                Complete = client.AddNewUser(user, textBox4.Text, textBox5.Text);
                client.Close();
                if (Complete)
                {
                    MessageBox.Show("Complete");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*using(*/Service1Client client = new Service1Client();//)
            //{
                if (!client.UserExists(new Loger { Login = textBox1.Text}))
                {
                    label7.ForeColor = Color.Green;
                    label7.Text = "Unique";
                    login = true;
                }
                else
                {
                    label7.Text = "This login exists";
                    label7.ForeColor = Color.Red;
                    login = false;
                }
            //}
            client.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == textBox3.Text)
            {
                textBox3.ForeColor = SystemColors.WindowText;
                pass = true;
            }
            else
            {
                pass = false;
                textBox3.ForeColor = Color.Red;
            }
        }
    }
}
