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
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual User Admin { get; set; }
        [DataMember]
        public virtual ICollection<Message> Messages { get; set; }
        [DataMember]
        public virtual ICollection<User> Participants { get; set; }

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
                catch (Exception ex)
                {
                    return false;
                    //throw;
                }
            }
            return false;
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