using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
     : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryRepository.Update(request.Category);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
