using MediatR;


namespace Nnovah.Comunity.Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand:IRequest<Unit>
    {
        public int Id { get; set; }
      
    }
}
