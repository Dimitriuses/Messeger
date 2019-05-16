using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.DTO
{
    [DataContract]
    public class LogerDTO
    {
        public LogerDTO()
        {

        }

        public LogerDTO(Loger loger)
        {
            Id = loger.Id;
            Login = loger.Login;
        }
        public LogerDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
    }
}