using AutoMapper;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Users;
using CodeAgenda.Web.Mappers;

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

    // Agrega más pruebas para las otras entidades y DTOs.
}
