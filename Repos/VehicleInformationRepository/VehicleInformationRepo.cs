using AnasProject.DTOS;
using AnasProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AnasProject.Repos.VehicleInformationRepository
{
    public class VehicleInformationRepo:Repository<VehiclesInformation>,IVehicleInformationRepo
    {
        Context context;
        public VehicleInformationRepo(Context _context) : base(_context)
        {
            context = _context;
        }

        public VehiclesInformationForGetAllDTO GetVehicleInformationData(long vehicleId)
        {
            var vehicleInformationData = context.VehiclesInformations
                .Where(v => v.VehicleId == vehicleId)
                .Select(v => new
                {
                    v.VehicleId,
                    v.Id,
                    v.VehicleMake,
                    v.PurchaseDate,
                    v.DriverId,
                    v.VehicleModel,
                    v.Vehicle,
                    v.Driver,
                    LastRouteHistory = v.Vehicle.RouteHistories
                        .OrderByDescending(rh => rh.RouteHistoryId)
                        .FirstOrDefault()
                })
                .AsEnumerable()
                .Select(v => new VehiclesInformationForGetAllDTO
                {
                    VehicleNumber = v.Vehicle?.VehicleNumber,
                    DriverName = v.Driver?.DriverName,
                    LastLongitude = v.LastRouteHistory?.Longitude,
                    VehicleMake = v.VehicleMake,
                    VehicleModel = v.VehicleModel,
                    PhoneNumber = v.Driver?.PhoneNumber,
                    VehicleType = v.Vehicle?.VehicleType,
                    LastLatitude = v.LastRouteHistory?.Latitude,
                })
                .FirstOrDefault();

            return vehicleInformationData;
        }


    }
        }
