using AnasProject.DTOS;

namespace AnasProject.Repos.VehicleInformationRepository
{
    public interface IVehicleInformationRepo:IRepository<VehiclesInformation>
    {
        public VehiclesInformationForGetAllDTO GetVehicleInformationData(long vehicleId);
    }
}
