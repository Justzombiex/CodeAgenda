using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Types;

namespace CodeAgenda.DatatAccess.Tests
{
    public class AssignmentTests
    {
        private IAssignmentRepository _assignmentRepository;
        private IUnitOfWork _unitOfWork;
        private IProjectRepository _projectRepository;

        public AssignmentTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _assignmentRepository = new AssignmentRepository(context);
            _projectRepository = new ProjectRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Configure Data Base", "Learn postgresql", Status.Pending)]
        public void Can_Add_New_Assignment(
            string name,
            string description,
            Status status
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime finishDate = DateTime.UtcNow.AddDays(7);
            Project project = _projectRepository.GetAll().First();
            Assignment assignment = new Assignment(name, description, finishDate, status, project, id);

            //Execute
            _assignmentRepository.Add(assignment);
            _unitOfWork.SaveChanges();

            //Assert
            Assignment? loadedAssignment = _assignmentRepository.GetById(id);
            Assert.NotNull(loadedAssignment);

        }

        [Theory]
        [InlineData(0)]
        public void Can_Get_Assignment_By_Id(int position)
        {
            // Arrange
            var Assignments = _assignmentRepository.GetAll().ToList();
            Assert.NotNull(Assignments);
            Assert.True(position < Assignments.Count);
            Assignment AssignmentToGet = Assignments[position];

            // Execute
            Assignment? loadedAssignment = _assignmentRepository.GetById(AssignmentToGet.Id);

            // Assert
            Assert.NotNull(loadedAssignment);
        }

        [Fact]
        public void Cannot_Get_Assignment_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Assignment? loadedAssignment = _assignmentRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedAssignment);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Update_Assignment(int position)
        {
            // Arrange
            var Assignments = _assignmentRepository.GetAll().ToList();
            Assert.NotNull(Assignments);
            Assert.True(position < Assignments.Count);
            Assignment AssignmentToUpdate = Assignments[position];

            // Execute
            AssignmentToUpdate.Name = "Python project";
            _assignmentRepository.Update(AssignmentToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Assignment? loadedAssignment = _assignmentRepository.GetById(AssignmentToUpdate.Id);
            Assert.NotNull(loadedAssignment);
            Assert.Equal(loadedAssignment.Name, AssignmentToUpdate.Name);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Delete_Assignment(int position)
        {
            // Arrange
            var Assignments = _assignmentRepository.GetAll().ToList();
            Assert.NotNull(Assignments);
            Assert.True(position < Assignments.Count);
            Assignment AssignmentToDelete = Assignments[position];

            // Execute
            _assignmentRepository.Delete(AssignmentToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Assignment? loadedAssignment = _assignmentRepository.GetById(AssignmentToDelete.Id);
            Assert.Null(loadedAssignment);
        }
    }
}
