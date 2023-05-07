using AutoMapper;
using FluentAssertions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Service.DTO;
using Manager.Service.Interfaces;
using Manager.Service.Services;
using Manager.Tests.Configuration;
using Manager.Tests.Fixtures;
using Moq;

namespace Manager.Tests.Projects.Services
{
    public class UserServiceTest
    {

        // Subject Under Test
        private readonly IUserService _sut;

        // Mocks
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepoMock;

        public UserServiceTest()
        {
            _mapper = AutoMapperConfig.GetConfiguration();
            _userRepoMock = new Mock<IUserRepository>();

            _sut = new UserService(
                    mapper: _mapper,
                    userRepository: _userRepoMock.Object);
        }

        [Fact(DisplayName = "Create Valid User")]
        public async Task Create_WhenUserIsValid_ReturnsUserDTO()
        {
            var user = UserFixture.createValidUserDTO("Matheus Wiener", "matheus@gmail.com", "123456");
            var userCreated = _mapper.Map<User>(user);

            _userRepoMock.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            _userRepoMock.Setup(x => x.Create(It.IsAny<User>()))
                .ReturnsAsync(() => userCreated);


            var result = await _sut.Create(user);

            result.Should().BeEquivalentTo(_mapper.Map<UserDTO>(userCreated));
        }

    }
}
