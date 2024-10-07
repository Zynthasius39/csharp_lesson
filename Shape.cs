using Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    class Shape
    {
        public int[] sideSizes;
        public int sideCount;

        public override string ToString()
        {
            string val = "Shape(";
            for (int i = 0; i < sideSizes.Length; i++)
            {
                val += i.ToString();
                if (i != sideSizes.Length - 1)
                        val += ", ";
            }
            val += ")";
            return val;
        }
    }

    class Triangle : Shape
    {
        public Triangle(int[] sideSizesIn)
        {
            sideCount = 3;
            if (sideSizesIn.Count<int>() != 3)
            {
                throw new ArgumentException("Three arguments expected for Triangle");
            }
            for (int i = 0;  i < sideSizesIn.Length; i++)
            {
                if (sideSizesIn[i] <= 0)
                {
                    throw new ArgumentException("Invalid Triangle");
                }
                if (sideSizesIn[i] + sideSizesIn[(i + 1) % sideCount] <= sideSizesIn[(i + 2) % sideCount])
                {
                    throw new ArgumentException("Invalid Triangle");
                }
            }
            sideSizes = sideSizesIn;
        }

        public double GetArea()
        {
            int halfPerimeter = 0;
            halfPerimeter += (sideSizes[0] + sideSizes[1] + sideSizes[2]) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideSizes[0]) * (halfPerimeter - sideSizes[1]) * (halfPerimeter - sideSizes[2]));
        }

        public bool IsRectangularTriangle()
        {
            return Math.Pow(sideSizes[0], 2) + Math.Pow(sideSizes[1], 2) == Math.Pow(sideSizes[2], 2);
        }

        public double GetAngleFacingTo(int sideInx)
        {
            return Math.Round(
                Math.Acos(
                    (
                        Math.Pow(sideSizes[(sideInx + 1) % sideCount], 2) + Math.Pow(sideSizes[(sideInx + 2) % sideCount], 2) - Math.Pow(sideSizes[sideInx], 2)
                    ) / (
                        2 * sideSizes[(sideInx + 1) % sideCount] * sideSizes[(sideInx + 2) % sideCount])
                    ) * 57.2958
            );
        }

        public override string ToString()
        {
            return "Triangle(" + sideSizes[0] + ", " + sideSizes[1] + ", " + sideSizes[2] + ") Area: " + this.GetArea();
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(int[] sideSizesIn)
        {
            sideCount = 4;
            foreach (int side in sideSizesIn)
            {
                if (side <= 0)
                {
                    throw new ArgumentException("Invalid Rectangle");
                }
            }
            if (sideSizesIn.Count<int>() != sideCount)
            {
                throw new ArgumentException("Four arguments expected for Rectangle");
            } else if (sideSizesIn[0] != sideSizesIn[2] || sideSizesIn[1] != sideSizesIn[3])
            {
                throw new ArgumentException("Invalid Rectangle");
            }
            sideSizes = sideSizesIn;
        }

        public double GetArea()
        {
            return sideSizes[0] * sideSizes[1];
        }

        public override string ToString()
        {
            return "Rectangle(" + sideSizes[0] + ", " + sideSizes[1] + ", " + sideSizes[2] + ", " + sideSizes[3] + ") Area: " + this.GetArea();
        }
    }
    class Circle : Shape
    {
        public Circle(int radius)
        {
            sideCount = 0;
            if (radius <= 0)
            {
                throw new ArgumentException("Invalid Circle");
            }
            sideSizes = [radius];
        }

        public double GetArea()
        {
            return Math.Round(Math.PI * Math.Pow(sideSizes[0], 2));
        }

        public double GetLength()
        {
            return Math.PI * 2 * sideSizes[0];
        }

        public override string ToString()
        {
            return "Circle(" + sideSizes[0] + ") Area: " + this.GetArea();
        }
    }
}