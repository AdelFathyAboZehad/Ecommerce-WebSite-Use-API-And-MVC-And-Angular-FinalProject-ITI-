using Application.Features.Addesses.Queries.GetAllAddress;
using Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Wishlist
{
    public interface IWishlistRepository:IRepository<WishList,int>
    {
        Task<bool> delete(int uid, long pid);
    }
}
