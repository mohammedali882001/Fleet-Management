using AnasProject.DTOS;
using AnasProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AnasProject.Repos.VehicleRepository
{
    public class VehicleRepo:Repository<Vehicle> , IVehicleRepo
    {
        Context context;
        public VehicleRepo(Context _context) : base(_context)
        {
            context = _context;
        }

        public List<VehicleDtoGetAll> GetAllVehiclesData()
        {

            var vehiclesData = context.Vehicles
                .Select(v => new
                {
                    v.VehicleId,
                    v.VehicleNumber,
                    v.VehicleType,
                    LastRouteHistory = v.RouteHistories
                        .OrderByDescending(rh => rh.RouteHistoryId)
                        .FirstOrDefault()
                })
                .AsEnumerable()
                .Select(v => new VehicleDtoGetAll
                {
                    VehicleId = v.VehicleId,
                    VehicleNumber = v.VehicleNumber,
                    VehicleType = v.VehicleType,
                    LastDirection = v.LastRouteHistory?.VehicleDirection,
                    LastStatus = v.LastRouteHistory?.Status,
                    LastLatitude = v.LastRouteHistory?.Latitude,
                    LastLongitude = v.LastRouteHistory?.Longitude
                })
                .ToList();

            return vehiclesData;
        }



    }
}
