using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateTag;
using CodeAgenda.Application.Assignments.Commands.DeleteTag;
using CodeAgenda.Application.Assignments.Commands.UpdateTag;
using CodeAgenda.Application.Common.Queries.GetAllTags;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.DTO.Common;
using CodeAgenda.Services.Interfaces.Common;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagProjectController : ControllerBase
    {
        private readonly ITagProjectService _tagProjectService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public TagProjectController(ITagProjectService tagprojectService, IProjectService projectService, IMapper mapper)
        {
            _tagProjectService = tagprojectService;
            _projectService = projectService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<TagProjectDTO>>();

            try
            {
                var query = new GetAllTagsQuery();
                var tagProjects = await _tagProjectService.GetAll(query);

                rsp.status = true;
                rsp.value = tagProjects;
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
            var rsp = new Response<TagProjectDTO?>();

            try
            {
                var query = new GetTagByIdQuery(id);
                var tagProjectDto = await _tagProjectService.GetById(query);

                rsp.status = true;
                rsp.value = tagProjectDto;
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
        public async Task<IActionResult> Create([FromBody] TagProjectDTO tagProjectDto)
        {
            var rsp = new Response<TagProjectDTO>();
            try
            {
                var project = await _projectService.GetProjectById(tagProjectDto.ProjectId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var tagProject = _mapper.Map<TagProject>(tagProjectDto);
                var command = new CreateTagProjectCommand(tagProject.Name, tagProject.Color, project);

                rsp.status = true;
                rsp.value = await _tagProjectService.Create(command);
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
        public async Task<IActionResult> Edit([FromBody] TagProjectDTO tagProjectDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var tagProject = _mapper.Map<TagProject>(tagProjectDto);
                var command = new UpdateTagProjectCommand(tagProject);

                rsp.status = true;
                await _tagProjectService.Update(command);
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
                var command = new DeleteTagCommand(id);
                await _tagProjectService.Delete(command);
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

