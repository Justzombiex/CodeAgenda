using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.DatatAccess.Tests
{
    public class ProjectTests
    {
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public ProjectTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userRepository = new UserRepository(context);
            _projectRepository = new ProjectRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("To do List", "Student to do list ")]
        [InlineData("Data base project", "Data base learning")]
        public void Can_Add_New_Project(
            string name,
            string description
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow.AddDays(7);
            User user = _userRepository.GetAll().First();
            Project Project = new Project(name, description, startDate, endDate, user, id);

            //Execute
            _projectRepository.Add(Project);
            _unitOfWork.SaveChanges();

            //Assert
            Project? loadedProject = _projectRepository.GetById(id);
            Assert.NotNull(loadedProject);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Can_Get_Project_By_Id(int position)
        {
            // Arrange
            var Projects = _projectRepository.GetAll().ToList();
            Assert.NotNull(Projects);
            Assert.True(position < Projects.Count);
            Project ProjectToGet = Projects[position];

            // Execute
            Project? loadedProject = _projectRepository.GetById(ProjectToGet.Id);

            // Assert
            Assert.NotNull(loadedProject);
        }

        [Fact]
        public void Cannot_Get_Project_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Project? loadedProject = _projectRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedProject);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Update_Project(int position)
        {
            // Arrange
            var Projects = _projectRepository.GetAll().ToList();
            Assert.NotNull(Projects);
            Assert.True(position < Projects.Count);
            Project ProjectToUpdate = Projects[position];

            // Execute
            ProjectToUpdate.Name = "Python project";
            _projectRepository.Update(ProjectToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Project? loadedProject = _projectRepository.GetById(ProjectToUpdate.Id);
            Assert.NotNull(loadedProject);
            Assert.Equal(loadedProject.Name, ProjectToUpdate.Name);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Delete_Project(int position)
        {
            // Arrange
            var Projects = _projectRepository.GetAll().ToList();
            Assert.NotNull(Projects);
            Assert.True(position < Projects.Count);
            Project ProjectToDelete = Projects[position];

            // Execute
            _projectRepository.Delete(ProjectToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Project? loadedProject = _projectRepository.GetById(ProjectToDelete.Id);
            Assert.Null(loadedProject);
        }
    }
}
