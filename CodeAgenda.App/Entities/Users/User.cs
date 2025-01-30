using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Users
{
    public class User : Entity
    {
        #region Properties

        /// <summary>
        /// Name of the User.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// First name of the User.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Email of the User.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Projects related to the User.
        /// </summary>
        [NotMapped]
        public List<Project> Projects;

        /// <summary>
        /// Notes cretaed by the user
        /// </summary>
        [NotMapped]
        public List<Note> Notes;

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected User() { }

        /// <summary>
        /// Instance an object of User
        /// </summary>
        /// <param name="name">Name of the User.</param>
        /// <param name="firstName">First name of the User.</param>
        /// <param name="email">Email of the User.</param>
        public User(string name,
            string firstName,
            string email,
            Guid id)
            : base(id)
        {
            Name = name;
            FirstName = firstName;
            Email = email;
            Projects = new List<Project>();
            Notes = new List<Note>();
        }
    }
}
