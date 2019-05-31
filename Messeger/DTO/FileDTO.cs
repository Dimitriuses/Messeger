using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.DTO
{
    [KnownType(typeof(FileStream))]
    [DataContract]
    public class FileDTO
    {
        public FileDTO()
        {

        }
        public FileDTO(string path)
        {
            FileInfo = new FileInfo(path);
            using (System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                FileStream = stream;
            }
            FileName = FileInfo.Name;
        }
        public FileDTO(Model.File file)
        {
            Model.File tmp;
            using(Meseger ctx = new Meseger())
            {
                tmp = ctx.Files.SingleOrDefault(a => a.Id == file.Id);
                ChatId = tmp.Message.Chat.Id;
            }
            FileInfo = new FileInfo(tmp.Path);
            FileStream = new FileStream(tmp.Path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            FileName = FileInfo.Name;
        }
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