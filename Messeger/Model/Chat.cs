using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger
{
    [DataContract]
    public class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<User>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Admin { get; set; }
        [DataMember]
        public virtual ICollection<Message> Messages { get; set; }
        [DataMember]
        public virtual ICollection<User> Participants { get; set; }
        [ForeignKey("Admin")]
        public virtual User User { get; set; }


    }
}