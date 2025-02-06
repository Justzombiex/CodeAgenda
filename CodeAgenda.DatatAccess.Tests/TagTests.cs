using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using System.Drawing;

namespace CodeAgenda.DatatAccess.Tests
{

    public class TagTests
    {
        private ITagRepository _tagRepository;
        private IProjectRepository _projectRepository;
        private IAssignmentRepository _assignmentRepository;
        private IUnitOfWork _unitOfWork;

        public TagTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _tagRepository = new TagRepository(context);
            _projectRepository = new ProjectRepository(context);
            _assignmentRepository = new AssignmentRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Python", "Blue")]
        public void Can_Add_New_TagProject(
            string tagName,
            string colorName
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Color color = Color.FromName(colorName);
            Project project = _projectRepository.GetAll().First();
            Tag tag = new TagProject(tagName, color, project, id);

            //Execute
            _tagRepository.Add(tag);
            _unitOfWork.SaveChanges();

            //Assert
            Tag? loadedTag = _tagRepository.GetById(id);
            Assert.NotNull(loadedTag);

        }

        [Theory]
        [InlineData("C#", "Red")]
        public void Can_Add_New_TagAssignment(
            string tagName,
            string colorName
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Color color = Color.FromName(colorName);
            Assignment assignment = _assignmentRepository.GetAll().First();
            Tag tag = new TagAssignment(tagName, color, assignment, id);

            //Execute
            _tagRepository.Add(tag);
            _unitOfWork.SaveChanges();

            //Assert
            Tag? loadedTag = _tagRepository.GetById(id);
            Assert.NotNull(loadedTag);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Can_Get_Tag_By_Id(int position)
        {
            // Arrange
            var tags = _tagRepository.GetAll().ToList();
            Assert.NotNull(tags);
            Assert.True(position < tags.Count);
            Tag tagToGet = tags[position];

            // Execute
            Tag? loadedTag = _tagRepository.GetById(tagToGet.Id);

            // Assert
            Assert.NotNull(loadedTag);
        }

        [Fact]
        public void Cannot_Get_Tag_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Tag? loadedTag = _tagRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedTag);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Update_Tag(int position)
        {
            // Arrange
            var tags = _tagRepository.GetAll().ToList();
            Assert.NotNull(tags);
            Assert.True(position < tags.Count);
            Tag tagToUpdate = tags[position];

            // Execute
            Color color = Color.White;
            tagToUpdate.Color = color;
            _tagRepository.Update(tagToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Tag? loadedtag = _tagRepository.GetById(tagToUpdate.Id);
            Assert.NotNull(loadedtag);
            Assert.Equal(loadedtag.Color, color);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Delete_Tag(int position)
        {
            // Arrange
            var tags = _tagRepository.GetAll().ToList();
            Assert.NotNull(tags);
            Assert.True(position < tags.Count);
            Tag tagToDelete = tags[position];

            // Execute
            _tagRepository.Delete(tagToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Tag? loadedTag = _tagRepository.GetById(tagToDelete.Id);
            Assert.Null(loadedTag);
        }

    }
}
