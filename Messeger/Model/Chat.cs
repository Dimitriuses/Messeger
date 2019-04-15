using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger
{
    [DataContract]
    public class Chat
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public List<Message> Messages { get; set; }
        [DataMember]
        public List<User> Participants { get; set; }
        [DataMember]
        public User Admin { get; set; }

        public bool AddMessage(Message message)
        {
            if (message != null)
            {
                try
                {
                    Messages.Add(message);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    //throw;
                }
            }
            else
            {
                return false;
            }
        }
        public bool AddParticipant(User user)
        {
            if (user != null)
            {
                try
                {
                    Participants.Add(user);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    //throw;
                }
            }
            else
            {
                return false;
            }
        }
        public bool RemoveParticipant(User user)
        {
            if(user != null)
            {
                return Participants.Remove(user);
            }
            else
            {
                return false;
            }
        }
    }
}