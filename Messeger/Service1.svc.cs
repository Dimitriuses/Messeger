using Messeger.DTO;
using Messeger.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
                    User user = new User { Login = login.Login, Email = email, Phone = phone, PasswordHash = login.PasswordHash, Name = "", SurName = "" };
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
        
        public bool RenameUser(Loger loger, string name, string surname)
        {
            if(UserLogin(loger))
            {
                using(Meseger ctx = new Meseger())
                {
                    var user = ctx.Users.SingleOrDefault(a=> a.Login == loger.Login);
                    if(user.Name != name)
                    {
                        user.Name = name;
                    }
                    if(user.SurName != surname)
                    {
                        user.SurName = surname;
                    }
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public string GetEmail(Loger loger)
        {
            if (UserLogin(loger))
            {
                string tmp = "";
                using (Meseger ctx = new Meseger())
                {
                    User user = ctx.Users.SingleOrDefault<User>(a => a.Login == loger.Login);
                    tmp = user.Email;
                }
                return tmp;
            }
            return null;
        }
        public string GetPhone(Loger loger)
        {
            if (UserLogin(loger))
            {
                string tmp = "";
                using (Meseger ctx = new Meseger())
                {
                    User user = ctx.Users.SingleOrDefault<User>(a => a.Login == loger.Login);
                    tmp = user.Phone;
                }
                return tmp;
            }
            return null;
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

        public bool AddChatToParticipants(Loger loger, int[] participants, int chatId)
        {
            if (UserLogin(loger) && participants != null && participants.Length > 0 && chatId != -1)
            {
                int realChatId = GetChat(loger, chatId);
                if(realChatId != -1)
                {
                    using (Meseger ctx = new Meseger())
                    {
                        User user = ctx.Users.SingleOrDefault(a => a.Login == loger.Login);
                        Chat chat = ctx.Chats.Find(realChatId);
                        if(user.Administrator == chat.Administrator)
                        {
                            //Participant participant = new Participant();
                            foreach (int item in participants)
                            {
                                chat.Participants.Add(ctx.Users.Find(item).Participant);

                                //participant.Users.Add(ctx.Users.Find(item));
                            }
                            //participants.ForEach(p => participant.Users.Add(ctx.Users.Find(p)));
                            ctx.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool AddNewChat(Loger login, string name)
        {
            if (UserLogin(login) && name != null)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault<User>(a => a.Login == login.Login);
                    meseger.Entry(user).State = System.Data.Entity.EntityState.Unchanged;
                    //if(UserLogin(login))
                    //{
                    //List<User> users = meseger.Users.Where(a => participants.Contains(a.Id)).ToList();
                    //users.Add(user);
                    Administrator administrator;
                    administrator = meseger.Administrators.SingleOrDefault(a => a.User.Login == user.Login);
                    if(administrator == null)
                    {
                        administrator = new Administrator { User = user };

                    }
                    Participant par;
                    par = user.Participant;
                    if(par == null)
                    {
                        par = new Participant { Users = new List<User> { user } };
                    }
                    Chat chat = new Chat
                    {
                        Name = name,
                        Administrator = administrator,
                        Participants = new List<Participant> { par }
                    };

                    //user.Chats.Add(chat);
                    meseger.Chats.Add(chat);
                    meseger.SaveChanges();
                        //AddChatToParticipants(participants, chat);
                        //users.ForEach(p => p.Chats.Add(chat));
                        
                        //user.Chats.Add(chat); 
                       // chat.Messages = new List<Message>();
                        //chat.Messages.Add(new Message { Chat = chat, Text = $"hello and welcome" });
                        //meseger.SaveChanges(); // Multiplicity constraint violated. The role 'User_Chats_Source' of the relationship 'Messeger.User_Chats' has multiplicity 1 or 0..1.
                        return true;
                   //}
                    //return false;
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

        public List<UserDTO> GetChatParticipant(Loger loger, int chatId)
        {
            if (UserLogin(loger) && chatId != -1) 
            {
                List<UserDTO> userDTOs = new List<UserDTO>();
                int realChatId = GetChat(loger, chatId);
                if (realChatId != -1)
                {
                    HashSet<User> users = new HashSet<User>();
                    using(Meseger ctx = new Meseger())
                    {
                        //Chat chat = ctx.Chats.Find(realChatId);
                        List<Participant> participants = ctx.Chats.Find(realChatId).Participants.ToList();
                        participants.ForEach(a => users.UnionWith(a.Users));
                    }
                    foreach (User item in users)
                    {
                        userDTOs.Add(new UserDTO(item));
                    }
                }
                return userDTOs;
            }
            return null;
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
            if (chatID != -1 && Userloger != null)
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
                    messageDTOs.Add(new MessageDTO { Text = "This chat is empty", SenderId = 1 });
                    return messageDTOs;
                }
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
            if(loger != null)
            {
                using (Meseger meseger = new Meseger())
                {
                    User user = meseger.Users.SingleOrDefault(a => a.Login == loger.Login);
                    if (user != null && user.PasswordHash == loger.PasswordHash )
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        
        public bool ChatUserExists(Loger loger, int Chatid)
        {
            using (Meseger meseger = new Meseger())
            {
                User user = meseger.Users.SingleOrDefault(a => a.Login == loger.Login);
                Chat chat = meseger.Chats.SingleOrDefault(a => a.Id == Chatid);
                List<Participant> participants = chat.Participants.ToList();
                foreach (Participant item in participants)
                {
                    if(item == user.Participant)
                    {
                        return true;
                    }
                }
                if (chat.Administrator.User == user)
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

        public List<UserDTO> GetUserListByFindMode(string findstring)
        {
            List<UserDTO> logers = new List<UserDTO>();
            if (findstring != string.Empty)
            {
                HashSet<User> tmp = new HashSet<User>();
                using (Meseger ctx = new Meseger())
                {
                    //tmp = ctx.Users.Where(t => t.Login.ToUpper().StartsWith(findstring)).ToList();
                    //foreach (User item in ctx.Users)
                    //{
                    //    if (item.Login.Contains(findstring) || item.Name.Contains(findstring) || item.SurName.Contains(findstring))
                    //    {
                    //        tmp.Add(item);
                    //    }
                    //}
                    tmp.UnionWith(ctx.Users.Where(a => a.Login.Contains(findstring)));
                    tmp.UnionWith(ctx.Users.Where(a => a.Name.Contains(findstring)));
                    tmp.UnionWith(ctx.Users.Where(a => a.SurName.Contains(findstring)));
                    

                }
                if (tmp.Count > 0)
                {
                    foreach (User item in tmp)
                    {
                        if(item.Id != 1)
                        {
                            logers.Add(new UserDTO(item));
                        }
                    }
                    return logers;
                }

            }
            //logers.Add(new LogerDTO { Login = "Users not find" , Id = -1});
            return logers;
        }

        List<UserDTO> DeleteCloneItems(List<UserDTO> users)
        {
            if(users!=null && users.Count > 0)
            {
                List<UserDTO> tmp = new List<UserDTO>();
                //foreach (UserDTO item in users)
                //{
                //    bool IsClone = false;
                //    int count = 0;
                //    foreach (UserDTO item2 in users)
                //    {
                //        if(item.Id == item2.Id)
                //        {
                //            count++;
                //        }
                //        if ((item.Id == item2.Id && count > 1) || item.Id == 1)
                //        {
                //            IsClone = true;
                //            break;
                //        }
                //    }
                //    if (!IsClone)
                //    {
                //        tmp.Add(item);
                //    }
                //}
                //tmp = users.Distinct(new ItemEqualityComparer())
                return tmp;
            }
            return users;
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

        public UserDTO GetUserProfile(Loger loger)
        {
            if (UserLogin(loger))
            {
                UserDTO user;
                using (Meseger ctx = new Meseger())
                {
                    user = new UserDTO(ctx.Users.SingleOrDefault(a => a.Login == loger.Login));
                }
                return user;
            }
            return null;
        }
    }


    public class TransferService : ITransferService
    {
        public RemoteFileInfo DownloadFile(DownloadRequest request)
        {
            RemoteFileInfo result = new RemoteFileInfo();
            try
            {
                string filePath = Path.Combine(@"c:\Uploadfiles", request.FileName);
                FileInfo fileInfo = new FileInfo(filePath);

                // check if exists
                if (!fileInfo.Exists)
                    throw new FileNotFoundException("Файл не знайдений", request.FileName);

                // open stream
                FileStream stream = new FileStream(filePath,
                          System.IO.FileMode.Open, FileAccess.Read);

                // return result 
                result.FileName = request.FileName;
                result.Length = fileInfo.Length;
                result.FileByteStream = stream;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public void UploadFile(RemoteFileInfo request)
        {
            FileStream targetStream = null;
            Stream sourceStream = request.FileByteStream;

            string uploadFolder = @"C:\upload\";

            string filePath = Path.Combine(uploadFolder, request.FileName);

            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 65000 byte chunks

                const int bufferLen = 65000;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    // save to output stream
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
        }
    }
}
