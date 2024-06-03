using AnasProject.DTOS;

namespace AnasProject.Repos.RouteHistoryRepository
{
    public interface IRouteHistoryRepo :IRepository<RouteHistory>
    {
        public List<RouteHistoryForGetAllDTO> GetRouteHistoryPlayback(long vehicleId, long startEpoch, long endEpoch);
    }
}
