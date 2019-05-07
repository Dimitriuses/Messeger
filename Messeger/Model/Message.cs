using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Messeger
{
    [DataContract]
    public class Message
    {
        
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public virtual Chat Chat { get; set; }
        [DataMember]
        public virtual User Sender { get; set; }
        [DataMember]
        public virtual ICollection<User> Reciver { get; set; }

        public virtual ICollection<Chat> Chats  { get; set; }



        
    }
}