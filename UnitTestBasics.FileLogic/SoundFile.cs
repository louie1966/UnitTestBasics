namespace UnitTestBasics.FileLogic
{
    public class SoundFile
    {
        public User SavedBy { get; set; }

        public bool CanBeDeletedBy(User user)
        {
            if (user.IsSystemAdmin || user == SavedBy)
                return true;

            return false;
        }
    }
}
