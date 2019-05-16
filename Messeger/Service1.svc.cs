using Messeger.DTO;
using Messeger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

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
            
            if (login != null&& Regex.IsMatch(login.PasswordHash, @"[0-9a-f]{32}")) 
            {
                using(var ctx = new Meseger())
                {
                    User user = new User { Login = login.Login, Email = email, Phone = phone, PasswordHash = login.PasswordHash };
                    //ctx.Users.Add(user);
                    //ctx.SaveChanges();
                    Administrator admin = new Administrator { User = user };
                    Participant participant = new Participant { Users = new List<User> { user } };
                    Chat chat = new Chat { Administrator = admin, Name = "Save", Participants = new List<Participant> { participant } };
                    //ctx.SaveChanges();
                  //  Message message = new Message { Chat = chat, Text = $"Hello {user.Login}", Sender = user, Reciver = new List<User> { user } };
                  //  ctx.SaveChanges();
                  //  chat.Messages.Add(message);
                  //  ctx.SaveChanges();
                  //  user.Chats.Add(chat);
                  //  ctx.SaveChanges();
                  //  //user.PasswordHash = login.;
                  //  // meseger.Users.Add(user);
                  ////  ctx.Users.Add(user);
                   ctx.Chats.Add(chat);
                  // // ctx.Messages.Add(message);
                    ctx.SaveChanges();
                    //if(AddNewChat(user,"Save",new List<User> { user }))
                    //{
                    //
                    //}
                }
                return true;
            }
            return false;
        }
        
        public bool ThisLoginIsUnique(string Login)
        {
            if(Login != null)
            {
                using(Meseger ctx = new Meseger())
                {
                    var user = ctx.Users;
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

        //private bool AddChatToParticipants (List<User> participants, Chat chat)
        //{
        //    if(participants != null && participants.Count > 0 && chat != null)
        //    {
        //        foreach (User item in participants)
        //        {
        //            if (UserExists(item))
        //            {
        //                if (item.Chats == null)
        //                {
        //                    item.Chats = new List<Chat>();
        //                }
        //                item.Chats.Add(chat);
        //                if (chat.Participants == null)
        //                {
        //                    chat.Participants = new List<User>();
        //                }
        //                chat.Participants.Add(item);
                        
        //            }

        //        }
        //        return true;
        //    }
        //    return false;
        //}
        public bool AddNewChat(Loger login, string name, List<int> participants)
        {
            if (login != null && name != null && participants.Count > 0)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == login.Login);
                    meseger.Entry(user).State = System.Data.Entity.EntityState.Unchanged;
                    if(UserLogin(login))
                    {
                        List<User> users = meseger.Users.Where(a => participants.Contains(a.Id)).ToList();
                        users.Add(user);
                        Administrator administrator = new Administrator { User = user };
                        List<Participant> par = new List<Participant>();
                        par.Add(new Participant { Users = users});
                        Chat chat = new Chat
                        {
                            Name = name,
                            Administrator = administrator,
                            Participants = par 
                        };

                        //user.Chats.Add(chat);
                        meseger.SaveChanges();
                        //AddChatToParticipants(participants, chat);
                        //users.ForEach(p => p.Chats.Add(chat));
                        
                        //user.Chats.Add(chat); 
                       // chat.Messages = new List<Message>();
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
                    //var chats = meseger.Chats.Select(a => a.Participants.Select(b => b.Users.Select(c => c.Login == user.Login)));
                    //var chats = meseger.Chats.Where(a => a.Participants.Where(b => b.Users.Where(c => c.Login == user.Login) != null) != null).ToList<Chat>();

                    var chats = user.Participant.Chats.ToList();
                    foreach (Chat item in chats)
                    {
                        tmp.Add(item.Name);
                    }
                    return tmp;
                }
                return null;
            }
        }

        public int GetChat(Loger Userloger,int id)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault<User>(a => a.Login == Userloger.Login);
                if (UserLogin(Userloger))
                {
                    List<Chat> tmp = new List<Chat>();
                    var chats = user.Participant.Chats.ToList();
                    foreach (Chat item in chats)
                    {
                        tmp.Add(item);
                    }
                    return tmp[id].Id;
                }
                return -1;
            }
        }

        public List<MessageDTO> GetMessages(Loger Userloger,int chatID)
        {
            bool Secure = false;
            List<Message> messages = new List<Message>();
            using (Meseger meseger = new Meseger())
            {
                int id = GetChat(Userloger, chatID);
                Chat chat = meseger.Chats.SingleOrDefault(a=> a.Id == id);
                //bool admin = chat.Administrator.User == Userloger;
                //bool participant = chat.Participants.SingleOrDefault(a => Userloger == a.Users) != null;
                //bool all = admin || participant;
                if (UserLogin(Userloger) && ChatUserExists(Userloger, id))
                {
                    messages = chat.Messages.ToList<Message>();
                    Secure = true;
                }
            }
            List<MessageDTO> messageDTOs = new List<MessageDTO>();
            if (Secure && messages.Count > 0) 
            {
                foreach (Message item in messages)
                {
                    messageDTOs.Add(new MessageDTO(item));
                }
                return messageDTOs;
            }
            else if (Secure && messages.Count == 0)
            {
                messageDTOs.Add(new MessageDTO { Text = "This chat is empty", SenderId = 4 });
                return messageDTOs;
            }
            return null;
        }
        
        public bool UserExists(Loger loger)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault(a => a.Login == loger.Login);
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
                User user = meseger.Users.SingleOrDefault(a => a.Login == loger.Login);
                if (user != null && user.PasswordHash == loger.PasswordHash )
                {
                    return true;
                }
                return false;
            }
        }
        
        public bool ChatUserExists(Loger loger, int Chatid)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault(a => a.Login == loger.Login);
                Chat chat = meseger.Chats.SingleOrDefault(a => a.Id == Chatid);
                if (chat.Administrator.User == user || chat.Participants.SingleOrDefault(a=> user == a.Users) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool PushMessage(string text,Loger loger,int ChatId)
        {
            using (Meseger ctx = new Meseger())
            {
                
                User user = ctx.Users.SingleOrDefault(a => a.Login == loger.Login);
                int id = GetChat(loger, ChatId);
                Chat chat = ctx.Chats.SingleOrDefault(a => a.Id == id);

                if (ChatUserExists(loger, chat.Id)&&UserLogin(loger))
                {
                    Sender sender = ctx.Senders.SingleOrDefault(a => a.Id == user.Id);
                    if (sender == null)
                    {
                        sender = new Sender { User = user };
                    }
                    
                    Message msg = new Message { Text = text, Sender = sender, DateTime = DateTime.Now, Chat = chat };
                    ctx.Messages.Add(msg);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public string GetLoginById(int id)
        {
            using(Meseger ctx = new Meseger())
            {
                User user = ctx.Users.Find(id);
                return user.Login;
            }
        }

        public List<LogerDTO> GetUserListByFindMode(string findstring)
        {
            List<LogerDTO> logers = new List<LogerDTO>();
            if (findstring != string.Empty)
            {
                using (Meseger ctx = new Meseger())
                {
                    List<User> tmp = new List<User>();
                    tmp = ctx.Users.Where(t => t.Login.ToUpper().StartsWith(findstring)).ToList();
                    if (tmp.Count > 0)
                    {
                        foreach (User item in tmp)
                        {
                            logers.Add(new LogerDTO(item));
                        }
                        return logers;
                    }
                }
            }
            logers.Add(new LogerDTO { Login = "Users not find" , Id = -1});
            return logers;
        }

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
    }
}
