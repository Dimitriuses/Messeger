using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger
{
    [DataContract]
    [KnownType(typeof(Loger))]
    public class User : Loger
    {
        public User()
        {
            Chats = new HashSet<Chat>();
        }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
       // [DataMember]
        public virtual ICollection<Chat> Chats { get; set; }

        //public virtual Message Message { get; set; }
        //public virtual Chat Chat { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        //public virtual ICollection<Chat> Chats { get; set; }

    }
}