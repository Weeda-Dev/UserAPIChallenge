using NUnit.Framework;
using Shouldly;
using UsersAPI.Utilities;

namespace UsersAPI.Tests.ServicesTests
{
    [TestFixture]
    public class GetIdServiceTests
    {
        [TestCase(34,35)]
        [TestCase(1,2)]
        [TestCase(1845854,1845855)]
        [TestCase(98563253,98563254)]
        public void GivenLastIdOnUsersList_WhenGetNewUserIdIsCalled_ShouldReturnCorrectNewUserId(int lastIdOnUsersList, int expectedNewUserId)
        {
            GetIdService getIdServ = new GetIdService();
            var result = getIdServ.GetNewUserId(lastIdOnUsersList);

            result.ShouldBe(expectedNewUserId);
        }
    }
}