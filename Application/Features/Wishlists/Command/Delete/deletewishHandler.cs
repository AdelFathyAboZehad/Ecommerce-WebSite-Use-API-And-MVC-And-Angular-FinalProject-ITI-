using Application.Contracts.Wishlist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Wishlists.Command.Delete
{
    public class deletewishHandler : IRequestHandler<DeleteWishlistCommand, bool>
    {
        private readonly IWishlistRepository _wishlist;

        public deletewishHandler(IWishlistRepository wishlist)
        {
            _wishlist = wishlist;
        }
        public async Task<bool> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
        {
           return await _wishlist.delete(request.uid, request.pid);
             
        }
    }
}
