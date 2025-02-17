﻿using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetAssignmnetById
{
    public class GetAssignmentByIdQueryHandler
        : IQueryHandler<GetAssignmentByIdQuery, Assignment?>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAssignmentByIdQueryHandler(
            IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public Task<Assignment?> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_assignmentRepository.GetById(request.Id));
        }
    }
}
