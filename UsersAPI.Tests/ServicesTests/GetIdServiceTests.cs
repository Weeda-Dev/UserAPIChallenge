using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using UsersAPI.Utilities;

namespace UsersAPI.Tests.ServicesTests
{
    [TestFixture]
    public class GetIdServiceTests
    {
        [TestCase(34)]
        [TestCase(1)]
        [TestCase(1845854)]
        [TestCase(98563253)]
        public void GivenValidUserModel_WhenGetNewUserIdIsCalled_TheShouldReturnCorrectNewUserId(int lastIdOnUsersList)
        {
            GetIdService getIdServ = new GetIdService();

            var expectedResult = lastIdOnUsersList + 1;
            var result = getIdServ.GetNewUserId(lastIdOnUsersList);

            result.ShouldBe(expectedResult);
            result.ShouldNotBe(lastIdOnUsersList);
        }
    }
}