using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationExample
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }  
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point[] arr = new Point[] { new Point { x = 10, y = 20 }, new Point { x = 30, y = 40 } };

            var serializer = new XmlSerializer(typeof(Point[]));
            var sb = new StringBuilder();
            var tw = new StringWriter(sb);
            serializer.Serialize(tw, arr);
            var xml = sb.ToString();
            Console.WriteLine(xml);
            var px = serializer.Deserialize(new StringReader(xml)) as Point[];
            Console.WriteLine(px[0].x);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var p = xmlDoc.SelectSingleNode("//Point");
            p.InnerText = "ala ma kota";
            var atr = xmlDoc.CreateAttribute("x");
            atr.Value = "33333";
            p.Attributes.Append(atr);
            Console.WriteLine(xmlDoc.OuterXml);
            var json = new DataContractJsonSerializer(typeof(Point[]));
            using (var v = File.Create(@"c:\temp\x.json")) {
                json.WriteObject(v,arr);
            }
            using (var v = File.OpenRead(@"c:\temp\x.json"))
            {
                var arr1 = json.ReadObject(v) as Point[] ;
                Console.WriteLine(arr1[1].x);

            }
            Console.ReadLine();


        }
    }
}
