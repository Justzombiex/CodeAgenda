using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;

namespace CodeAgenda.Application.Projects.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
         : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var CategoryToDelete = _categoryRepository.GetById(request.Id);
            if (CategoryToDelete is null)
                return Task.CompletedTask;
            _categoryRepository.Delete(CategoryToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
