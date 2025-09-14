using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Application.Features.User.Queries.GetUser
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Usertype { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdPartner { get; set; }
        public int State { get; set; }
    }
}
