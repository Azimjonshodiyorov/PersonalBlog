﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.DTOs.Account
{
    public  class LoginDto
    {
        
        public  string Email { get; set; }
        
        public  string Password { get; set; }

    }
}
