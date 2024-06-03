using AnasProject.DTOS;
using AnasProject.Repos.RectangularGeofenceReopsitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangularGeofenceController : ControllerBase
    {
        private readonly IRectangularGeofenceRepo rectangularGeofenceRepo;
        public RectangularGeofenceController(IRectangularGeofenceRepo rectangularGeofenceRepo)
        {
            this.rectangularGeofenceRepo = rectangularGeofenceRepo;
        }

        [HttpGet("rectangular")]
        public IActionResult GetRectangularGeofences()
        {
            var rectangularGeofences = rectangularGeofenceRepo.GetAll();
            var dataTable = new DataTable("RectangleGeofences");
            dataTable.Columns.Add("Id", typeof(long));
            dataTable.Columns.Add("North", typeof(double));
            dataTable.Columns.Add("West", typeof(double));
            dataTable.Columns.Add("East", typeof(double));
            dataTable.Columns.Add("South", typeof(double));
            dataTable.Columns.Add("AddedDate", typeof(string));
            dataTable.Columns.Add("GeofenceType", typeof(string));
            dataTable.Columns.Add("FillColor", typeof(string));
            dataTable.Columns.Add("StrokeOpacity", typeof(double));
            dataTable.Columns.Add("StrokeWeight", typeof(double));
            dataTable.Columns.Add("StrokeColor", typeof(string));
            dataTable.Columns.Add("FillOpacity", typeof(double));

            foreach (var geofence in rectangularGeofences)
            {
                dataTable.Rows.Add(geofence.Id,
                    geofence.North,
                    geofence.West,
                    geofence.East,
                    geofence.South,
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
            gvar.AddDataTable("RectangleGeofences", dataTable);

            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }

        [HttpPost("rectangular/add")]
        public IActionResult AddRectangularGeofence([FromBody] RectangularGeofenceDTO rectangularGeofenceDTO)
        {
            if (ModelState.IsValid)
            {
                var rectangleGeofence = new RectangleGeofence
                {
                    North = rectangularGeofenceDTO.North,
                    West = rectangularGeofenceDTO.West,
                    East = rectangularGeofenceDTO.East,
                    South = rectangularGeofenceDTO.South,
                    AddedDate = FormattedStringToUnixTimeStamp(rectangularGeofenceDTO.AddedDate).ToString(),
                    FillColor = rectangularGeofenceDTO.FillColor,
                    FillOpacity = rectangularGeofenceDTO.FillOpacity,
                    GeofenceType = rectangularGeofenceDTO.GeofenceType,
                    StrockColor = rectangularGeofenceDTO.StrockColor,
                    StrockOpacity = rectangularGeofenceDTO.StrockOpacity,
                    StrockWeight = rectangularGeofenceDTO.StrockWeight
                };

                rectangularGeofenceRepo.Insert(rectangleGeofence);
                rectangularGeofenceRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["Id"] = rectangleGeofence.Id.ToString(),
                    ["North"] = rectangleGeofence.North.ToString(),
                    ["West"] = rectangleGeofence.West.ToString(),
                    ["East"] = rectangleGeofence.East.ToString(),
                    ["South"] = rectangleGeofence.South.ToString(),
                    ["AddedDate"] = UnixTimeStampToFormattedString(long.Parse(rectangleGeofence.AddedDate)),
                    ["FillColor"] = rectangleGeofence.FillColor,
                    ["FillOpacity"] = rectangleGeofence.FillOpacity.ToString(),
                    ["GeofenceType"] = rectangleGeofence.GeofenceType,
                    ["StrockColor"] = rectangleGeofence.StrockColor,
                    ["StrockOpacity"] = rectangleGeofence.StrockOpacity.ToString(),
                    ["StrockWeight"] = rectangleGeofence.StrockWeight.ToString()
                };

                var response = new
                {
                    gvar = gvar
                };

                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");
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
