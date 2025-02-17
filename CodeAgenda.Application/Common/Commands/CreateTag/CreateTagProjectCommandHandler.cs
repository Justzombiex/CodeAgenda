using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Application.Assignments.Commands.CreateTag
{
    public class CreateTagProjectCommandHandler
     : ICommandHandler<CreateTagProjectCommand, TagProject>
    {
        private readonly ITagRepository _tagProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTagProjectCommandHandler(
            ITagRepository tagProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _tagProjectRepository = tagProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<TagProject> Handle(CreateTagProjectCommand request, CancellationToken cancellationToken)
        {
            TagProject result = new TagProject(
                request.name,
                request.color,
                request.project, 
                Guid.NewGuid());

            _tagProjectRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
