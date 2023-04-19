using Application.Contracts;
using Application.Contracts.UserAddresses;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.UserAddresses
{
    public class UserAddressRepository : Repository<UserAddress, int>, IUserAddressesRepository
    {

        public UserAddressRepository(Context context) : base(context) { }

    }
}
