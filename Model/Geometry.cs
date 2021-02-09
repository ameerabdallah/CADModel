using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    enum GeoType
    {
        None,
        Point,
        Line,
        Arc,
        Circle,
        Ellipse,
        ArcOfEllipse,
        ArcOfHyperbola,
        ArcOfParabola,
        BSpline
    }
    class Geometry
    {
    }

    class GeoDef
    {
        Geometry geometry;  // A reference to the geometry
        GeoType type;       // Geometry Type
        int index;          // index in respective List<type>

    }
}
