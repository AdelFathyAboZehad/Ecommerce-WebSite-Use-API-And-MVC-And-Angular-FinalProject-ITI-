using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("UserAddress")]
    public class UserAddress
    {
        
        public int Id { get; set; }

        //relation with User
        
        public  User User { get; set; }

        //relation with Address
        public  Address Address { get; set; }
        public bool? IsDefault { get; set; }

        public UserAddress(User user, Address address, bool? isDefault = null)
        {
            User = user;
            Address = address;
            IsDefault = isDefault;
        }

        public UserAddress():this (null!,null!)
        {

        }




    }
}
