using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nnovah.Comunity.Domain.Communs;

namespace Nnovah.Comunity.Domain
{
    public class Contacts : BaseEntity
    {
        public int Phone { get; set; }
        public int Email { get; set; }
        public int Email1 { get; set; }
    }
}
