using Application.Contracts.Addresses;
using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Queries.GetAllAddress
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, IEnumerable<AddressMinimalDTO>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAllAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<AddressMinimalDTO>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {

            return (await _addressRepository.GetAllAddressAsync(request.UserId)).Select(x => 
                new AddressMinimalDTO()
                {
                    Id = x.Id,
                  //  Address1 = x.Address1,
                   // Address2 = x.Address2,
                    City = x.City,
                    Region = x.Region,
                    Country = x.Country,
                    PostCode = x.PostCode,
                    StreetNumber = x.StreetNumber,
                    UnitNumber = x.UnitNumber
                }
            );
        }
    }
}
