using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Shapes3D;

namespace FinalAssignment 
{
    static class Solver 
    {
        public static void RunObject(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input filepath.");
                return;
            }
            string filepath = args[0];
            List<Shape3D> shapes = new List<Shape3D>();
            double totalArea = 0;
            double totalVolume = 0;

            foreach (string line in System.IO.File.ReadLines(filepath))
            {
                string[] lineData = line.Split(',');
                switch (lineData[0])
                {
                    case "cube":
                    {
                        double sideLength = double.Parse(lineData[1], CultureInfo.InvariantCulture);
                        Cube cube = new Cube(sideLength);
                        shapes.Add(cube);
                        break;
                    }
                    case "cuboid":
                    {
                        double width = double.Parse(lineData[1], CultureInfo.InvariantCulture),
                                 height = double.Parse(lineData[2], CultureInfo.InvariantCulture),
                                 depth = double.Parse(lineData[3], CultureInfo.InvariantCulture);
                        Cuboid cuboid = new Cuboid(width, height, depth);
                        shapes.Add(cuboid);
                        break;
                    }
                    case "cylinder":
                    {
                        double radius = double.Parse(lineData[1], CultureInfo.InvariantCulture),
                                height = double.Parse(lineData[2], CultureInfo.InvariantCulture);
                        Cylinder cylinder = new Cylinder(radius, height);
                        shapes.Add(cylinder);
                        break;
                    }
                    case "sphere":
                    {
                        double radius = double.Parse(lineData[1], CultureInfo.InvariantCulture);
                        Sphere sphere = new Sphere(radius);
                        shapes.Add(sphere);
                        break;
                    }
                    case "prism":
                    {
                        double sideLength = double.Parse(lineData[1], CultureInfo.InvariantCulture);
                        int faces = int.Parse(lineData[2]);
                        double height = double.Parse(lineData[3], CultureInfo.InvariantCulture);
                        Prism prism = new Prism(sideLength, faces, height);
                        shapes.Add(prism);
                        break;
                    }
                    case "area":
                    {
                        int scaleFactor = int.Parse(lineData[1]);
                        double Area = CalculatorArea(shapes) * scaleFactor;
                        totalArea += Area;
                        shapes.Clear();
                        break;
                    }
                    case "volume":
                    {
                        int scaleFactor = int.Parse(lineData[1]);
                        double Volume = CalculatorVolume(shapes) * scaleFactor;
                        totalVolume += Volume;
                        shapes.Clear();
                        break;
                    }
                }
            }
            double finalSum = totalArea + totalVolume;
            Console.WriteLine("The sum of measurements is {0:N2}.", finalSum);
        }
        private static double CalculatorArea(List<Shape3D> shapes)
        {
            double Area = 0;
            foreach (var shape in shapes)
            {
                Area += shape.SurfaceArea();
            }
            return Area;
        }
        private static double CalculatorVolume(List<Shape3D> shapes)
        {
            double Volume = 0;
            foreach (var shape in shapes)
            {
                Volume += shape.Volume();
            }
            return Volume;
        }

    }
}