using AnasProject.Models;

namespace AnasProject.Repos.RectangularGeofenceReopsitory
{
    public class RectangularGeofenceRepo:Repository<RectangleGeofence> , IRectangularGeofenceRepo
    {
        Context context;
        public RectangularGeofenceRepo(Context _context) : base(_context)
        {
            context = _context;
        }

    }
}
