﻿using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Common
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Add a Notification in the DB.
        /// </summary>
        /// <param name="notification">Notification to add.</param>
        void Add(Notification notification);

        /// <summary>
        /// Gets a Notification from DB.
        /// </summary>
        /// <param name="id">Notification Id</param>
        /// <returns> Notification to exist in DB, otherwise <see langword="null"/></returns>
        Notification? Get(Guid id);

        /// <summary>
        /// Gets all Notifications from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Notification> GetAll();

        /// <summary>
        /// Update a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to update.</param>
        void Update(Notification Notification);

        /// <summary>
        /// Delete a Notification in the DB.
        /// </summary>
        /// <param name="Notification">Notification to delete.</param>
        void Delete(Notification Notification);
    }
}
