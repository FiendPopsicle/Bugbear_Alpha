namespace Bugbear.Managers
{
    public interface ISaveManager
    {
        public bool CheckSaveData();
        public SaveSystem GetSaveSystem();
    }
}