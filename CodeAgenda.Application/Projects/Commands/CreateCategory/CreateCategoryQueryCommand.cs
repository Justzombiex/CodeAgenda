using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
         : ICommandHandler<CreateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category result = new Category(
                request.name,
                request.color,
                request.project,
                Guid.NewGuid());

            _categoryRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
