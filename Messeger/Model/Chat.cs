﻿using Messeger.Model;
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
            Participants = new HashSet<Participant>();
            Guid = Guid.NewGuid();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid Guid { get; set; }
        //[DataMember]
        //public int Admin { get; set; }
        //[DataMember]
        //public virtual ICollection<Message> Messages { get; set; }
        //[DataMember]
        //public virtual ICollection<int> Participants { get; set; }
        //[ForeignKey("Admin")]
        //public virtual User User { get; set; }
        //[ForeignKey("Participants")]
        //public virtual ICollection<User> Users { get; set; }
        public virtual Administrator Administrator { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }


    }
}