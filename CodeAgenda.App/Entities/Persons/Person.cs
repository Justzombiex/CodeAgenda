using CodeAgenda.Domain.Entities.Activities;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Persons
{
    public class Person : Entity
    {
        #region Properties

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }    

        /// <summary>
        /// First name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Email of the person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Activities related to the person.
        /// </summary>
        public List<Activity> Activities { get; set; } = new List<Activity>();

        /// <summary>
        /// Projects related to the person.
        /// </summary>
        public List<Project> Projects { get; } = new List<Project>();

        #endregion Properties

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Person() { }

        /// <summary>
        /// Instance an object of Person
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="firstName">First name of the person.</param>
        /// <param name="email">Email of the person.</param>
        public Person(string name, string firstName, string email)
        {
            Name = name;
            FirstName = firstName;
            Email = email;
        }
    }
}
