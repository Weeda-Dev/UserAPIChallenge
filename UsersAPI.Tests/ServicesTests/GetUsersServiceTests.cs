using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersAPI.Interfaces;
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
            var fakejson = GetFakeValidUserDataJson();
            mockJsonHelper.Setup(x => x.GetUsersDataFromJsonFile())
                .Returns(fakejson);

            //Act
            GetUsersService gUserServ = new GetUsersService(mockJsonHelper.Object);
            var userListRootObject = gUserServ.GetUserListRootObject();
            var expectedItemValidCount = userListRootObject.users.Count() == 2;

            var allUsers = userListRootObject.users;
            var actualFirstPersonFirstName = allUsers.FirstOrDefault().FirstName;
            var expectedFirstPersonFirstName = "brad";

            //Assert
            Assert.True(expectedItemValidCount);
            actualFirstPersonFirstName.ShouldBe(expectedFirstPersonFirstName);
        }

        public string GetFakeValidUserDataJson()
        {
            return @"
{
'users':[
{
      'Id': 0,
      'Title': 'mr',
      'FirstName': 'brad',
      'LastName': 'gibson',
      'Email': 'brad.gibson@example.com',
      'Birthday': '1993-07-20',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    },
{
      'Id': 1,
      'Title': 'mrs',
      'FirstName': 'gomel',
      'LastName': 'tun',
      'Email': 'gomel.tun@example.com',
      'Birthday': '1995-09-10',
      'MobileNumber': '011-962-7516',
      'ProfileImageLarge': 'https://randomuser.me/api/portraits/men/75.jpg',
      'ProfileImageThumbnail': 'https://randomuser.me/api/portraits/med/men/75.jpg'
    }
]}";
        }
    }
}