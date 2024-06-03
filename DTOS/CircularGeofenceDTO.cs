namespace AnasProject.DTOS
{
    public class CircularGeofenceDTO
    {
        public long Radius { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string GeofenceType { get; set; }
        public string AddedDate { get; set; }
        public string StrockColor { get; set; }
        public double StrockOpacity { get; set; }
        public double StrockWeight { get; set; }
        public string FillColor { get; set; }
        public double FillOpacity { get; set; }
    }
}
