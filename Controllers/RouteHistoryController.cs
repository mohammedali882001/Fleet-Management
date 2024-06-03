using AnasProject.DTOS;
using AnasProject.Repos.RouteHistoryRepository;
using AnasProject.Repos.VehicleRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteHistoryController : ControllerBase
    {

        private readonly IRouteHistoryRepo routeHistoryRepo;

        public RouteHistoryController(IRouteHistoryRepo routeHistoryRepo)
        {
            this.routeHistoryRepo = routeHistoryRepo;
        }

        [HttpPost("add")]
        public IActionResult AddVechileRouteHistory([FromBody] RouteHistoryDTO routeHistoryDTO)
        {
            if (ModelState.IsValid)
            {
                RouteHistory routeHistory = new RouteHistory()
                {
                    VehicleSpeed = routeHistoryDTO.VehicleSpeed,
                    Status = routeHistoryDTO.Status,
                    Epoch = routeHistoryDTO.Epoch,
                    VehicleDirection = routeHistoryDTO.VehicleDirection,
                    Longitude = routeHistoryDTO.Longitude,
                    Latitude = routeHistoryDTO.Latitude,
                    VehicleId = routeHistoryDTO.VehicleId

                };
                // Add the driver to the database
                routeHistoryRepo.Insert(routeHistory);
                routeHistoryRepo.Save();

                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["VehicleId"] = routeHistory.VehicleId.ToString(),
                    ["VehicleSpeed"] = routeHistory.VehicleSpeed.ToString(),
                    ["Status"] = routeHistory.Status.ToString(),
                    ["Epoch"] = routeHistory.Epoch.ToString(),
                    ["VehicleDirection"] = routeHistory.VehicleDirection.ToString(),
                    ["Longitude"] = routeHistory.Longitude.ToString(),
                    ["Latitude"] = routeHistory.Latitude.ToString(),

                };

                // Wrap the GVAR object into a response structure
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");

        }


        [HttpGet("playback")]
        public IActionResult GetRouteHistoryPlayback(long vehicleId, long startEpoch, long endEpoch)
        {
            if (ModelState.IsValid)
            {
                var routeHistoryData = routeHistoryRepo.GetRouteHistoryPlayback(vehicleId, startEpoch, endEpoch);

                var dataTable = new DataTable("RouteHistory");
                dataTable.Columns.Add("VehicleID", typeof(long));
                dataTable.Columns.Add("VehicleNumber", typeof(string));
                dataTable.Columns.Add("Status", typeof(char));
                dataTable.Columns.Add("Latitude", typeof(float));
                dataTable.Columns.Add("Longitude", typeof(float));
                dataTable.Columns.Add("VehicleDirection", typeof(int));
              

                foreach (var data in routeHistoryData)
                {
                    dataTable.Rows.Add(data.VehicleId, data.VehicleNumber, data.Status, data.LastLatitude, data.LastLongitude, data.VehicleDirection);
                }

                var gvar = new GVAR();
                gvar.AddDataTable("RouteHistory", dataTable);

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Fetching Route History");
        }
    }
}
