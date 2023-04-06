﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.UserDto
{
    public class RegisterRequest
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Region { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

    }
}
