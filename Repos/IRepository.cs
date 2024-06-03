namespace AnasProject.Repos
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(long id);
        public void Insert(T obj);
        public void Update(T obj);
        public void Delete(long id);
        public void Save();
    }
}