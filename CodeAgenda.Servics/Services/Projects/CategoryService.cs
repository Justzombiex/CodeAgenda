using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Application.Projects.Commands.CreateCategory;
using CodeAgenda.Application.Projects.Commands.DeleteCategory;
using CodeAgenda.Application.Projects.Commands.UpdateCategory;
using CodeAgenda.Application.Projects.Queries.GetAllCategories;
using CodeAgenda.Application.Projects.Queries.GetCategoryById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using MediatR;

namespace CodeAgenda.Services.Services.Projects
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CreateCategoryCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<CategoryDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteCategoryCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<CategoryDTO>> GetAll(GetAllCategoriesQuery query)
        {
            try
            {
                var categorys = await _mediator.Send(query);
                var category = _mapper.Map<List<CategoryDTO>>(categorys.OfType<Category>());
                return category;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<CategoryDTO?> GetById(GetCategoryByIdQuery query)
        {
            try
            {
                var category = await _mediator.Send(query);
                var categoryDTO = _mapper.Map<CategoryDTO>(category);
                return categoryDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateCategoryCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<Category?> GetCategoryById(Guid categoryId)
        {
            var query = new GetTagByIdQuery(categoryId);
            var categoryDto = await _mediator.Send(query);
            var category = _mapper.Map<Category>(categoryDto);
            return category;
        }
    }
}
