using AnasProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AnasProject.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context;
        public Repository(Context _context)
        {
            context = _context;
        }
        public void Delete(long id)
        {
            T t = GetById(id);
           
            Update(t);
        }


        public virtual List<T> GetAll()
        {

            return context.Set<T>().ToList();

        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }


        public void Insert(T obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Update(obj);
        }
    }
}
