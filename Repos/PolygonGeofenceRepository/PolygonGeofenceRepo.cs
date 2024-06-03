using AnasProject.Models;

namespace AnasProject.Repos.PolygonGeofenceRepository
{
    public class PolygonGeofenceRepo:Repository<PolygonGeofence> , IPolygonGeofenceRepo
    {
        Context context;
        public PolygonGeofenceRepo(Context _context) : base(_context)
        {
            context = _context;
        }
    }
}
