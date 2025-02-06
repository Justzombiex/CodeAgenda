using System.ComponentModel.DataAnnotations;

namespace CodeAgenda.Domain.Entities.Common
{
    /// <summary>
    /// Base class for all the entities in the DB.
    /// </summary>
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// Identifier on the data carrier.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Required by EntityFramework.
        /// </summary>
        protected Entity()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        public Entity(Guid id)
        {
            Id = id;
        }

    }
}