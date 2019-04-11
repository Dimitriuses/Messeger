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
        public string Sender { get; set; }
        [DataMember]
        public string Reciver { get; set; }
        public override string ToString()
        {
            return $"{Id} {Sender} => {Reciver} << {Text}";
        }
        //public bool HasTheSameTitle(string newName)
        //{

        //    return Title == newName;
        //}
    }
}