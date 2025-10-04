using AutoMapper;
using MediatR;
using Nnovah.Comunity.Application.Contracts.Persistenc;
using Nnovah.Comunity.Application.Exceptions;


namespace Nnovah.Comunity.Application.Features.Leads.Commands.CreateLeads
{
    public class CreateLeadsCommandHandler : IRequestHandler<CreateLeadsCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeadsRepository _leadsRepository;

        public CreateLeadsCommandHandler(IMapper mapper, ILeadsRepository leadsRepository)
        {
            this._mapper = mapper;
            this._leadsRepository = leadsRepository;
        }
        public async Task<int> Handle(CreateLeadsCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeadsValidator(_leadsRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Any())
                throw new BadRequestException("Invalid ", validatorResult);

            var leads = _mapper.Map<Domain.Leads>(request);
            await _leadsRepository.CreatAsync(leads);
            return leads.Id;
        }
    }
}
