using System;
using System.Numerics;
//using System.Drawing.Point;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            std::vector<GCS::Point> Points;
            std::vector<GCS::Line> Lines;
            std::vector<GCS::Arc> Arcs;
            std::vector<GCS::Circle> Circles;
            std::vector<GCS::Ellipse> Ellipses;
            std::vector<GCS::ArcOfEllipse> ArcsOfEllipse;
            std::vector<GCS::ArcOfHyperbola> ArcsOfHyperbola;
            std::vector<GCS::ArcOfParabola> ArcsOfParabola;
            std::vector<GCS::BSpline> BSplines;
            */

            Model.Models.Point p = new Model.Models.Point(3, 4);

            Console.WriteLine(p.X + " " + p.Y + " " + p.Z);

        }
    }
}
