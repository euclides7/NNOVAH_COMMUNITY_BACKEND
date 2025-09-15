using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using Nnovah.Application.Features.User.Queries.GetUser;
using BCrypt.Net;
using Nnovah.Comunity.Application.Contracts.Persistenc.Security;
using Nnovah.Comunity.Application.Features.User.Queries.GetUserLoginQuery;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUserLogin
{
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, LoginDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        public GetUserLoginQueryHandler(IMapper mapper, IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService)
        {
            this._mapper = mapper;
            _passwordService = passwordService;
            this._userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<LoginDTO> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByPartnerAndCodeAsync(request.idPartner, request.userCode);
            if (user == null) return null;

            if (!_passwordService.VerifyPassword(request.password, user.Password)) 
               return null;

            var token = _jwtService.GenerateToken(user.Id, user.UserCode, user.IdPartner);

            return new LoginDTO
            {
                User = _mapper.Map<UserDTO>(user),
                Token = token
            };
        }
    }
}
