using System;
using System.Threading.Tasks;
using EmployerPortal.Application.Services;
using EmployerPortal.Application.Services.Interfaces;
using EmployerPortal.Domain.Entities;
using EmployerPortal.Domain.Errors;
using EmployerPortal.Domain.Interfaces;
using Moq;
using Xunit;

namespace EmployerPortal.UnitTests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IUserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task WelcomeUserAsync_WithValidUsername_ReturnsWelcomeMessage()
    {
        // Arrange
        var username = "john.doe";
        var user = new User(username, "John Doe");
        _userRepositoryMock.Setup(x => x.GetByUsernameAsync(username))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.WelcomeUserAsync(username);

        // Assert
        Assert.Equal($"Hello, {user.Name}", result);
    }

    [Fact]
    public async Task WelcomeUserAsync_WithInvalidUsername_ThrowsNotFoundException()
    {
        // Arrange
        var username = "nonexistent";
        _userRepositoryMock.Setup(x => x.GetByUsernameAsync(username))
            .ReturnsAsync((User)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundError>(() =>
            _userService.WelcomeUserAsync(username));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task WelcomeUserAsync_WithEmptyUsername_ThrowsArgumentException(string username)
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            _userService.WelcomeUserAsync(username));
    }
}