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

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeDeletedBy_UsersOwnFile_ReturnsTrue()
        {
            var user = new User();
            var soundFile = new SoundFile { SavedBy = user };

            var result = soundFile.CanBeDeletedBy(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeDeletedBy_NotUsersOwnFile_ReturnsFals()
        {
            var user = new User();
            var soundFile = new SoundFile { SavedBy = user };

            var result = soundFile.CanBeDeletedBy(new User());

            Assert.IsFalse(result);
        }
    }
}
