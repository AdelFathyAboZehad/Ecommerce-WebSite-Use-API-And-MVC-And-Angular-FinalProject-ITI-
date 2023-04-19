using Dtos.Addresses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Addesses.Commands.CreateAddress
{
    public class CreateAddressCommand:IRequest<AddressMinimalDTO>
    {
        public int UserId { get; set; }

        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [MaxLength(100)]
        public string? StreetNumber { get; set; }
        [MaxLength(200), MinLength(5)]
        public string AddressEN1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string? AddressEN2 { get; set; }

        [MaxLength(200), MinLength(5)]
        public string AddressAR1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string? AddressAR2 { get; set; }

        [MaxLength(100), MinLength(3)]
        public string City { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Region { get; set; }
        [MaxLength(10), MinLength(5)]
        public string? PostCode { get; set; }
        [MaxLength(100), MinLength(5)]
        public string Country { get; set; }
        public CreateAddressCommand() : this(null, null, null!, null, null!, null, null!, null!, null, null!)
        {

        }

        public CreateAddressCommand(string? unitNumber, string? streetNumber, string addressEN1, string? addressEN2, string addressAR1, string? addressAR2, string city, string region, string? postCode, string country)
        {
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            AddressEN1 = addressEN1;
            AddressEN2 = addressEN2;
            AddressAR1 = addressAR1;
            AddressAR2 = addressAR2;
            City = city;
            Region = region;
            PostCode = postCode;
            Country = country;
        }
    }
}
