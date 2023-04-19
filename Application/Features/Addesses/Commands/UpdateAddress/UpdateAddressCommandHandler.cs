using Application.Contracts.Addresses;
using Domian;
using MediatR;
using System.Diagnostics.Metrics;

namespace Application.Features.Addesses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetDetailsAsync(request.Id);
            if (address == null)
            {
                return false;
            }
            else
            {
                if(request.UnitNumber!=null)
                    address.UnitNumber = request.UnitNumber;
                if (request.AddressEN1 != null)
                     address.AddressEN1 = request.AddressEN1;
                if (request.AddressEN2 != null)
                    address.AddressEN2 = request.AddressEN2;
                if (request.AddressAR1 != null)
                    address.AddressAR1 = request.AddressAR1;
                if (request.AddressAR2 != null)
                    address.AddressAR2 = request.AddressAR2;
                if (request.City != null)
                     address.City = request.City;
                if (request.Region != null)
                     address.Region = request.Region;
                if (request.Country != null)
                    address.Country = request.Country;
                if (request.PostCode != null)
                    address.PostCode = request.PostCode;
                if (request.StreetNumber != null)
                    address.StreetNumber = request.StreetNumber;

                return await _addressRepository.UpdateAsync(address);
            }
        }
    }
}
