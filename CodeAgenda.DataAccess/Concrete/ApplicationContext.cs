using CodeAgenda.DataAccess.FluentConfigurations.Assignments;
using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.DataAccess.FluentConfigurations.Projects;
using CodeAgenda.DataAccess.FluentConfigurations.Users;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeAgenda.DataAccess.Concrete
{
    /// <summary>
    /// Defines the structure of the application database.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        #region Tables 

        /// <summary>
        /// Assignment table.
        /// </summary>
        public DbSet<Assignment> Assignment { get; set; }

        /// <summary>
        /// Tag table.
        /// </summary>
        public DbSet<Tag> Tag { get; set; }

        /// <summary>
        /// TagAssignment table 
        /// </summary>
        public DbSet<TagAssignment> TagAssignments { get; set; }

        /// <summary>
        /// TagProjects table
        /// </summary>
        public DbSet<TagProject> TagProjects { get; set; }

        /// <summary>
        /// Note table.
        /// </summary>
        public DbSet<Note> Note { get; set; }

        /// <summary>
        /// NoteAssignment table 
        /// </summary>
        public DbSet<NoteAssignment> NoteAssignments { get; set; }

        /// <summary>
        /// NoteProjects table
        /// </summary>
        public DbSet<NoteProject> NoteProjects { get; set; }

        /// <summary>
        /// Notification table.
        /// </summary>
        public DbSet<Notification> Notification { get; set; }

        /// <summary>
        /// User table.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Category table.
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// Project table.
        /// </summary>
        public DbSet<Project> Project { get; set; }

        #endregion


        /// <summary>
        /// Requerired by EntityFrameworkCore for migration.
        /// </summary>
        protected ApplicationContext()
        {
        }

        /// <summary>
        /// Initialize an object. <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Connection string.
        /// </param>
        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        /// <summary>
        /// initialize an object. <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Context options.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=CodeAgendaDB;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AssignmentEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new TagEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new NoteEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new NotificationEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new TagAssignmentsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagProjectsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NoteAssignmentEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new NoteProjectEntityTypeConfigurationBase());

        }


        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

    }

    /// <summary>
    /// Habilita características en tiempo de diseño de la base de datos de la aplicación.
    /// Ej: Migraciones.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            try
            {
                var connectionString = "Host=localhost;Database=CodeAgendaDB;Username=postgres;Password=1234";
                optionsBuilder.UseNpgsql(connectionString);
            }
            catch (Exception)
            {
                //handle error here.. means DLL has no sattelite configuration file.
                throw;
            }

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}

