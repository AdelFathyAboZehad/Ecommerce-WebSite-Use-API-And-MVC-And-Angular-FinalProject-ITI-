using Application.Contracts;
using MediatR;
using Dtos.Category;


namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class FilterCategoriesQueryHandler : IRequestHandler<FilterCategoriesQuery, IEnumerable<CategoryMinimalDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public FilterCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task< IEnumerable<CategoryMinimalDTO>> Handle(FilterCategoriesQuery request, CancellationToken cancellationToken)
        {
           

            return (await _categoryRepository.FilterByAsync(request.filter , request.ParentCategoryId))
                .Select(c => new CategoryMinimalDTO() { Id = c.Id, NameEN = c.NameEN ,NameAR=c.NameAR,ImageUrl = c.ImageURL});
        }

       
    }
}
