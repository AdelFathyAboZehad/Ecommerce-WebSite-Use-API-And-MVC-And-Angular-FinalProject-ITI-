
using Dtos.Category;
using MediatR;
 

namespace Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsDto>
    {
        public int Id { get; set; }
   
    }
}
