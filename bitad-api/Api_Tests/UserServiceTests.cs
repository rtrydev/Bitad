using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BitadAPI.Dto;
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
            
            users.Add(new User()
            {
                Id = 0,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 100
            });
            users.Add(new User()
            {
                Id = 1,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 10
            });
            users.Add(new User()
            {
                Id = 2,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 40
            });
            users.Add(new User()
            {
                Id = 3,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 10
            });
            users.Add(new User()
            {
                Id = 4,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 800
            });

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
        
        [Fact]
        public async Task GetWinners_WithZeroPointsUsers_ReturnsICollection()
        {
            //Arrange
            
            var users = new List<User>();
            
            users.Add(new User()
            {
                Id = 0,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 0
            });
            users.Add(new User()
            {
                Id = 1,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 0
            });
            users.Add(new User()
            {
                Id = 2,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 0
            });
            users.Add(new User()
            {
                Id = 3,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 0
            });
            users.Add(new User()
            {
                Id = 4,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 0
            });

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
        
        [Fact]
        public async Task GetWinners_WithAdminWithMostPoints_ReturnsICollectionWithoutAdmin()
        {
            //Arrange
            
            var users = new List<User>();
            
            users.Add(new User()
            {
                Id = 0,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 100
            });
            users.Add(new User()
            {
                Id = 1,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 10
            });
            users.Add(new User()
            {
                Id = 2,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 40
            });
            users.Add(new User()
            {
                Id = 3,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 10
            });
            var admin = new User()
            {
                Id = 5,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 800,
                Role = UserRole.Admin
            };
            users.Add(admin);
            var super = new User()
            {
                Id = 5,
                AttendanceCheckDate = DateTime.Now,
                CurrentScore = 800,
                Role = UserRole.Super
            };
            users.Add(super);

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
            
            result.Value.Contains(_mapper.Map<DtoUser>(admin)).Should().BeFalse();
            result.Value.Contains(_mapper.Map<DtoUser>(super)).Should().BeFalse();
        }
    }
}