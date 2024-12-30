using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract
{
    /// <summary>
    /// Defines the properties and methods of a repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Indicates whether the repository is in a transaction.
        /// </summary>
        bool IsInTransaction { get; }

        /// <summary>
        /// Start a transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Saves changes to the current transaction and closes it.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Deletes the current transaction without saving changes to the DB.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves changes to the current transaction without closing it.
        /// </summary>
        void PartialCommit();

    }
}
