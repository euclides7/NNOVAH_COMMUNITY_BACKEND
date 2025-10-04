using AutoMapper;
using Nnovah.Comunity.Application.Contracts.Security;
using Nnovah.Comunity.Application.Features.Customer.Queries.GetCustomerQuery;
using Nnovah.Comunity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.MappingResolvers
{
   
        public class IdEncryptionResolver : IValueResolver<Customer, CustomerDTO, string>
        {
            private readonly IIdProtector _idProtector;

            public IdEncryptionResolver(IIdProtector idProtector)
            {
                _idProtector = idProtector;
            }

            public string Resolve(Customer source, CustomerDTO destination, string destMember, ResolutionContext context)
            {
                return _idProtector.Encrypt(source.Id);
            }
        }
    
}
