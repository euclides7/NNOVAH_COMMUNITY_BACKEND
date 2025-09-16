using FluentValidation;
using Nnovah.Comunity.Application.Contracts.Persistenc;


namespace Nnovah.Comunity.Application.Features.States.Commands.CreateStates
{
    public class CreateStatesValidator: AbstractValidator<CreateStatesCommand>
    {
        private readonly IStatesRepository _statesRepository;
    public CreateStatesValidator(IStatesRepository statesRepository)
    {

        RuleFor(p => p.Description)
                .NotEmpty();
        this._statesRepository = statesRepository;

    }
}
 
}
