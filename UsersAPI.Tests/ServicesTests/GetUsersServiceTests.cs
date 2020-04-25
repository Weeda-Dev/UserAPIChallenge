using Moq;
using NUnit.Framework;
using Shouldly;
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
        public void WhenGetUserListRootObject_ShouldReturnValidRootObjectList()
        {
            //Set up
            var mockJsonHelper = new Mock<IGetJsonFileDataService>();
            var fakejson = FakeJsonHelper.GetFakeValidUserDataJson();
            mockJsonHelper.Setup(x => x.GetUsersDataFromJsonFile())
                .Returns(fakejson);

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object);
            var userListRootObject = gUserServ.GetUserListRootObject();
            var expectedItemValidCount = userListRootObject.users.Count() == 7;

            var allUsers = userListRootObject.users;
            var actualFirstPersonFirstName = allUsers.FirstOrDefault().FirstName;
            var expectedFirstPersonFirstName = "brad";

            //Assert
            Assert.True(expectedItemValidCount, "Item count does not match the expected count (7).");
            actualFirstPersonFirstName.ShouldBe(expectedFirstPersonFirstName, "First name of the first person " +
                $"on the list is not {expectedFirstPersonFirstName}.");
        }
    }
}