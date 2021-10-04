using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Models;
using BitadAPI.Profiles;
using BitadAPI.Repositories;
using BitadAPI.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace Api_Tests
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryStub = new();
        private Mock<IWorkshopRepository> _workshopRepository = new();
        private Mock<IJwtService> _jwtService = new();
        private Mock<IMailService> _mailService = new();
        private readonly IMapper _mapper =
            new Mapper(new MapperConfiguration(config => config.AddProfile(new UserProfile())));
        
        [Fact]
        public async Task GetWinners_WithValidUsers_ReturnsICollection()
        {
            //Arrange
            var users = new List<User>();

            _userRepositoryStub.Setup(repository => repository.GetAll()).ReturnsAsync(users);

            var userService = new UserService(
                _userRepositoryStub.Object,
                _workshopRepository.Object,
                _mapper,
                _jwtService.Object,
                _mailService.Object);

            var numberOfWinners = 3;

            //Act

            var result = await userService.GetWinners(numberOfWinners);

            //Assert

            result.Value.Should().NotBeNull();
            result.Value.Count.Should().Be(numberOfWinners);
        }
    }
}