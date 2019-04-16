using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Messeger
{

    //public static class MessagerDB
    //{
    //    public static List<Message> WorkersDB()
    //    {
    //        List<Message> list = new List<Message>()
    //        {
    //            new Message { Id = 1, Text = "Heloo", Sender = "Narod", Reciver = "Useless" },
    //            new Message { Id = 2, Text = "Are you seriosly?", Sender = "Useless", Reciver = "Narod" },
    //            new Message { Id = 3, Text = "Em yes!?", Sender = "Nameless", Reciver = "Useless" },
    //            new Message { Id = 4, Text = "Why I sign up to this MESEGER?!", Sender = "Useless", Reciver = "All" }

    //        };
    //        return list;
    //    }
    //}
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /////////////////////////////////////////////////////////////////////////////
        ///

        public bool AddNewUser(Loger login, string email, string phone)
        {
            if (login != null) 
            {
                using(Meseger meseger = new Meseger())
                {
                    meseger.Users.Add(new User { Login = login.Login, PasswordHash = login.PasswordHash, Email = email, Phone = phone });
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewChat(Loger login, string name, List<string> participants)
        {
            if (login != null && name != null && participants.Count > 0)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.Find(new object { new string Login = login})
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        

        //public bool Add(Message message)
        //{
        //    int oldLength = messages.Count;
        //    messages.Add(message);
        //    int newLength = messages.Count;
        //    return newLength > oldLength;
        //}

        //public Message GetMessageById(int id)
        //{
        //    return messages.SingleOrDefault(b => b.Id == id);
        //}

        //public string HelloResponse(string name)
        //{
        //    return $"Hello from Hell, {name}! ";
        //}

        //public decimal SimpleCalculator(decimal a, decimal b, char @operator)
        //{
        //    return a * b;
        //}
    }
}
