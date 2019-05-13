using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.Model
{
    public class Receiver
    {
        [DataMember]
        public int Id { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}