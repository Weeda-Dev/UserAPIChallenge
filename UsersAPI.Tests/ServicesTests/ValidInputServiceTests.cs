using NUnit.Framework;
using Shouldly;
using UsersAPI.Utilities;

namespace UsersAPI.Tests.ServicesTests
{
    [TestFixture]
    public class ValidInputServiceTests
    {
        [Test]
        public void GivenNullFirstNameAndLastName_WhenTurnNullToEmptyString_ShouldReturnEmptyString()
        {
            //Setup
            string firstName = null;
            string lastName = null;

            //Act
            ValidInputService vS = new ValidInputService();
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
            ValidInputService vS = new ValidInputService();
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
            ValidInputService vS = new ValidInputService();
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
            ValidInputService vS = new ValidInputService();
            vS.TurnNullToEmptyString(ref firstName, ref lastName);

            //Assert
            firstName.ShouldBe("");
            firstName.ShouldNotBe(null);
            lastName.ShouldBe("Smith");
            lastName.ShouldNotBe("");
        }
    }
}