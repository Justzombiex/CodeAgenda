using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.Domain.Entities.Projects;
using System.Drawing;
using CodeAgenda.DataAccess.FluentConfigurations;

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
        /// Note table.
        /// </summary>
        public DbSet<Note> Note { get; set; }

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
        public ApplicationContext()
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
            optionsBuilder.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Base classes mapping

            modelBuilder.Entity<Assignment>().ToTable("Assignments");

            modelBuilder.Entity<Note>().ToTable("Notes");

            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Project>().ToTable("Projects");

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().Property(p => p.Color)
                .HasConversion(
                c => c.ToArgb(),
                c => Color.FromArgb(c));

            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<Tag>().Property(p => p.Color)
                .HasConversion(
                c => c.ToArgb(),
                c => Color.FromArgb(c));


            #endregion

            modelBuilder.ApplyConfiguration(new AssignmentFluentConfiguration());
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
                var connectionString = "Data Source = CodeAgendaDB.npgsql";
                optionsBuilder.UseNpgsql(connectionString);
            }
            catch (Exception)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
                throw;
            }

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}

