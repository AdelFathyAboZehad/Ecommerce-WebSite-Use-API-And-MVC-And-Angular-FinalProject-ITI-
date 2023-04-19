using Application.Contracts.Addresses;
using Application.Contracts.UserAddresses;
using Domian;
using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressMinimalDTO>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressesRepository _userAddressesRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository,
            IUserRepository userRepository,
            IUserAddressesRepository userAddressesRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _userAddressesRepository = userAddressesRepository;
        }
        public async Task<AddressMinimalDTO> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var user1 = await _userRepository.GetByIdAsync(request.UserId);
            if (user1 == null)
            {
                throw new Exception("not found user");
            }

            Address AddressTemp = new Address()
            {
                UnitNumber=request.UnitNumber,
                AddressEN1 = request.AddressEN1,
                AddressAR1 = request.AddressAR1,
                AddressEN2 = request.AddressEN2,
                AddressAR2 = request.AddressAR2,
                City = request.City,
                Region = request.Region,
                Country = request.Country,
                PostCode = request.PostCode,
                StreetNumber = request.StreetNumber
                
            };

            var address =await _addressRepository.CreateAsync(AddressTemp);
            UserAddress userAddress = new UserAddress(user1, address);
            await _userAddressesRepository.CreateAsync(userAddress);

            return new AddressMinimalDTO()
            {
                Id = address.Id,
                UnitNumber = address.UnitNumber,
                AddressEN1 = address.AddressEN1,
                AddressEN2 = address.AddressEN2,
                AddressAR1 = address.AddressAR1,
                AddressAR2 = address.AddressAR2,
                City = address.City,
                Region = address.Region,
                Country = address.Country,
                PostCode = address.PostCode,
                StreetNumber = address.StreetNumber,

            };
        }
    }
}
