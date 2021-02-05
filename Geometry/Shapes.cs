/* 
 * Author: Kushal Bhandari 
 * BronCAD: Shapes & Geometry Math
 */

using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Point
    {
        private double x, y, z;
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        
        public Point() { X = 0.0; Y = 0.0; Z = 0.0; }
        public Point(double X, double Y, double Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public class Line
    {
        private Point startPoint, endPoint;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line() 
        { 
            startPoint = null;
            endPoint = null; 
        }
        
        public Line(Point startPoint, Point endPoint)
        {
            this.setPoints(startPoint, endPoint);
        }

        public Line(Line line2)
        {
            this.setPoints(line2.StartPoint, line2.EndPoint);
        }

        public void setPoints(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
    }

    public class Circle
    {
        private Point location;
        private double radius;

        public Point Location { get; set; }
        public double Radius { get; set; }

        public Circle()
        {
            this.location = null;
            this.radius = 0.0;
        }

        public Circle(Circle circle2)
        {
            this.location = circle2.Location;
            this.radius = circle2.Radius;
        }
    }

    public class Ellipse
    {
        private Point location;
        private double majorRadius;
        private double minorRadius;

        public Point Location { get; set; }
        public double MajorRadius { get; set; }
        public double MinorRadius { get; set; }

        public Ellipse()
        {
            this.location = null;
            this.majorRadius = 0.0;
            this.minorRadius = 0.0;
        }

        public Ellipse(Ellipse ellipse2)
        {
            this.location = ellipse2.location;
            this.majorRadius = ellipse2.majorRadius;
            this.minorRadius = ellipse2.minorRadius;
        }
    }

    /* 
     * Holds vector val, and derivatives on the parameter that the derivatives are being calculated
     */
    public class VectorMath
    {
        double x, dx;
        double y, dy;
        double z, dz;
        VectorMath() { x = 0; y = 0; z = 0; dx = 0; dy = 0; dz = 0; }
        public VectorMath(double x, double y, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            dx = 0;
            dy = 0;
        }
        public VectorMath(double x, double y, double z, double dx, double dy, double dz)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
        }
        public VectorMath(Point p, double derivparam)
        {
            x = p.X; y = p.Y;
            dx = 0.0; dy = 0.0;

            if (derivparam == p.X)
                dx = 1.0;
            if (derivparam == p.Y)
                dy = 1.0;
        }
        //gets distance/length of the path
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double Length(ref double length)
        {
            double l = Length();
            if (l == 0)
            {
                length = 1.0;
                return l;
            }
            else
            {
                length = (x * dx + y * dy) / l;
                return l;
            }
        }

        public VectorMath sum(VectorMath vectTwo)
        {
            return new VectorMath(x + vectTwo.x, y + vectTwo.y, 0, dx + vectTwo.dx, dy + vectTwo.dy, 0);
        }

        public VectorMath subtract(VectorMath vectTwo)
        {
            return new VectorMath(x - vectTwo.x, y - vectTwo.y, 0, dx - vectTwo.dx, dy - vectTwo.dy, 0);
        }
        public VectorMath mult(double point)
        {
            return new VectorMath(x *point, y* point, 0, dx *point, dy * point, 0);
        }
        public VectorMath multDerivative(double point, double dpoint)
        {
            return new VectorMath(x * point, y * point, 0, dx * dpoint, dy * dpoint, 0);
        }

        public VectorMath divDerivative(double point, double dpoint)
        {
            return new VectorMath(x / point, y / point, 0,
                       dx / point - x * dpoint / (point * point),
                       dy / point - y * point / (point * point), 0);
        }

        public VectorMath rotateCounterClock()
        {
            return new VectorMath(-y, x,0, -dy, dx,0);
        }

        public VectorMath rotateClockWise()
        {
            return new VectorMath(y, -x, 0, dy, -dx, 0);
        }

        public VectorMath combineVector(VectorMath vectTwo)
        {
            return new VectorMath(x + vectTwo.x, y + vectTwo.y, 0, dx + vectTwo.dx, dy + vectTwo.dy, 0);
        }
    }
}
