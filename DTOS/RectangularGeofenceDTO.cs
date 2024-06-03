namespace AnasProject.DTOS
{
    public class RectangularGeofenceDTO
    {
        public double North { get; set; }
        public double East { get; set; }
        public double West { get; set; }
        public double South { get; set; }

        public string GeofenceType { get; set; }

        public string AddedDate { get; set; }

        public string StrockColor { get; set; }

        public double StrockOpacity { get; set; }

        public double StrockWeight { get; set; }

        public string FillColor { get; set; }

        public double FillOpacity { get; set; }
    }
}
