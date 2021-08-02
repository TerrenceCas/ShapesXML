using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static System.Console;

namespace ShapesXML
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    public class Shape
    {
        public virtual string Colour { get; set; }
        public virtual double Area { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
            };

            string xmlFile = "shapes.xml";

            ToXmlFile(xmlFile, listOfShapes);

            List<Shape> loadedShapesXml =
                 FromXmlFile<List<Shape>>(xmlFile);


            foreach (Shape item in listOfShapes)
            {
                WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of { item.Area}");
            }
        }
        public static T FromXmlFile<T>(string file)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            var xmlContent = File.ReadAllText(file);

            using (StringReader sr = new StringReader(xmlContent))
            {
                return (T)xmls.Deserialize(sr);
            }
        }

        public static void ToXmlFile<T>(string file, T obj)
        {
            using (StringWriter sw =
                new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }
    }
}


