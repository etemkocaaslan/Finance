namespace Finance.Helper
{
    public abstract class Manager<T>
    {
        protected List<T> Items;

        protected Manager()
        {
            Items = [];
        }

        public abstract void Add(T item);
        public abstract void Update(int id, T updatedItem);
        public abstract void Delete(int id);
        public abstract void Display();
    }

}
