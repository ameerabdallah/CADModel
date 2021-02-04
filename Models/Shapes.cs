﻿/* 
 * Author: Kushal Bhandari 
 * BronCAD: Shapes & Geometry Math
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Point
    {
        public double x;
        public double y;
        public double z;

        Point() { this.x = 0; this.y = 0; this.z = 0; }
        Point(double x, double y, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
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
            x = p.x; y = p.y;
            dx = 0.0; dy = 0.0;

            if (derivparam == p.x)
                dx = 1.0;
            if (derivparam == p.y)
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
