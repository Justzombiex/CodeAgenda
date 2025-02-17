using CodeAgenda.Contracts.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DataAccess.Repositories.Projects
{
    public class NotificationRepository
        : RepositoryBase, INotificationRepository
    {
        public NotificationRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Notification notification)
        {
            _context.Notification.Add(notification);
        }

        Notification? INotificationRepository.GetById(Guid id)
        {
            var notification = _context.Notification.FirstOrDefault(x => x.Id == id);
            if (notification == null)
            {
                throw new Exception("Notification not found");
            }
            return notification;
        }

        public IEnumerable<Notification> GetAll()
        {
            return _context.Notification.ToList();
        }

        public void Update(Notification Notification)
        {
            _context.Notification.Update(Notification);
        }

        public void Delete(Notification Notification)
        {
            _context.Notification.Remove(Notification);
        }

    }
}
