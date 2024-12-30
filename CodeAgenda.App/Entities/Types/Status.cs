using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Types
{
    /// <summary>
    /// Status of the Assignment
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Pending Assignment
        /// </summary>
        Pending,
        /// <summary>
        /// In progress Assignment
        /// </summary>
        InProgress,
        /// <summary>
        /// Completed Assignment
        /// </summary>
        Completed
    }
}
