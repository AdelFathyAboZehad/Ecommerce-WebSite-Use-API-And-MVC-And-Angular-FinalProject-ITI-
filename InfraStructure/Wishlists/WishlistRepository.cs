using Application.Contracts.Wishlist;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Wishlists
{
    public class WishlistRepository : Repository<WishList, int> , IWishlistRepository
    {
        public WishlistRepository(Context context) : base(context)
        {
        }

        public async Task<bool> delete(int uid, long pid)
        {
            var res =  _context.WishLists.Include(a=>a.User).Include(a=>a.Product).FirstOrDefault(a => a.User.Id == uid && a.Product.Id == pid);

            _context.WishLists.Remove(res);
            _context.SaveChanges();
            //_dbset.Remove(res);
            //_context.SaveChanges();
            return true ;
          
        }
    }
}
