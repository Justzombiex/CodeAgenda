using CodeAgenda.Application.Projects.Commands.CreateCategory;
using CodeAgenda.Application.Projects.Commands.DeleteCategory;
using CodeAgenda.Application.Projects.Commands.UpdateCategory;
using CodeAgenda.Application.Projects.Queries.GetAllCategories;
using CodeAgenda.Application.Projects.Queries.GetCategoryById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;

namespace CodeAgenda.Services.Interfaces.Projects
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Create(CreateCategoryCommand command);
        Task Delete(DeleteCategoryCommand command);
        Task Update(UpdateCategoryCommand command);
        Task<List<CategoryDTO>> GetAll(GetAllCategoriesQuery query);
        Task<CategoryDTO> GetById(GetCategoryByIdQuery query);
        Task<Category?> GetCategoryById(Guid CategoryId);
    }
}
