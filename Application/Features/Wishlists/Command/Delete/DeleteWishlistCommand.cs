using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Wishlists.Command.Delete
{
    public class DeleteWishlistCommand : IRequest<bool>
    {
        public int uid { get; set; }
        public long pid { get; set; }

    }
}
