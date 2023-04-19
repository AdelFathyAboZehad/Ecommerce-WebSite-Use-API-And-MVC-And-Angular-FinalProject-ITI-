using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string? UnitNumber { get; set; }
        [MaxLength(100)]
        public string? StreetNumber { get; set; }
        [MaxLength(200),MinLength(5)]
        public string AddressEN1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string AddressAR1 { get; set; }
        [MaxLength(200), MinLength(5)]
        public string? AddressEN2 { get; set; }
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

        //relation with UserAddresses

        public IEnumerable <UserAddress> UserAddresses { get; set; }
        //relation with Order

        public  IEnumerable<Order>? Orders { get; set; }

        public Address( string addressEN1, string addressAR1,  string city, string region, string country, string? addressEN2=null, string? addressAR2 = null, string? postCode=null, string? unitNumber=null, string? streetNumber=null)
        {
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            AddressEN1 = addressEN1;
            AddressAR1 = addressAR1;
            AddressEN2 = addressEN2;
            AddressAR2= addressAR2;
            City = city;
            Region = region;
            PostCode = postCode;
            Country = country;
            UserAddresses = new List<UserAddress>();
            Orders = new List<Order>();
        }

        public Address():this (null!,null!, null!, null!,null!,null!) 
        { 
        }
    }
}
