﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        private string Salt { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
