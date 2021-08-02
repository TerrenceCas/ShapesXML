namespace ShapesXML
{
    public class Rectangle : Shape
    {
        public override string Colour { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area => Width * Height;
    }
}