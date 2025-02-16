using CodeAgenda.Application.Assignments.Commands.CreateAssignment;
using CodeAgenda.Application.Assignments.Commands.DeleteAssignment;
using CodeAgenda.Application.Assignments.Commands.UpdateAssignment;
using CodeAgenda.Application.Assignments.Queries.GetAllAssignments;
using CodeAgenda.Application.Assignments.Queries.GetAssignmnetById;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DTO.Assignments;

namespace CodeAgenda.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<AssignmentDTO> Create(CreateAssignmentCommand command);
        Task Delete(DeleteAssignmentCommand command);
        Task Update(UpdateAssignmentCommand command);
        Task<List<AssignmentDTO>> GetAll(GetAllAssignmentsQuery query);
        Task<AssignmentDTO> GetById(GetAssignmentByIdQuery query);
        Task<Assignment?> GetAssignmentById(Guid AssignmentId);
    }
}
