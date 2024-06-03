namespace AnasProject.DTOS
{
    public class GeofenceForGetDTO
    {
        public long GeofenceId { get; set; }
        public string GeofenceType { get; set; }
        public long AddedDate { get; set; }
        public string StrockColor { get; set; }
        public double StrockOpacity { get; set; }
        public double StrockWeight { get; set; }

        public string FillColor { get; set; }

        public double FillOpacity { get; set; }
    }
}
