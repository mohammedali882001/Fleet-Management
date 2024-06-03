using AnasProject.DTOS;
using AnasProject.Models;
using System.Collections.Concurrent;

namespace AnasProject.Repos.GeofenceRepository
{
    public class GeofenceRepo : Repository<Geofence>, IGeofenceRepo
    {
        Context context;
        public GeofenceRepo(Context _context) : base(_context)
        {
            context = _context;
        }












    }
     
      
}
