using Nnovah.Comunity.Domain.Communs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Domain
{
    public class Address:BaseEntity 
    {
        public string Street { get; set; }
        public string Province { get; set; }
        public int Country { get; set; }
        public string Municipality { get; set; }
    }
}
