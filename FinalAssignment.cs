using Shapes3D;

namespace Shapes3D {
    public abstract class Shape3D
    {
        public abstract double SurfaceArea();
        public abstract double Volume();
    }
       public class Cuboid : Shape3D 
       {
        private double _width;
        private double _height;
        private double _depth;
        private double _surfaceArea;
        private double _volume;

        public double Width { get { return _width; } set { if (value > 0) _width = value; }}
        public double Height { get { return _height; } set { if (value > 0) _height = value; }}
        public double Depth { get { return _depth; } set { if (value > 0) _depth = value; }}

        public Cuboid(double width, double height, double depth) {
            string errorMessage = "dimensions must be positive.";
            if (width <= 0) {throw new ArgumentException(string.Format(errorMessage, width.ToString()));}
            if (height <= 0) {throw new ArgumentException(string.Format(errorMessage, height.ToString()));}
            if (depth <= 0) {throw new ArgumentException(string.Format(errorMessage, depth.ToString()));}

            _width = width;
            _height = height;
            _depth = depth;

            calculatorValues();
        }
        private void calculatorValues()
        {
            _surfaceArea = 2 * (_width * _height + _width * _depth + _height * _depth);
            _volume = _width * _height * _depth;
        }   
        public override double SurfaceArea() => _surfaceArea;
        public override double Volume() => _volume;
        
       }
       public class Cube : Cuboid {
            public Cube(double sideLength) : base(sideLength, sideLength, sideLength) {}
        }

       }
        public class Cylinder: Shape3D
        {
            private double _radius;
            private double _height;
            private double _surfaceArea;
            private double _volume;
        public double Radius { get { return _radius; } set { if (value > 0) _radius = value; }}
        public double Height { get { return _height; } set { if (value > 0) _height = value; }}

        public Cylinder(double radius, double height)
        {
            string errorMessage = "dimensions must be positive.";
            if (radius <= 0) {throw new ArgumentException(string.Format(errorMessage, radius.ToString()));}
            if (height <= 0) {throw new ArgumentException(string.Format(errorMessage, height.ToString()));}
            _radius = radius;
            _height = height;
            calculatorValues();
        }
        private void calculatorValues()
        {
            _surfaceArea = 2 * Math.PI * _radius * (_radius + _height);
            _volume = Math.PI * Math.Pow(_radius, 2) * _height;
        }   
        public override double SurfaceArea() => _surfaceArea;
        public override double Volume() => _volume;

        }
        public class Sphere: Shape3D {
            private double _radius;
            private double _surfaceArea;
            private double _volume;
        public double Radius { get { return _radius; } set { if (value > 0) _radius = value; }}
        public Sphere(double radius)
        {
            string errorMessage = "dimensions must be positive.";
            if (radius <= 0) {throw new ArgumentException(string.Format(errorMessage, radius.ToString()));}
            _radius = radius;
            calculatorValues();
        }
        private void calculatorValues()
        {
            _surfaceArea = 4 * Math.PI * Math.Pow(_radius, 2);
            _volume = (4.0 / 3.0) * Math.PI * Math.Pow(_radius, 3);
        }   
        public override double SurfaceArea() => _surfaceArea;
        public override double Volume() => _volume;


        }
        public class Prism: Shape3D {

            private double _sideLength;
            private int _faces;
            private double _height;
            private double _surfaceArea;
            private double _volume;
            
            public double SideLength { get { return _sideLength; } set { if (value > 0) _sideLength = value; }}
            public int Faces { get { return _faces; } set { if (value >= 3) _faces = value; }}
            public double Height { get { return _height; } set { if (value > 0) _height = value; }}

            public Prism(double sideLength, int faces, double height)
            {
            string errorMessage = "dimensions must be positive.";
            if (sideLength <= 0) {throw new ArgumentException(string.Format(errorMessage, sideLength.ToString()));}
            if (faces < 3) {throw new ArgumentException(string.Format(errorMessage, faces.ToString()));}
            if (height <= 0) {throw new ArgumentException(string.Format(errorMessage, height.ToString()));}
            _sideLength = sideLength;
            _faces = faces;
            _height = height;
            calculatorValues();
            }
        private void calculatorValues()
        {
            double Perimeter = _faces * _sideLength;
            double apothem = _sideLength / (2 * Math.Tan(Math.PI / _faces));
            double Area = 0.5 * Perimeter * apothem;
            _surfaceArea = (Area * 2) + (Perimeter * _height);
            _volume = Area * _height;
        }   
        public override double SurfaceArea() => _surfaceArea;
        public override double Volume() => _volume;            

        }
