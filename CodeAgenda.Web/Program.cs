using CodeAgenda.IOC.Dependencies;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.DataAccess.Repositories;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.Application;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Services.Services.Assignments;
using CodeAgenda.Services.Services.Common;
using CodeAgenda.Services.Services.Projects;
using CodeAgenda.Services.Services.Users;
using CodeAgenda.Services.Interfaces.Assignments;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Services.Interfaces.Common;
using CodeAgenda.Services.Interfaces.Users;
using CodeAgenda.Contracts.Projects;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.DataAccess.Repositories.Projects;

namespace CodeAgenda.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            builder.Services.InjectDependencies(builder.Configuration);

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IAssignmentService, AssignmentService>();
            builder.Services.AddScoped<ITagAssignmentService, TagAssignmentService>();
            builder.Services.AddScoped<ITagProjectService, TagProjectService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<INoteRepository, NoteRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
