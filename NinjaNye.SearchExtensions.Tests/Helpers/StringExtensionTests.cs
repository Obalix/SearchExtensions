using NinjaNye.SearchExtensions.Helpers;
using NUnit.Framework;

namespace NinjaNye.SearchExtensions.Tests.Helpers
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void GetFirstCharacter_EmptyString_ReturnsNull()
        {
            //Arrange

            //Act
            var character = string.Empty.GetFirstCharacter();

            //Assert
            Assert.IsNull(character);
        }

        [Test]
        public void GetFirstCharacter_ValidString_ReturnedValueIsNotNull()
        {
            //Arrange
            string word = "test";

            //Act
            var character = word.GetFirstCharacter();

			//Assert
			Assert.That(character, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void GetFirstCharacter_ValidString_ReturnedValueIsFirstCharacterOnly()
        {
            //Arrange
            string word = "test";

            //Act
            var character = word.GetFirstCharacter();

            //Assert
            Assert.AreEqual(word[0].ToString(), character);
        }

        [Test]
        public void GetFirstCharacter_StringIsWhitespaceOnly_ReturnNull()
        {
            //Arrange
            string word = "   ";

            //Act
            var character = word.GetFirstCharacter();

            //Assert
            Assert.IsNull(character);
        }

        [Test]
        public void GetFirstCharacter_StringBeginsWithWhitespace_ReturnFirstNonWhitespaceCharacter()
        {
            //Arrange
            string word = " test";

            //Act
            var character = word.GetFirstCharacter();

            //Assert
            Assert.AreEqual("t", character);
        }
    }
}
