using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Types
{
    /// <summary>
    /// Status of the activity
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Pending activity
        /// </summary>
        Pending,
        /// <summary>
        /// In progress activity
        /// </summary>
        InProgress,
        /// <summary>
        /// Completed activity
        /// </summary>
        Completed
    }
}
