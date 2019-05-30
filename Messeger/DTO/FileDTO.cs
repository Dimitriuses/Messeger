using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.DTO
{
    [DataContract]
    public class FileDTO
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public Stream FileStream { get; set; }
        [DataMember]
        public FileInfo FileInfo { get; set; }
        [DataMember]
        public int ChatId { get; set; }


    }
}