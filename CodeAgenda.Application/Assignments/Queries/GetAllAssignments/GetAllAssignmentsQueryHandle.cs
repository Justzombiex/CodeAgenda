using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetAllAssignments
{
    public class GetAllAssignmentsQueryHandler
        : IQueryHandler<GetAllAssignmentsQuery, IEnumerable<Assignment>>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAllAssignmentsQueryHandler(
            IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public Task<IEnumerable<Assignment>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_assignmentRepository.GetAll());
        }
    }
}
