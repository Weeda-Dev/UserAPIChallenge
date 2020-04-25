using NUnit.Framework;
using Shouldly;
using UsersAPI.Services;

namespace UsersAPI.Tests.ServicesTests
{
    /// <summary>
    /// Test getting valid input service
    /// </summary>
    [TestFixture]
    public class GetValidInputServiceTests
    {
        [Test]
        public void GivenNullFirstNameAndLastName_WhenTurnNullToEmptyString_ShouldReturnEmptyString()
        {
            //Setup
            string firstName = null;
            string lastName = null;

            //Act
            GetValidInputService vS = new GetValidInputService();
            vS.TurnNullToEmptyString(ref firstName, ref lastName);

            //Assert
            firstName.ShouldBe("");
            lastName.ShouldBe("");
            firstName.ShouldNotBeNull();
            lastName.ShouldNotBeNull();
        }

        [Test]
        public void GivenValidFirstNameAndLastName_WhenTurnNullToEmptyString_ShouldReturnValidFirstNameandLastName()
        {
            //Setup
            var firstName = "John";
            var lastName = "Smith";

            //Act
            GetValidInputService vS = new GetValidInputService();
            vS.TurnNullToEmptyString(ref firstName, ref lastName);

            //Assert
            firstName.ShouldBe("John");
            lastName.ShouldBe("Smith");
            firstName.ShouldNotBe("");
            lastName.ShouldNotBe("");
        }

        [Test]
        public void GivenValidFirstNameAndNullLastName_WhenTurnNullToEmptyString_ShouldReturnFirstNameAndLastNameAsEmptyString()
        {
            //Setup
            string firstName = "John";
            string lastName = null;

            //Act
            GetValidInputService vS = new GetValidInputService();
            vS.TurnNullToEmptyString(ref firstName, ref lastName);

            //Assert
            firstName.ShouldBe("John");
            firstName.ShouldNotBe("");
            lastName.ShouldBe("");
            lastName.ShouldNotBe(null);
        }

        [Test]
        public void GivenNullFirstNameAndValidLastName_WhenTurnNullToEmptyString_ShouldReturnFirstNameAsEmptyStringAndLastName()
        {
            //Setup
            string firstName = null;
            string lastName = "Smith";

            //Act
            GetValidInputService vS = new GetValidInputService();
            vS.TurnNullToEmptyString(ref firstName, ref lastName);

            //Assert
            firstName.ShouldBe("");
            firstName.ShouldNotBe(null);
            lastName.ShouldBe("Smith");
            lastName.ShouldNotBe("");
        }
    }
}