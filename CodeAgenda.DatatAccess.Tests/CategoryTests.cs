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
using System.Drawing;

namespace CodeAgenda.DatatAccess.Tests
{
    public class CategoryTests
    {
        private ICategoryRepository _categoryRepository;
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _categoryRepository = new CategoryRepository(context);
            _projectRepository = new ProjectRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Machine learning", "Yellow")]
        public void Can_Add_New_Category(
            string name,
            string colorName
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Color color = Color.FromName(colorName);
            Project project = _projectRepository.GetAll().First();
            Category Category = new Category(name, color, project, id);


            //Execute
            _categoryRepository.Add(Category);
            _unitOfWork.SaveChanges();

            //Assert
            Category? loadedCategory = _categoryRepository.GetById(id);
            Assert.NotNull(loadedCategory);

        }

        [Theory]
        [InlineData(0)]
        public void Can_Get_Category_By_Id(int position)
        {
            // Arrange
            var Categorys = _categoryRepository.GetAll().ToList();
            Assert.NotNull(Categorys);
            Assert.True(position < Categorys.Count);
            Category CategoryToGet = Categorys[position];

            // Execute
            Category? loadedCategory = _categoryRepository.GetById(CategoryToGet.Id);

            // Assert
            Assert.NotNull(loadedCategory);
        }

        [Fact]
        public void Cannot_Get_Category_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Category? loadedCategory = _categoryRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedCategory);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Update_Category(int position)
        {
            // Arrange
            var Categorys = _categoryRepository.GetAll().ToList();
            Assert.NotNull(Categorys);
            Assert.True(position < Categorys.Count);
            Category CategoryToUpdate = Categorys[position];

            // Execute
            CategoryToUpdate.Name = "IA";
            _categoryRepository.Update(CategoryToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Category? loadedCategory = _categoryRepository.GetById(CategoryToUpdate.Id);
            Assert.NotNull(loadedCategory);
            Assert.Equal(loadedCategory.Name, CategoryToUpdate.Name);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Delete_Category(int position)
        {
            // Arrange
            var Categorys = _categoryRepository.GetAll().ToList();
            Assert.NotNull(Categorys);
            Assert.True(position < Categorys.Count);
            Category CategoryToDelete = Categorys[position];

            // Execute
            _categoryRepository.Delete(CategoryToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Category? loadedCategory = _categoryRepository.GetById(CategoryToDelete.Id);
            Assert.Null(loadedCategory);
        }
    }
}
