

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc.Security;
using Nnovah.Comunity.Application.Contracts.Security;
using Nnovah.Comunity.Persistence.DatabaseContext;
using Nnovah.Comunity.Persistence.Repository;
using Nnovah.Comunity.Persistence.Security;

namespace Nnovah.Comunity.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var idProtectorKey = Environment.GetEnvironmentVariable("Jwt__Key")
                             ?? configuration["Jwt:Key"];

            if (string.IsNullOrEmpty(idProtectorKey))
            {
                throw new Exception("JWT Key não encontrada. Configure a variável de ambiente 'Jwt__Key' ou no appsettings.json em Jwt:Key.");
            }

            // Regista o IIdProtector
            services.AddSingleton<IIdProtector>(sp => new AesIdProtector(idProtectorKey));
            var connectionString = configuration.GetConnectionString("NnovahComunityConnectionString");

            services.AddDbContext<NnovahComunityDatabaseContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILeadsRepository, LeadsRepository>();
            services.AddScoped<ILicenseOrderRepository, LicenseOrderRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IPartnerTypeRepository, PartnerTypeRepository>();
            services.AddScoped<IPermissionGroupRepository, PermissionGroupRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IStatesRepository, StatesRepository>();
            services.AddScoped<ITechnicalPartnerRepository, TechnicalPartnerRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITechnicalTypeRepository, TechnicalTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
