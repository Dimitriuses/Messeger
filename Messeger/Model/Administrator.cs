﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.Model
{
    public class Administrator
    {
        [DataMember]
        [ForeignKey("User")]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }
    }
}