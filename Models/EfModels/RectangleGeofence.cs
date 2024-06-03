using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class RectangleGeofence : Geofence
{
    //public long Id { get; set; }
    public double North { get; set; }
    public double East { get; set; }
    public double West { get; set; }
    public double South { get; set; }

    
}
