using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Messeger
{
    [DataContract]
    public class Loger
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }

        public bool CompareHashPass(Loger Userloger)
        {
            if(Userloger.PasswordHash == PasswordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetHashPass(string pass) => PasswordHash = pass;
        //{
       // PasswordHash = pass;
            //return true;
       // }
        public bool SetHashPass(Loger Userloger)
        {
            return PasswordHash == Userloger.PasswordHash;
            return true;
        }
    }
}