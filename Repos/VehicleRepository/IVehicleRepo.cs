using AnasProject.DTOS;

namespace AnasProject.Repos.VehicleRepository
{
    public interface IVehicleRepo:IRepository<Vehicle>
    {
        public List<VehicleDtoGetAll> GetAllVehiclesData();
    }
}
