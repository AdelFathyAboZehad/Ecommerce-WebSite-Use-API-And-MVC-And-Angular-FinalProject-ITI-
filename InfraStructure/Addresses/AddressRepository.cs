using Application.Contracts.Addresses;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Addresses
{
    public class AddressRepository : Repository<Address, int>,IAddressRepository
    {
        public AddressRepository(Context context) : base(context)
        {
        }

        public  async Task<IEnumerable<Address>> GetAllAddressAsync(int id)
        {
          var userTemp= await _context.Users.Include(x=>
                    x.UserAddresses).FirstAsync(x=>x.Id == id);
            var u = userTemp.UserAddresses;
            var Alladdresses = _context.Address.Include(x => x.UserAddresses);
            List<Address> addresses = new List<Address>();
            foreach (var item in u)
            {
                foreach (var item1 in Alladdresses)
                {
                    if(item.Address.Id==item1.Id)
                        addresses.Add(item1);
                }
            }

            //another way 
            //var u = userTemp.UserAddresses;
            //List<Address> addresses = new List<Address>();
            //if (u != null)
            //{
            //    foreach (var item1 in u)
            //    {
            //        addresses.Add(item1.Address);
            //    }

            //}

            return addresses;
        }
    }
}
