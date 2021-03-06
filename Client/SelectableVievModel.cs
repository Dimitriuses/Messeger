﻿using Client.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class SelectableVievModel
    {
        public SelectableVievModel()
        {
            IsSelected = false;
        }
        public SelectableVievModel(UserDTO user)
        {
            Id = user.Id;
            Code = (user.Name!=null)? $"{user.Name[0]}{user.SurName[0]}".ToUpper():$"{user.Login[0]}{user.Login[1]}".ToUpper();
            Name =(user.Name!=null&&user.SurName!=null)? $"{user.Name} {user.SurName}":"";
            Description = user.Login;
            IsSelected = false;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
