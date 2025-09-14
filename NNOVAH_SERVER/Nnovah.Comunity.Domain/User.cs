﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Usertype { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdPartner { get; set; }

    }
}
