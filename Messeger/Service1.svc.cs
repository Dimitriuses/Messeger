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
                    User user = new User { Login = login.Login, Email = email, Phone = phone };
                    user.SetHashPass(login);
                    meseger.Users.Add(user);
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
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == login.Login);
                    if(user != null && user.CompareHashPass(login))
                    {
                        Chat chat = new Chat();
                        chat.Name = name;
                        chat.Admin = user;
                        string recipients = " ";
                        foreach (string item in participants)
                        {
                            User tmp = meseger.Users.Find(item);
                            if(tmp != null)
                            {
                                tmp.Chats.Add(chat);
                                chat.Participants.Add(tmp);
                                recipients += $"{tmp.Login} ";
                            }                     
                        }                         
                        user.Chats.Add(chat); 
                        chat.Admin.Chats.Add(chat);
                        chat.Messages.Add(new Message { ChatId = chat, Text = $"hello and welcome: {recipients}" });
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GetChatList(Loger Userloger)
        {
            using(Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                if (user != null && user.CompareHashPass(Userloger))
                {
                    List<string> tmp = new List<string>();
                    foreach (Chat item in user.Chats)
                    {
                        tmp.Add(item.Name);
                    }
                    return tmp;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Message> GetMessages(Loger Userloger,int chatID)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                Chat chat = meseger.Chats.Find(chatID);
                if (user != null && user.CompareHashPass(Userloger) && chat != null)
                {
                    if(chat.Admin == user || chat.Participants.Find(a=>a.Login == user.Login) != null)
                    {
                        return chat.Messages;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
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
