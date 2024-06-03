using AnasProject.DTOS;
using AnasProject.Models;

namespace AnasProject.Repos.RouteHistoryRepository
{
    public class RouteHistoryRepo:Repository<RouteHistory> , IRouteHistoryRepo
    {
        Context context;
        public RouteHistoryRepo(Context _context) : base(_context)
        {
            context = _context;
        }

        public List<RouteHistoryForGetAllDTO> GetRouteHistoryPlayback(long vehicleId, long startEpoch, long endEpoch)
        {
            return context.RouteHistories
                .Where(rh => rh.VehicleId == vehicleId && rh.Epoch >= startEpoch && rh.Epoch <= endEpoch)
                .Select(rh => new RouteHistoryForGetAllDTO
                {
                    VehicleId = rh.VehicleId,
                    VehicleNumber = rh.Vehicle.VehicleNumber,
                    Status = rh.Status,
                    LastLatitude = rh.Latitude,
                    LastLongitude = rh.Longitude,
                    VehicleDirection = rh.VehicleDirection,
                  
                })
                .ToList();
        }


    }
}
