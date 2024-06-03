using AnasProject.DTOS;
using AnasProject.Models;
using AnasProject.Repos.GeofenceRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Repos.CircularGeofenceRepository
{
    public class CircularGeofenceRepo:Repository<CircleGeofence> , ICircularGeofenceRepo
    {
        Context context;
        public CircularGeofenceRepo(Context _context) : base(_context)
        {
            context = _context;
        }


       

    }
}
