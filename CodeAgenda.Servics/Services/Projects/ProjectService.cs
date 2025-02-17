using AutoMapper;
using CodeAgenda.Application.Projects.Commands.CreateProject;
using CodeAgenda.Application.Projects.Commands.DeleteProject;
using CodeAgenda.Application.Projects.Commands.UpdateProject;
using CodeAgenda.Application.Projects.Queries.GetAllProjects;
using CodeAgenda.Application.Projects.Queries.GetProjectById;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using MediatR;

namespace CodeAgenda.Services.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProjectDTO> Create(CreateProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<ProjectDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteProjectCommand command)
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

        public async Task<List<ProjectDTO>> GetAll(GetAllProjectsQuery query)
        {
            try
            {
                var projects = await _mediator.Send(query);
                var projectDtos = _mapper.Map<List<ProjectDTO>>(projects);
                return projectDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<ProjectDTO?> GetById(GetProjectByIdQuery query)
        {
            try
            {
                var project = await _mediator.Send(query);
                var projectDto = _mapper.Map<ProjectDTO>(project);
                return projectDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateProjectCommand command)
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

        public async Task<Project?> GetProjectById(Guid projectId)
        {
            var query = new GetProjectByIdQuery(projectId);
            var projectDto = await _mediator.Send(query);
            var project = _mapper.Map<Project>(projectDto);
            return project;
        }
    }
}

