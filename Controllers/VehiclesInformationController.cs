using AnasProject.DTOS;
using AnasProject.Repos.VehicleInformationRepository;
using AnasProject.Repos.VehicleRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;
using System.Globalization;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesInformationController : ControllerBase
    {
        private readonly IVehicleInformationRepo vehicleInformationRepo;

        public VehiclesInformationController(IVehicleInformationRepo vehicleInformationRepo)
        {
            this.vehicleInformationRepo = vehicleInformationRepo;
        }

        [HttpPost("add")]
        public IActionResult AddVechileInformation([FromBody] VehiclesInformationDTO vehiclesInformationDTO)
        {
            if (ModelState.IsValid)
            {
                var purchaseDateUnix = FormattedStringToUnixTimeStamp(vehiclesInformationDTO.PurchaseDate.ToString());

                VehiclesInformation vehiclesInformation = new VehiclesInformation()
                {
                    DriverId = vehiclesInformationDTO.DriverId,
                    VehicleId = vehiclesInformationDTO.VehicleId,
                    VehicleMake = vehiclesInformationDTO.VehicleMake,
                    PurchaseDate = purchaseDateUnix.ToString(),
                    VehicleModel = vehiclesInformationDTO.VehicleModel
                };

                vehicleInformationRepo.Insert(vehiclesInformation);
                vehicleInformationRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = UnixTimeStampToFormattedString(long.Parse(vehiclesInformation.PurchaseDate)),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
                };

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Vehicle");
        }

        [HttpPut("update")]
        public IActionResult UpdateVechileInformation(int vehicleInformationId, [FromBody] VehiclesInformationDTO vehiclesInformationDTO)
        {
            if (ModelState.IsValid)
            {
                VehiclesInformation vehiclesInformation = vehicleInformationRepo.GetById(vehicleInformationId);

                if (vehiclesInformation == null)
                {
                    return NotFound("Vehicle information not found.");
                }

                vehiclesInformation.VehicleId = vehiclesInformationDTO.VehicleId;
                vehiclesInformation.DriverId = vehiclesInformationDTO.DriverId;
                vehiclesInformation.VehicleMake = vehiclesInformationDTO.VehicleMake;
                vehiclesInformation.VehicleModel = vehiclesInformationDTO.VehicleModel;
                vehiclesInformation.PurchaseDate = FormattedStringToUnixTimeStamp(vehiclesInformationDTO.PurchaseDate).ToString();

                vehicleInformationRepo.Update(vehiclesInformation);
                vehicleInformationRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = UnixTimeStampToFormattedString(long.Parse(vehiclesInformation.PurchaseDate)),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
                };

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Updating This Vehicle");
        }

        [HttpDelete("delete")]
        public IActionResult DeleteInformation(long vehicleInformationId)
        {
            if (ModelState.IsValid)
            {
                VehiclesInformation vehiclesInformation = vehicleInformationRepo.GetById(vehicleInformationId);

                if (vehiclesInformation == null)
                {
                    return NotFound("Vehicle information not found.");
                }

                vehiclesInformation.IsDeleted = true;
                vehicleInformationRepo.Update(vehiclesInformation);
                vehicleInformationRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverId"] = vehiclesInformation.DriverId.ToString(),
                    ["VehicleId"] = vehiclesInformation.VehicleId.ToString(),
                    ["VehicleMake"] = vehiclesInformation.VehicleMake,
                    ["PurchaseDate"] = UnixTimeStampToFormattedString(long.Parse(vehiclesInformation.PurchaseDate)),
                    ["VehicleModel"] = vehiclesInformation.VehicleModel
                };

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Deleting This Vehicle");
        }

        [HttpGet("vehicleInformation/{vehicleId}")]
        public IActionResult GetVehicleInformation(long vehicleId)
        {
            var vehicleDataInformation = vehicleInformationRepo.GetVehicleInformationData(vehicleId);

            if (vehicleDataInformation == null)
            {
                return NotFound("Vehicle information not found.");
            }

            var dataTable = new DataTable("VehicleInformation");
            dataTable.Columns.Add("VehicleNumber", typeof(long));
            dataTable.Columns.Add("VehicleType", typeof(string));
            dataTable.Columns.Add("DriverName", typeof(string));
            dataTable.Columns.Add("LastLatitude", typeof(double));
            dataTable.Columns.Add("LastLongitude", typeof(double));
            dataTable.Columns.Add("VehicleMake", typeof(string));
            dataTable.Columns.Add("VehicleModel", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));

            dataTable.Rows.Add(
                vehicleDataInformation.VehicleNumber,
                vehicleDataInformation.VehicleType,
                vehicleDataInformation.DriverName,
                vehicleDataInformation.LastLatitude,
                vehicleDataInformation.LastLongitude,
                vehicleDataInformation.VehicleMake,
                vehicleDataInformation.VehicleModel,
                vehicleDataInformation.PhoneNumber);

            var gvar = new GVAR();
            gvar.AddDataTable("VehicleInformation", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

        private string UnixTimeStampToFormattedString(long unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            dateTimeOffset = dateTimeOffset.ToOffset(TimeSpan.FromHours(3)); // Adjust the time zone if necessary
            return dateTimeOffset.ToString("dddd, MMMM d, yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }

        private long FormattedStringToUnixTimeStamp(string formattedString)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(
                formattedString,
                "dddd, MMMM d, yyyy h:mm:ss tt",
                CultureInfo.InvariantCulture);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
