namespace UnitTestBasics.FileLogic
{
    public class SoundFile
    {
        public User SavedBy { get; set; }

        public bool CanBeDeletedBy(User user)
        {
            return (user.IsSystemAdmin || user == SavedBy);
        }
    }
}
