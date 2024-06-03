namespace AnasProject.DTOS
{
    public class VehiclesInformationDTO
    {
        public long VehicleId { get; set; }
        public long? DriverId { get; set; }
        public string? VehicleMake { get; set; }
        //public string? LastAddress { get; set; }
        //public string? LastGPSSpeed { get; set; }
        //public long?	LastGPSTime { get; set; }

        public string? VehicleModel { get; set; }
        public string? PurchaseDate { get; set; }
    }
}
