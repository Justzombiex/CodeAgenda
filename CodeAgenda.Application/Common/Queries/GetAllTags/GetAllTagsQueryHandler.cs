using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllTags
{
    public class GetAllTagsQueryHandler
    : IQueryHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository;

        public GetAllTagsQueryHandler(
            ITagRepository tagAssignmentRepository)
        {
            _tagRepository = tagAssignmentRepository;
        }

        public Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tagRepository.GetAll());
        }
    }

}
