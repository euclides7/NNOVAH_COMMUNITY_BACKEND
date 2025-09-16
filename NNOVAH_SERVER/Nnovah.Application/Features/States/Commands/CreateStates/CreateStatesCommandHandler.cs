using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;


namespace Nnovah.Comunity.Application.Features.States.Commands.CreateStates
{
    public class CreateStatesCommandHandler : IRequestHandler<CreateStatesCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IStatesRepository _statesRepository;

        public CreateStatesCommandHandler(IMapper mapper, IStatesRepository statesRepository)
        {
            this._mapper = mapper;
            this._statesRepository = statesRepository;
        }
        public async Task<int> Handle(CreateStatesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStatesValidator(_statesRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);
            var states = _mapper.Map<Domain.States>(request);
            await _statesRepository.CreatAsync(states);
            return states.Id;
        }
    }
}
