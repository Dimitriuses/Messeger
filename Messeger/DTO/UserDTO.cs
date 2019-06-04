using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger.DTO
{
    [DataContract]
    public class UserDTO : LogerDTO
    {
        public UserDTO()
        {

        }
        public UserDTO( User user)
        {
            Id = user.Id;
            Login = user.Login;
            Name = user.Name;
            SurName = user.SurName;
            Email = user.Email;
            Phone = user.Phone;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}