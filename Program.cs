using System;
using System.Numerics;
//using System.Drawing.Point;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TODO: 
             * Create Point Object ✔
             * Create Line Object ✔
             * Create Rectangle Object 
             * Create Polygon
             * Create Circle ✔
             * Create Ellipse ✔
             */

            Model.Models.Point p = new Model.Models.Point(3, 4);

            Console.WriteLine(p.X + " " + p.Y + " " + p.Z);

        }
    }
}
