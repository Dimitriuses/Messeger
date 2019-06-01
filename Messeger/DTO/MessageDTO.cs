using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.DTO
{
    [DataContract]
    public class MessageDTO
    {
        public MessageDTO()
        {

        }
        public MessageDTO(Message message)
        {
            Id = message.Id;
            string path;
            using(Meseger ctx = new Meseger())
            {
                message = ctx.Messages.SingleOrDefault(a => a.Id == Id);
                Text = message.Text;
                DateTime = message.DateTime;
                SenderId = message.Sender.Id;
                ReciversId = message.Receivers.Select(a => a.Id).ToArray<int>();
                ChatId = message.Chat.Id;
                if(message.File!= null)
                {
                    path = message.File.Path;
                }
                else
                {
                    path = String.Empty;
                }
            }
            if (path != String.Empty && System.IO.File.Exists(path))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
                FileName = fileInfo.Name;
            }
            else
            {
                FileName = String.Empty;
            }
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int SenderId { get; set; }
        [DataMember]
        public int[] ReciversId { get; set; }
        [DataMember]
        public int ChatId { get; set; }
        [DataMember]
        public string FileName { get; set; }
    }
}