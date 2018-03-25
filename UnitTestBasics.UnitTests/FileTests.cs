using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBasics.FileLogic;

namespace UnitTestBasics.UnitTests
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void CanBeDeletedBy_UserIsSystemAdmin_ReturnsTrue()
        {
            // Arrange
            var file = new SoundFile();

            // Act
            var result = file.CanBeDeletedBy(new User { IsSystemAdmin = true });

            // Assert standard and FluentAssertions
            Assert.IsTrue(result);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void CanBeDeletedBy_UsersOwnFile_ReturnsTrue()
        {
            var user = new User();
            var soundFile = new SoundFile { SavedBy = user };

            var result = soundFile.CanBeDeletedBy(user);

            Assert.IsTrue(result);
            result.Should().BeTrue();
        }

        [TestMethod]
        public void CanBeDeletedBy_NotUsersOwnFile_ReturnsFals()
        {
            var user = new User();
            var soundFile = new SoundFile { SavedBy = user };

            var result = soundFile.CanBeDeletedBy(new User());

            Assert.IsFalse(result);
            result.Should().BeFalse();
        }
    }
}
