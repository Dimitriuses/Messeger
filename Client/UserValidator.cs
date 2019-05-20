using Client.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client
{
    public class UserValidator : IDataErrorInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Login":
                        bool Exist = false;
                        Service1Client client = new Service1Client();
                        Exist = client.UserExists(new Loger { Login = this.Login });
                        client.Close();
                        if (Exist)
                        {
                            error = "Цей логін вже існує";
                        }
                        break;
                    case "Password":
                        break;
                    case "ConfirmPassword":
                        break;
                    case "Email":
                        try
                        {
                            MailAddress m = new MailAddress(Email);
                        }
                        catch (Exception)
                        {
                            error = "Email Недійсний"; 
                        }
                        break;
                    case "Phone":
                        if(!Regex.IsMatch(Phone, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"))
                        {
                            error = "Неправильний формат номеру";
                        }
                        break;
                    default:
                        break;
                }
                return error;
            }
            
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
