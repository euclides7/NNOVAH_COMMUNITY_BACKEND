using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc.Security;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.User.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressComandHandler : IRequestHandler<CreateAddressComand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressComandHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            this._mapper = mapper;
            this._addressRepository = addressRepository;
        }
        public async Task<int> Handle(CreateAddressComand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddressValidator(_addressRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);
           
            var address = _mapper.Map<Domain.Address>(request);
            await _addressRepository.CreatAsync(address);
            return address.Id;
        }
    }
}
