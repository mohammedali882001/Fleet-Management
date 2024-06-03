using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class CircleGeofence:Geofence
{
    //public long Id { get; set; }


    public long Radius { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }



}
