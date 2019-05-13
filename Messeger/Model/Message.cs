using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Messeger.Model;

namespace Messeger
{
    [DataContract]
    public class Message
    {
        public Message()
        {
            Receivers = new HashSet<Receiver>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        //[DataMember]
        //public virtual Chat Chat { get; set; }
        //[DataMember]
        //public virtual int Sender { get; set; }
        //[DataMember]
        //public virtual ICollection<int> Recivers { get; set; }

        //public virtual ICollection<Chat> Chats  { get; set; }
        //[ForeignKey("Sender")]
        //public virtual User User { get; set; }

        //[ForeignKey("Recivers")]
        //public virtual ICollection<User> Users { get; set; }
        [DataMember]
        public virtual Sender Sender { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
        public virtual Chat Chat { get; set; }
    }
}