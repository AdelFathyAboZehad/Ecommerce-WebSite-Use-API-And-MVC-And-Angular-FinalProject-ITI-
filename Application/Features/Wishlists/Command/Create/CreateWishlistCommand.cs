using MediatR;

namespace Application.Features.Wishlists.Command.Create
{
    public class CreateWishlistCommand : IRequest<string>
    {
        public int uid { get; set; }
        public long pid { get; set; }

    }
}
