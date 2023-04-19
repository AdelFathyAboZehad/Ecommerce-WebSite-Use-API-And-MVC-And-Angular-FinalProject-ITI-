using Dtos.Category;
using MediatR;


namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class FilterCategoriesQuery : IRequest<IEnumerable<CategoryMinimalDTO>>
    {
        public string? filter { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
