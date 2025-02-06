using CodeAgenda.Contracts;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DatatAccess.Tests.Utilities;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DatatAccess.Tests
{
    public class NotificationTests
    {
        private INotificationRepository _notificationRepository;
        private IProjectRepository _projectRepository;
        private IUnitOfWork _unitOfWork;

        public NotificationTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _notificationRepository = new NotificationRepository(context);
            _projectRepository = new ProjectRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Theory]
        [InlineData("Configure Data Base", false)]
        [InlineData("Learn Pyhton", false)]
        public void Can_Add_New_Notification(
            string message,
            bool isRead
            )
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime reminderDate = DateTime.UtcNow.AddDays(7);
            Project project = _projectRepository.GetAll().First();
            Notification Notification = new Notification(message, reminderDate, isRead, project, id);


            //Execute
            _notificationRepository.Add(Notification);
            _unitOfWork.SaveChanges();

            //Assert
            Notification? loadedNotification = _notificationRepository.GetById(id);
            Assert.NotNull(loadedNotification);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Can_Get_Notification_By_Id(int position)
        {
            // Arrange
            var Notifications = _notificationRepository.GetAll().ToList();
            Assert.NotNull(Notifications);
            Assert.True(position < Notifications.Count);
            Notification NotificationToGet = Notifications[position];

            // Execute
            Notification? loadedNotification = _notificationRepository.GetById(NotificationToGet.Id);

            // Assert
            Assert.NotNull(loadedNotification);
        }

        [Fact]
        public void Cannot_Get_Notification_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Notification? loadedNotification = _notificationRepository.GetById(Guid.Empty);

            // Assert
            Assert.Null(loadedNotification);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Update_Notification(int position)
        {
            // Arrange
            var Notifications = _notificationRepository.GetAll().ToList();
            Assert.NotNull(Notifications);
            Assert.True(position < Notifications.Count);
            Notification NotificationToUpdate = Notifications[position];

            // Execute
            NotificationToUpdate.Message = "Python project";
            _notificationRepository.Update(NotificationToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Notification? loadedNotification = _notificationRepository.GetById(NotificationToUpdate.Id);
            Assert.NotNull(loadedNotification);
            Assert.Equal(loadedNotification.Message, NotificationToUpdate.Message);
        }

        [Theory]
        [InlineData(1)]
        public void Can_Delete_Notification(int position)
        {
            // Arrange
            var Notifications = _notificationRepository.GetAll().ToList();
            Assert.NotNull(Notifications);
            Assert.True(position < Notifications.Count);
            Notification NotificationToDelete = Notifications[position];

            // Execute
            _notificationRepository.Delete(NotificationToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Notification? loadedNotification = _notificationRepository.GetById(NotificationToDelete.Id);
            Assert.Null(loadedNotification);
        }
    }
}
