using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Contracts.Persistenc.Security;
using Nnovah.Comunity.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public CreateUserCommandHandler(IMapper mapper,IUserRepository userRepository,IPasswordService passwordService)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
            this._passwordService = passwordService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserValidator(_userRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid User", validatorResult);
            var existingUser = await _userRepository.GetByPartnerAndCodeAsync(request.IdPartner, request.UserCode);
            if (existingUser != null)
                throw new BadRequestException("Já existe um utilizador com esse Partner e UserCode.");

            var hashedPassword = _passwordService.HashPassword(request.Password);
            var UserToCreate = _mapper.Map<Domain.User>(request);
            UserToCreate.Password = hashedPassword;
            await _userRepository.CreatAsync(UserToCreate);
            return UserToCreate.Id;
        }
    }
}
