using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Queries.GetAddressDetails
{
    public class GetAddressDetailsQuery : IRequest<AddressMinimalDTO>
    {
        public int Id { get; set; }
    }
}
