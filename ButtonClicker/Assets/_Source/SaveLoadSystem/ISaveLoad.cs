namespace SaveLoadSystem
{
    public interface ISaveLoad
    {
        bool CheckFile();
        void Save();
        void Load();
    }
}