using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.License.Commands.CreateLicense
{
    public class CreateLicenseCommand:IRequest<int>
    {
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] File { get; set; }
        public int Client { get; set; }
        public bool ForClient { get; set; }
        public int Renewer { get; set; }
        public int QtRenewer { get; set; }
        public int LicenseConfig { get; set; }
        public int Terminal { get; set; }
        public int Package { get; set; }
        public int State { get; set; }
    }
}
