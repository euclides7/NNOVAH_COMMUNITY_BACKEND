using AutoMapper;
using MediatR;
using Nnovah.Application.Contracts.Persistenc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nnovah.Comunity.Application.Features.User.Queries.GetUserDetailsQuery
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserDetailsQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<UserDetailsDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetByIdAsync(request.id);
            return _mapper.Map<UserDetailsDTO>(userDetails);
        }
    }
}
