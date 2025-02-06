using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.DatatAccess.Tests
{
    public class UserTests
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userRepository = new UserRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Brian Michel", "Morales Cutting", "bmoralescutting@gmail.com")]
        [InlineData("José Carlos", "García Cruz", "josegc@gmail.com")]
        public void Can_Add_New_User(
            string name,
            string firstName,
            string email
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            User User = new User(name, firstName, email, id);

            //Execute
            _userRepository.Add(User);
            _unitOfWork.SaveChanges();

            //Assert
            User? loadedUser = _userRepository.GetById(id);
            Assert.NotNull(loadedUser);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Can_Get_User_By_Id(int position)
        {
            // Arrange
            var Users = _userRepository.GetAll().ToList();
            Assert.NotNull(Users);
            Assert.True(position < Users.Count);
            User UserToGet = Users[position];

            // Execute
            User? loadedUser = _userRepository.GetById(UserToGet.Id);

            // Assert
            Assert.NotNull(loadedUser);
        }

        [Fact]
        public void Cannot_Get_User_By_Invalid_Id()
        {
            // Arrange

            // Execute
            User? loadedUser = _userRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedUser);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Update_User(int position)
        {
            // Arrange
            var Users = _userRepository.GetAll().ToList();
            Assert.NotNull(Users);
            Assert.True(position < Users.Count);
            User UserToUpdate = Users[position];

            // Execute
            UserToUpdate.Name = "José";
            _userRepository.Update(UserToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            User? loadedUser = _userRepository.GetById(UserToUpdate.Id);
            Assert.NotNull(loadedUser);
            Assert.Equal(loadedUser.Name, UserToUpdate.Name);
        }

        [Theory]
        [InlineData(0)]
        public void Can_Delete_User(int position)
        {
            // Arrange
            var Users = _userRepository.GetAll().ToList();
            Assert.NotNull(Users);
            Assert.True(position < Users.Count);
            User UserToDelete = Users[position];

            // Execute
            _userRepository.Delete(UserToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            User? loadedUser = _userRepository.GetById(UserToDelete.Id);
            Assert.Null(loadedUser);
        }
    }
}
