using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
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
            return _context.Set<Notification>().Find(id);
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
