using CodeAgenda.Application.Abstract;
using CodeAgenda.Application.Projects.Queries.GetAllProjects;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Application.Projects.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler
        : IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_categoryRepository.GetAll());
        }
    }
}
