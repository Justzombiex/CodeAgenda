using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DataAccess;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.DatatAccess.Tests
{
    public class NoteTests
    {
        private INoteRepository _noteRepository;
        private IProjectRepository _projectRepository;
        private IAssignmentRepository _assignmentRepository;
        private IUnitOfWork _unitOfWork;

        public NoteTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _noteRepository = new NoteRepository(context);
            _projectRepository = new ProjectRepository(context);
            _assignmentRepository = new AssignmentRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Add new assignment")]
        public void Can_Add_New_NoteProject(
            string content
            )
        {
            //TODO: Verificar la relación de las notas con proyectos y assignments
            //Arrange
            Guid id = Guid.NewGuid();
            Project project = _projectRepository.GetAll().First();
            Note note = new NoteProject(content, project, id);

            //Execute
            _noteRepository.Add(note);
            _unitOfWork.SaveChanges();

            //Assert
            Note? loadedNote = _noteRepository.GetById(id);
            Assert.NotNull(loadedNote);

        }

        [Theory]
        [InlineData("Add new element")]
        public void Can_Add_New_NoteAssignment(
            string content
            )
        {
            //TODO: Verificar la relación de las notas con proyectos y assignments
            //Arrange
            Guid id = Guid.NewGuid();
            Assignment assignment = _assignmentRepository.GetAll().First();
            Note note = new NoteAssignment(content, assignment, id);

            //Execute
            _noteRepository.Add(note);
            _unitOfWork.SaveChanges();

            //Assert
            Note? loadedNote = _noteRepository.GetById(id);
            Assert.NotNull(loadedNote);

        }

        [Theory]
        [InlineData(0)]
        public void Can_Get_Note_By_Id(int position)
        {
            // Arrange
            var Notes = _noteRepository.GetAll().ToList();
            Assert.NotNull(Notes);
            Assert.True(position < Notes.Count);
            Note NoteToGet = Notes[position];

            // Execute
            Note? loadedNote = _noteRepository.GetById(NoteToGet.Id);

            // Assert
            Assert.NotNull(loadedNote);
        }

        [Fact]
        public void Cannot_Get_Note_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Note? loadedNote = _noteRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedNote);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Update_Note(int position)
        {
            // Arrange
            var Notes = _noteRepository.GetAll().ToList();
            Assert.NotNull(Notes);
            Assert.True(position < Notes.Count);
            Note NoteToUpdate = Notes[position];

            // Execute
            NoteToUpdate.Content = "Python project";
            _noteRepository.Update(NoteToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Note? loadedNote = _noteRepository.GetById(NoteToUpdate.Id);
            Assert.NotNull(loadedNote);
            Assert.Equal(loadedNote.Content, NoteToUpdate.Content);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Delete_Note(int position)
        {
            // Arrange
            var Notes = _noteRepository.GetAll().ToList();
            Assert.NotNull(Notes);
            Assert.True(position < Notes.Count);
            Note NoteToDelete = Notes[position];

            // Execute
            _noteRepository.Delete(NoteToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Note? loadedNote = _noteRepository.GetById(NoteToDelete.Id);
            Assert.Null(loadedNote);
        }
    }
}
