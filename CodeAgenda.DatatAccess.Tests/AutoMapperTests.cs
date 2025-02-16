using AutoMapper;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Projects;
using CodeAgenda.DTO.Users;
using CodeAgenda.Utility.Mappers;
using System.Drawing;

public class AutoMapperTests
{
    private readonly IMapper _mapper;

    public AutoMapperTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Should_Map_User_To_UserDTO()
    {
        // Arrange
        var user = new User("John", "Doe", "john.doe@example.com", Guid.NewGuid());

        // Act
        var userDTO = _mapper.Map<UserDTO>(user);

        // Assert
        Assert.Equal(user.Name, userDTO.Name);
        Assert.Equal(user.FirstName, userDTO.FirstName);
        Assert.Equal(user.Email, userDTO.Email);
        Assert.Equal(user.Id, userDTO.Id);
    }

    [Fact]
    public void Should_Map_Project_To_ProjectDTO()
    {
        // Arrange
        var project = new Project("Project1", "Description1", DateTime.Now, DateTime.Now.AddDays(30), new User("John", "Doe", "john.doe@example.com", Guid.NewGuid()), Guid.NewGuid());

        // Act
        var projectDTO = _mapper.Map<ProjectDTO>(project);

        // Assert
        Assert.Equal(project.Name, projectDTO.Name);
        Assert.Equal(project.Description, projectDTO.Description);
        Assert.Equal(project.StartDate, projectDTO.StartDate);
        Assert.Equal(project.EndDate, projectDTO.EndDate);
    }

    [Fact]
    public void Should_Map_Category_To_CategoryDTO()
    {
        // Arrange
        var category = new Category("Category1", new Color(), new Project("Project1", "Description1", DateTime.Now, DateTime.Now.AddDays(30), new User("John", "Doe", "john.doe@example.com", Guid.NewGuid()), Guid.NewGuid()), Guid.NewGuid());

        // Act
        var categoryDTO = _mapper.Map<CategoryDTO>(category);

        // Assert
        Assert.Equal(category.Name, categoryDTO.Name);
        Assert.Equal(category.Color, categoryDTO.Color);
        Assert.Equal(category.ProjectId, categoryDTO.ProjectId);
        Assert.Equal(category.Id, categoryDTO.Id);
    }
}
