using Domian;

namespace Application.Contracts.Addresses
{
    public interface IAddressRepository:IRepository<Address,int>
    {
        Task<IEnumerable<Address>> GetAllAddressAsync(int id);
    }
}
