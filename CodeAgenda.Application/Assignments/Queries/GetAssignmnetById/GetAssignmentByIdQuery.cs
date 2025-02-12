using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetAssignmnetById
{
    public record GetAssignmentByIdQuery(Guid Id) : IQuery<Assignment?>;

}


