﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.Model
{
    public class UserModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Visitor,
        Admin
    }
}
