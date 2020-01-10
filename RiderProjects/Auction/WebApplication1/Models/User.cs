﻿using System.Collections;
using System.Collections.Generic;

namespace Auction.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Login { get; set; }
        
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role  { get; set; }
    }
}