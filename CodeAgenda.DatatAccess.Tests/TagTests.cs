using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeAgenda.DatatAccess.Tests
{
    
    public class TagTests
    {
        private ITagRepository _tagRepository;
        private IUnitOfWork _unitOfWork;

        public TagTests() 
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _tagRepository = new TagRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("C#", "Red")]
        public void Can_Add_New_Tag(
            string tagName,
            string colorName
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Color color = Color.FromName(colorName);
            Tag tag = new Tag(tagName, color, id);

            //Execute
            _tagRepository.AddTag(tag);
            _unitOfWork.SaveChanges();

            //Assert
            Tag? loadedTag = _tagRepository.Get(id);
            Assert.NotNull(loadedTag);
             
        }

    }
}
