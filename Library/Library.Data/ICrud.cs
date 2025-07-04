namespace Library.Data
{
    public interface ICrud<T>
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public int Add(T obj);
        public int Update(T obj);
        public int Delete(int id);
    }
}
