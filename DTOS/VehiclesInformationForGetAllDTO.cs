namespace AnasProject.DTOS
{
    public class VehiclesInformationForGetAllDTO
    {
        public long? VehicleNumber { get; set; }
        public string ?VehicleType { get; set; } = string.Empty;
        public string? DriverName { get; set;}
      
        //public string? LastGPSSpeed { get; set; }
        //public long? LastGPSTime { get; set; }
        //public string? LastAddress { get; set; }

        public double? LastLatitude { get; set; }
        public double? LastLongitude { get; set; }
        public string ?VehicleMake { get; set; }
        public string ?VehicleModel { get; set; }
        public string ?PhoneNumber { get; set; }


    }
}
