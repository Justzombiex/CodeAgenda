using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetAllProjects
{
    public record GetAllProjectsQuery : IQuery<IEnumerable<Project>>;

}
