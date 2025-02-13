using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery(Guid Id) : IQuery<Project?>;
}
