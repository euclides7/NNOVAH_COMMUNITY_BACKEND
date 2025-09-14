using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Infrastruture
{
    public static class InfrastrutureServicesRegistration
    {
        public static IServiceCollection AddInfrastrutureServices(this IServiceCollection service, IConfiguration configuration)
        {

            //service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            //service.AddTransient<IEmailSender, EmailSender>();
            //service.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return service;
        }
    }
}
