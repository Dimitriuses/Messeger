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
                    meseger.SaveChanges();
                    if(AddNewChat(user,"Save",new List<User> { user }))
                    {

                    }
                }
                return true;
            }
            return false;
        }
        
        public bool ThisLoginIsUnique(string Login)
        {
            if(Login != null)
            {
                using(Meseger meseger = new Meseger())
                {
                    var user = meseger.Users;
                    foreach (User item in user)
                    {
                        if(item.Login == Login)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool ReloadEmailUser(Loger Userloger,string Email)
        {
            if(Userloger != null && Email != null)
            {
                using(Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                    if (UserLogin(Userloger))
                    {
                        user.Email = Email;
                        meseger.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool ReloadPhonelUser(Loger Userloger, string phone)
        {
            if (Userloger != null && phone != null)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                    if (UserLogin(Userloger))
                    {
                        user.Phone = phone;
                        meseger.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        private bool AddChatToParticipants (List<User> participants, Chat chat)
        {
            if(participants != null && participants.Count > 0 && chat != null)
            {
                foreach (User item in participants)
                {
                    if (UserExists(item))
                    {
                        if (item.Chats == null)
                        {
                            item.Chats = new List<Chat>();
                        }
                        item.Chats.Add(chat);
                        if (chat.Participants == null)
                        {
                            chat.Participants = new List<User>();
                        }
                        chat.Participants.Add(item);
                        
                    }

                }
                return true;
            }
            return false;
        }
        public bool AddNewChat(Loger login, string name, List<User> participants)
        {
            if (login != null && name != null && participants.Count > 0)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == login.Login);
                    if(UserLogin(login))
                    {
                        Chat chat = new Chat();
                        chat.Name = name;
                        chat.Admin = user;
                        AddChatToParticipants(participants, chat);                   
                        user.Chats.Add(chat); 
                        //chat.Admin.Chats.Add(chat);
                        chat.Messages = new List<Message>();
                        chat.Messages.Add(new Message { Chat = chat, Text = $"hello and welcome" });
                        meseger.SaveChanges(); // Multiplicity constraint violated. The role 'User_Chats_Source' of the relationship 'Messeger.User_Chats' has multiplicity 1 or 0..1.
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public List<string> GetChatList(Loger Userloger)
        {
            using(Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                if (UserLogin(Userloger))
                {
                    List<string> tmp = new List<string>();
                    foreach (Chat item in user.Chats)
                    {
                        tmp.Add(item.Name);
                    }
                    return tmp;
                }
                return null;
            }
        }

        public List<Message> GetMessages(Loger Userloger,int chatID)
        {
            using (Meseger meseger = new Meseger())
            {
                
                Chat chat = meseger.Chats.Find(chatID);
                if (UserLogin(Userloger) && ChatUserExists(Userloger, chat))
                {
                    return chat.Messages.ToList<Message>();
                }
                return null;
            }
        }
        
        public bool UserExists(Loger loger)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == loger.Login);
                if (user != null)
                {
                    return true;
                }
                return false;
            }  
        }

        public bool UserLogin(Loger loger)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == loger.Login);
                if (user != null && user.CompareHashPass(loger))
                {
                    return true;
                }
                return false;
            }
        }
        
        public bool ChatUserExists(Loger loger, Chat chat)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == loger.Login);
                if(chat.Admin == user || chat.Participants.SingleOrDefault<User>(a=> a.Login == user.Login) != null)
                {
                    return true;
                }
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
