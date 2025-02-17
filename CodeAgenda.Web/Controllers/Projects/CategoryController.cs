using AutoMapper;
using CodeAgenda.Application.Projects.Commands.CreateCategory;
using CodeAgenda.Application.Projects.Commands.DeleteCategory;
using CodeAgenda.Application.Projects.Commands.UpdateCategory;
using CodeAgenda.Application.Projects.Queries.GetAllCategories;
using CodeAgenda.Application.Projects.Queries.GetCategoryById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IProjectService projectService, IMapper mapper)
        {
            _categoryService = categoryService;
            _projectService = projectService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<CategoryDTO>>();

            try
            {
                var query = new GetAllCategoriesQuery();
                var categorys = await _categoryService.GetAll(query);

                rsp.status = true;
                rsp.value = categorys;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = new Response<CategoryDTO?>();

            try
            {
                var query = new GetCategoryByIdQuery(id);
                var categoryDto = await _categoryService.GetById(query);

                rsp.status = true;
                rsp.value = categoryDto;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO categoryDto)
        {
            var rsp = new Response<CategoryDTO>();
            try
            {
                var project = await _projectService.GetProjectById(categoryDto.ProjectId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var category = _mapper.Map<Category>(categoryDto);
                var command = new CreateCategoryCommand(category.Name, category.Color, project);

                rsp.status = true;
                rsp.value = await _categoryService.Create(command);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] CategoryDTO categoryDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var project = await _projectService.GetProjectById(categoryDto.ProjectId);

                var category = _mapper.Map<Category>(categoryDto);
                var command = new UpdateCategoryCommand(category);

                rsp.status = true;
                await _categoryService.Update(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                var command = new DeleteCategoryCommand(id);
                await _categoryService.Delete(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
