﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; }
    }
}
