using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Contracts.Persistenc.Security
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string userCode, int idPartner);
    }
}
