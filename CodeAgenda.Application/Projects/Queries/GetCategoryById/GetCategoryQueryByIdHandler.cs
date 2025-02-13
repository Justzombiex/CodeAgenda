using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler
    : IQueryHandler<GetCategoryByIdQuery, Category?>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_categoryRepository.GetById(request.Id));
        }
    }
}
