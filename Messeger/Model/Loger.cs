﻿using System;
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
        private string PasswordHash;

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

        public bool SetHashPass(string pass)
        {
            PasswordHash = pass;
            return true;
        }
        public bool SetHashPass(Loger Userloger)
        {
            PasswordHash = Userloger.PasswordHash;
            return true;
        }
    }
}