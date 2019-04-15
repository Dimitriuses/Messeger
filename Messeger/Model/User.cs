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
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public List<Chat> Chats { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}