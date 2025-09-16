using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;
using Nnovah.Comunity.Application.Features.TechnicalPartner.Commands.CreateTechnicalPartner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.UserType.Commands.CreateUserType
{
    public class CreateUserTypeCommandHandler:IRequestHandler<CreateUserTypeCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IUserTypeRepository _userTypeRepository;

        public CreateUserTypeCommandHandler(IMapper mapper,IUserTypeRepository userTypeRepository)
        {
            this._mapper = mapper;
            this._userTypeRepository = userTypeRepository;
        }

        public async Task<int> Handle(CreateUserTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserTypeValidator(_userTypeRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var userType = _mapper.Map<Domain.UserType>(request);
            await _userTypeRepository.CreatAsync(userType);
            return userType.Id;
        }
    }
}
