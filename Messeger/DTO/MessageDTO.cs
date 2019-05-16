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
            using(Meseger ctx = new Meseger())
            {
                message = ctx.Messages.SingleOrDefault(a => a.Id == Id);
                Text = message.Text;
                DateTime = message.DateTime;
                SenderId = message.Sender.Id;
                ReciversId = message.Receivers.Select(a => a.Id).ToArray<int>();
                ChatId = message.Chat.Id;
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
    }
}