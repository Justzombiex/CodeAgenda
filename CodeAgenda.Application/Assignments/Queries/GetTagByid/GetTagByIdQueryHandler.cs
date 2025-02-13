using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetTagByid
{
    public class GetTagByIdQueryHandler
     : IQueryHandler<GetTagByIdQuery, Tag?>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagByIdQueryHandler(
            ITagRepository projectRepository)
        {
            _tagRepository = projectRepository;
        }

        public Task<Tag?> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tagRepository.GetById(request.Id));
        }
    }

}
