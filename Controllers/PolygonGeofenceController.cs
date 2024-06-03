using AnasProject.DTOS;
using AnasProject.Repos.PolygonGeofenceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonGeofenceController : ControllerBase
    {
        private readonly IPolygonGeofenceRepo polygonGeofenceRepo;

        public PolygonGeofenceController(IPolygonGeofenceRepo polygonGeofenceRepo)
        {
            this.polygonGeofenceRepo = polygonGeofenceRepo;
        }

        [HttpGet("polygon")]
        public IActionResult GetPolygonGeofences()
        {
            var polygonGeofences = polygonGeofenceRepo.GetAll();
            var dataTable = new DataTable("PolygonGeofences");

            dataTable.Columns.Add("Id", typeof(long));
            dataTable.Columns.Add("Longitude", typeof(double));
            dataTable.Columns.Add("Latitude", typeof(double));
            dataTable.Columns.Add("AddedDate", typeof(string));
            dataTable.Columns.Add("GeofenceType", typeof(string));
            dataTable.Columns.Add("FillColor", typeof(string));
            dataTable.Columns.Add("StrockOpacity", typeof(double));
            dataTable.Columns.Add("StrockWeight", typeof(double));
            dataTable.Columns.Add("StrockColor", typeof(string));
            dataTable.Columns.Add("FillOpacity", typeof(double));

            foreach (var geofence in polygonGeofences)
            {
                dataTable.Rows.Add(
                    geofence.Id,
                    geofence.Longitude,
                    geofence.Latitude,
                    UnixTimeStampToFormattedString(long.Parse(geofence.AddedDate)),
                    geofence.GeofenceType,
                    geofence.FillColor,
                    geofence.StrockOpacity,
                    geofence.StrockWeight,
                    geofence.StrockColor,
                    geofence.FillOpacity
                );
            }

            var gvar = new GVAR();
            gvar.AddDataTable("PolygonGeofences", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

        [HttpPost("polygon/add")]
        public IActionResult AddPolygonGeofence([FromBody] PolygonGeofenceDTO polygonGeofenceDTO)
        {
            if (ModelState.IsValid)
            {
                var polygonGeofence = new PolygonGeofence
                {
                    Longitude = polygonGeofenceDTO.Longitude,
                    Latitude = polygonGeofenceDTO.Latitude,
                    AddedDate = FormattedStringToUnixTimeStamp(polygonGeofenceDTO.AddedDate).ToString(),
                    FillColor = polygonGeofenceDTO.FillColor,
                    FillOpacity = polygonGeofenceDTO.FillOpacity,
                    GeofenceType = polygonGeofenceDTO.GeofenceType,
                    StrockColor = polygonGeofenceDTO.StrockColor,
                    StrockOpacity = polygonGeofenceDTO.StrockOpacity,
                    StrockWeight = polygonGeofenceDTO.StrockWeight
                };

                polygonGeofenceRepo.Insert(polygonGeofence);
                polygonGeofenceRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["Id"] = polygonGeofence.Id.ToString(),
                    ["Longitude"] = polygonGeofence.Longitude.ToString(),
                    ["Latitude"] = polygonGeofence.Latitude.ToString(),
                    ["AddedDate"] = UnixTimeStampToFormattedString(long.Parse(polygonGeofence.AddedDate)),
                    ["FillColor"] = polygonGeofence.FillColor,
                    ["FillOpacity"] = polygonGeofence.FillOpacity.ToString(),
                    ["GeofenceType"] = polygonGeofence.GeofenceType,
                    ["StrockColor"] = polygonGeofence.StrockColor,
                    ["StrockOpacity"] = polygonGeofence.StrockOpacity.ToString(),
                    ["StrockWeight"] = polygonGeofence.StrockWeight.ToString()
                };

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Geofence");
        }

        private string UnixTimeStampToFormattedString(long unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            // Adjust the time zone if necessary, e.g., to GMT+03:00 DST
            dateTimeOffset = dateTimeOffset.ToOffset(TimeSpan.FromHours(3));
            return dateTimeOffset.ToString("dddd, MMMM d, yyyy h:mm:ss tt");
        }

        private long FormattedStringToUnixTimeStamp(string formattedString)
        {
            // Assuming the input format is "Thursday, May 30, 2024 11:10:15 AM"
            DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(
                formattedString,
                "dddd, MMMM d, yyyy h:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
