using AutoMapper;
using Nnovah.Comunity.Application.Contracts.Security;
using Nnovah.Comunity.Domain.Communs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.MappingResolvers
{
    public class GenericIdResolver<TSource> : IValueResolver<TSource, object, string>
    where TSource : BaseEntity
    {
        private readonly IIdProtector _idProtector;

        public GenericIdResolver(IIdProtector idProtector)
        {
            _idProtector = idProtector;
        }

        public string Resolve(TSource source, object destination, string destMember, ResolutionContext context)
        {
            return _idProtector.Encrypt(source.Id);
        }
    }

}
