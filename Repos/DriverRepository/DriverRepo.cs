using AnasProject.Models;

namespace AnasProject.Repos.DriverRepository
{
    public class DriverRepo : Repository<Driver>, IDriverRepo
    {
        Context context;
        public DriverRepo(Context _context) : base(_context)
        {
            context = _context;
        }



    }
}
