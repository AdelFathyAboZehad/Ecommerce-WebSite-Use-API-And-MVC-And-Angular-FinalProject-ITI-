using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Queries.GetAllAddress
{
    public class GetAllAddressQuery:IRequest<IEnumerable<AddressMinimalDTO>>
    {
        public int UserId { get; set; }
    }
}
