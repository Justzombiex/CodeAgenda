using CodeAgenda.Application.Projects.Commands.CreateProject;
using CodeAgenda.Application.Projects.Commands.DeleteProject;
using CodeAgenda.Application.Projects.Commands.UpdateProject;
using CodeAgenda.Application.Projects.Queries.GetAllProjects;
using CodeAgenda.Application.Projects.Queries.GetProjectById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;

namespace CodeAgenda.Services.Interfaces.Projects
{
    public interface IProjectService
    {
        Task<ProjectDTO> Create(CreateProjectCommand command);
        Task Delete(DeleteProjectCommand command);
        Task Update(UpdateProjectCommand command);
        Task<List<ProjectDTO>> GetAll(GetAllProjectsQuery query);
        Task<ProjectDTO> GetById(GetProjectByIdQuery query);
        Task<Project?> GetProjectById(Guid ProjectId);
    }
}
