using AnasProject.DTOS;
using AnasProject.Repos.CircularGeofenceRepository;
using AnasProject.Repos.GeofenceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircularGeofenceController : ControllerBase
    {
        private readonly ICircularGeofenceRepo circularGeofenceRepo;
        public CircularGeofenceController(ICircularGeofenceRepo circularGeofenceRepo)
        {
            this.circularGeofenceRepo = circularGeofenceRepo;
        }

        [HttpGet("circular")]
        public IActionResult GetCircularGeofences()
        {
            var circularGeofences = circularGeofenceRepo.GetAll();
            var dataTable = new DataTable("CircleGeofences");
            dataTable.Columns.Add("Id", typeof(long));
            dataTable.Columns.Add("Radius", typeof(long));
            dataTable.Columns.Add("Latitude", typeof(double));
            dataTable.Columns.Add("Longitude", typeof(double));
            dataTable.Columns.Add("AddedDate", typeof(string));
            dataTable.Columns.Add("GeofenceType", typeof(string));
            dataTable.Columns.Add("FillColor", typeof(string));
            dataTable.Columns.Add("FillOpacity", typeof(double));
            dataTable.Columns.Add("StrockColor", typeof(string));
            dataTable.Columns.Add("StrockOpacity", typeof(double));
            dataTable.Columns.Add("StrockWeight", typeof(double));

            foreach (var geofence in circularGeofences)
            {
                dataTable.Rows.Add(
                    geofence.Id,
                    geofence.Radius,
                    geofence.Latitude,
                    geofence.Longitude,
                    UnixTimeStampToFormattedString(long.Parse(geofence.AddedDate)),
                    geofence.GeofenceType,
                    geofence.FillColor,
                    geofence.FillOpacity,
                    geofence.StrockColor,
                    geofence.StrockOpacity,
                    geofence.StrockWeight
                );
            }

            var gvar = new GVAR();
            gvar.AddDataTable("CircularGeofences", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

        [HttpPost("circular/add")]
        public IActionResult AddCircularGeofence([FromBody] CircularGeofenceDTO circularGeofenceDTO)
        {
            if (ModelState.IsValid)
            {
                var Circlegeofence = new CircleGeofence
                {
                    //Id = circularGeofenceDTO.GeofenceId,
                    Radius = circularGeofenceDTO.Radius,
                    Latitude = circularGeofenceDTO.Latitude,
                    Longitude = circularGeofenceDTO.Longitude,
                    AddedDate = FormattedStringToUnixTimeStamp(circularGeofenceDTO.AddedDate).ToString(),
                    FillColor = circularGeofenceDTO.FillColor,
                    FillOpacity = circularGeofenceDTO.FillOpacity,
                    GeofenceType = circularGeofenceDTO.GeofenceType,
                    StrockColor = circularGeofenceDTO.StrockColor,
                    StrockOpacity = circularGeofenceDTO.StrockOpacity,
                    StrockWeight = circularGeofenceDTO.StrockWeight
                };

                circularGeofenceRepo.Insert(Circlegeofence);
                circularGeofenceRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["Id"] = Circlegeofence.Id.ToString(),
                    ["Radius"] = Circlegeofence.Radius.ToString(),
                    ["Latitude"] = Circlegeofence.Latitude.ToString(),
                    ["Longitude"] = Circlegeofence.Longitude.ToString(),
                    ["AddedDate"] = UnixTimeStampToFormattedString(long.Parse(Circlegeofence.AddedDate)),
                    ["FillColor"] = Circlegeofence.FillColor.ToString(),
                    ["FillOpacity"] = Circlegeofence.FillOpacity.ToString(),
                    ["GeofenceType"] = Circlegeofence.GeofenceType.ToString(),
                    ["StrockColor"] = Circlegeofence.StrockColor.ToString(),
                    ["StrockOpacity"] = Circlegeofence.StrockOpacity.ToString(),
                    ["StrockWeight"] = Circlegeofence.StrockWeight.ToString()
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
