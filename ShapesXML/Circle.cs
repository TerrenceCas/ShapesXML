using System;

namespace ShapesXML
{
    public class Circle : Shape
    {
        public override string Colour { get; set; }
        public double Radius { get; set; }
        public override double Area => Math.PI * Math.Pow(Radius, 2);
    }
}