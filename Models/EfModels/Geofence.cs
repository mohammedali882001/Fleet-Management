using System;
using System.Collections.Generic;

namespace AnasProject;

public partial class Geofence
{
    public long Id { get; set; }
    public string GeofenceType { get; set; }

    public string AddedDate { get; set; }

    public string StrockColor { get; set; }

    public bool IsDeleted { get; set; } = false;

    public double StrockOpacity { get; set; }

    public double StrockWeight { get; set; }

    public string FillColor { get; set; }

    public double FillOpacity { get; set; }

    public virtual ICollection<CircleGeofence> CircleGeofences { get; set; } = new List<CircleGeofence>();

    public virtual ICollection<PolygonGeofence> PolygonGeofences { get; set; } = new List<PolygonGeofence>();

    public virtual ICollection<RectangleGeofence> RectangleGeofences { get; set; } = new List<RectangleGeofence>();
}
