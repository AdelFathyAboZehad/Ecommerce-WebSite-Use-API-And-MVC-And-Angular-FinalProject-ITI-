using Application.Contracts;
using Application.Contracts.Wishlist;
using Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Wishlists.Command.Create
{
    public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, string>
    {
        private readonly IWishlistRepository wishlist;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;

        public CreateWishlistCommandHandler(IWishlistRepository wishlist,IProductRepository productRepository, IUserRepository userRepository )
        {
            this.wishlist = wishlist;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public async Task<string> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var user =await this.userRepository.GetByIdAsync(request.uid);

            var product =await this.productRepository.GetDetailsAsync(request.pid);

            if (user == null)
            {
                throw new Exception("Saleh&Adel Not found user");
            }
            WishList wl = new WishList
            {
                User = user,
                Product = product
            };

            await this.wishlist.CreateAsync(wl);

            return "Done";
        }
    }
}
