using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Common
{
    /// <summary>
    /// Base class for all the entities in the DB.
    /// </summary>
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// DB Identifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

    }
}