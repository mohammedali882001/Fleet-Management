using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class Driver
{
    public long DriverId { get; set; }
    public string? DriverName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string? PhoneNumber { get; set; }
    public virtual ICollection<VehiclesInformation> VehiclesInformations { get; set; } = new List<VehiclesInformation>();
}
