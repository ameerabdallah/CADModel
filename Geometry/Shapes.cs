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

        // copy constructor
        public Point(Point fromPoint)
        {
            this.X = fromPoint.X;
            this.Y = fromPoint.Y;
            this.Z = fromPoint.Z;
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

        // copy constructor
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

    public class Rectangle
    {
        
        Point center;
        double length;
        double width;
        Point corner0, corner1, corner2, corner3;
        Line line0, line1, line2, line3;
       
        // constructor taking length, width, and point representing the center
        public Rectangle(double _length, double _width, Point _center)
        {
            length = _length;
            width = _width;
            center = _center;

            init();

            setCornersFromCenter();
            setLinesFromCorners();

            // we now have data representing the center, 4 corners, and lines connecting them -luke
        }

        // default constructor
        public Rectangle()
        {
            new Rectangle(0, 0, new Point());
        }

        // copy constructor
        public Rectangle(Rectangle fromRect)
        {
            new Rectangle(fromRect.getLength(), fromRect.getWidth(), fromRect.getCenter());
        }

        // initialize corners and lines with new memory
        void init()
        {
            corner0 = new Point();
            corner1 = new Point();
            corner2 = new Point();
            corner3 = new Point();
            line0 = new Line();
            line1 = new Line();
            line2 = new Line();
            line3 = new Line();
        }

        // set coordinates of corner Points based on length and width
        void setCornersFromCenter()
        {
            double centerX = center.X;
            double centerY = center.Y;
            corner0.X = centerX - width / 2; corner0.Y = centerY - length / 2;
            corner0.X = centerX + width / 2; corner0.Y = centerY - length / 2;
            corner0.X = centerX + width / 2; corner0.Y = centerY + length / 2;
            corner0.X = centerX - width / 2; corner0.Y = centerY + length / 2;
        }

        // set Lines connecting the corners
        void setLinesFromCorners()
        {
            line0.setPoints(corner0, corner1);
            line1.setPoints(corner1, corner2);
            line2.setPoints(corner2, corner3);
            line3.setPoints(corner3, corner0);
        }

        // moves the center and resets the data based on the new center
        void setLocation(Point targetCenter)
        {
            center = targetCenter;
            setCornersFromCenter();
            setLinesFromCorners();
        }

        // getters
        public Point getCenter()
        {
            return center;
        }
        public double getLength()
        {
            return length;
        }
        public double getWidth()
        {
            return width;
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
