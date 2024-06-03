using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnasProject;

public partial class RouteHistory
{
    public long RouteHistoryId { get; set; }
    public long VehicleId { get; set; }
    public int VehicleDirection { get; set; }
    public char Status { get; set; }
    public string VehicleSpeed { get; set; }
    public bool IsDeleted { get; set; } = false;
    public long Epoch { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
}
