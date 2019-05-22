using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.Model
{
    public class File
    {
        [DataMember]
        [ForeignKey("Message")]
        public int Id { get; set; }
        [DataMember]
        public string Path { get; set; }
        public virtual Message Message { get; set; }
    }
}