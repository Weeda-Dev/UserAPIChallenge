﻿using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using UsersAPI.Interfaces;
using UsersAPI.Tests.Utilities;
using UsersAPI.Services;

namespace UsersAPI.Tests.ServicesTests
{
    /// <summary>
    /// Test get users services
    /// </summary>
    [TestFixture]
    public class GetUsersServiceTests
    {
        [Test]
        public void WhenGetUserLists_ShouldReturnValidUsersList()
        {
            //Set up
            Mock<IJsonFileDataService> mockJsonHelper = GetMockJsonHelperSetUp();
            Mock<IFilePathService> mockFilePathService = GetMockFilePathServiceSetup();

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object, mockFilePathService.Object);
            var userList = gUserServ.GetUserLists();
            var expectedItemValidCount = userList.Count() == 7;

            var actualFirstPersonFirstName = userList.FirstOrDefault().FirstName;
            var expectedFirstPersonFirstName = "brad";

            //Assert
            Assert.True(expectedItemValidCount, "Item count does not match the expected count (7).");
            actualFirstPersonFirstName.ShouldBe(expectedFirstPersonFirstName, "First name of the first person " +
                $"on the list is not {expectedFirstPersonFirstName}.");
        }

        [Test]
        public void WhenGetUserListRootObject_ShouldReturnValidRootObjectList()
        {
            //Set up
            Mock<IJsonFileDataService> mockJsonHelper = GetMockJsonHelperSetUp();
            Mock<IFilePathService> mockFilePathService = GetMockFilePathServiceSetup();

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object, mockFilePathService.Object);
            AllUsersRootModel userListRootObject = gUserServ.GetUserListRootObject();
            bool expectedItemValidCount = userListRootObject.users.Count() == 7;

            IEnumerable<UserModel> allUsers = userListRootObject.users;
            string actualFirstPersonFirstName = allUsers.FirstOrDefault().FirstName;
            string expectedFirstPersonFirstName = "brad";

            //Assert
            Assert.True(expectedItemValidCount, "Item count does not match the expected count (7).");
            actualFirstPersonFirstName.ShouldBe(expectedFirstPersonFirstName, "First name of the first person " +
                $"on the list is not {expectedFirstPersonFirstName}.");
        }

        private static Mock<IFilePathService> GetMockFilePathServiceSetup()
        {
            var mockFilePathService = new Mock<IFilePathService>();
            mockFilePathService.Setup(x => x.GetUsersDataJsonFilePath()).Returns("");
            return mockFilePathService;
        }

        private static Mock<IJsonFileDataService> GetMockJsonHelperSetUp()
        {
            var mockJsonHelper = new Mock<IJsonFileDataService>();
            var fakejson = FakeJsonHelper.GetFakeValidUserDataJson();
            mockJsonHelper.Setup(x => x.GetDataStringFromJsonFile(""))
                .Returns(fakejson);
            return mockJsonHelper;
        }
    }
}