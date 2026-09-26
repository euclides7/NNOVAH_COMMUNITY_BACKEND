using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Contracts.Security
{
    public interface IIdProtector
    {
        string Encrypt(int id);
        int Decrypt(string encryptedId);
    }
}
