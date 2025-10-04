using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Features.Address.Commands.UpdateAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IMapper mapper, IAddressRepository addressRepository)
        {
            this._mapper = mapper;
            this._addressRepository = addressRepository;
        }
        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var existing = await _addressRepository.GetByIdAsync(request.Id);
            if (existing == null)
                throw new KeyNotFoundException($"address {request.Id} não encontrado");
            _mapper.Map(request, existing);
            await _addressRepository.UpdateAsync(existing);
            return Unit.Value;
        }
    }
}
