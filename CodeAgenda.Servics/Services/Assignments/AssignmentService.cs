using AutoMapper;
using CodeAgenda.Application.Assignments.Commands.CreateAssignment;
using CodeAgenda.Application.Assignments.Commands.DeleteAssignment;
using CodeAgenda.Application.Assignments.Commands.UpdateAssignment;
using CodeAgenda.Application.Assignments.Queries.GetAllAssignments;
using CodeAgenda.Application.Assignments.Queries.GetAssignmnetById;
using CodeAgenda.Application.Users.Queries.GetUserById;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.Services.Interfaces.Assignments;
using MediatR;

namespace CodeAgenda.Services.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AssignmentService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<AssignmentDTO> Create(CreateAssignmentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<AssignmentDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteAssignmentCommand command)
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

        public async Task<List<AssignmentDTO>> GetAll(GetAllAssignmentsQuery query)
        {
            try
            {
                var assignments = await _mediator.Send(query);
                var assignmentDtos = _mapper.Map<List<AssignmentDTO>>(assignments);
                return assignmentDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<AssignmentDTO> GetById(GetAssignmentByIdQuery query)
        {
            try
            {
                var assignment = await _mediator.Send(query);
                var assignmentDto = _mapper.Map<AssignmentDTO>(assignment);
                return assignmentDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateAssignmentCommand command)
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

        public async Task<Assignment?> GetAssignmentById(Guid assignmentId)
        {
            var query = new GetAssignmentByIdQuery(assignmentId);
            var assignmentDto = await _mediator.Send(query);
            var assignment = _mapper.Map<Assignment>(assignmentDto);
            return assignment;
        }

    }
}
