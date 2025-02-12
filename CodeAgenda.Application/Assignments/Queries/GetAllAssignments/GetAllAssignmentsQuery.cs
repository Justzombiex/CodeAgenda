using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetAllAssignments
{
    public record GetAllAssignmentsQuery : IQuery<IEnumerable<Assignment>>;

}
