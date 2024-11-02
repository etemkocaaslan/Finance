namespace Finance.Helper
{
    public abstract class Storage<T>(string filePath)
    {
        protected string FilePath = filePath;
        public abstract List<T> Load();
        public abstract void Save(List<T> items);
    }
}