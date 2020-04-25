using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using UsersAPI.Interfaces;
using UsersAPI.Tests.Utilities;
using UsersAPI.Utilities;

namespace UsersAPI.Tests.ServicesTests
{
    [TestFixture]
    public class GetUsersServiceTests
    {
        [Test]
        public void WhenGetUserLists_ShouldReturnValidUsersList()
        {
            //Set up
            Mock<IGetJsonFileDataService> mockJsonHelper = GetMockJsonHelperSetUp();

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object);
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
            Mock<IGetJsonFileDataService> mockJsonHelper = GetMockJsonHelperSetUp();

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object);
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
        private static Mock<IGetJsonFileDataService> GetMockJsonHelperSetUp()
        {
            var mockJsonHelper = new Mock<IGetJsonFileDataService>();
            var fakejson = FakeJsonHelper.GetFakeValidUserDataJson();
            mockJsonHelper.Setup(x => x.GetUsersDataFromJsonFile())
                .Returns(fakejson);
            return mockJsonHelper;
        }
    }
}