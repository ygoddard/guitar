﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Credential
    {
        public string id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string pathToPic { get; set; }
        public bool passwordVerify(String toCompare)
        {
            if (Password == toCompare)
            {
                return true;
            }
            return false;
        }
    }
}
