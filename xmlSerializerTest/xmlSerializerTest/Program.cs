using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace xmlSerializerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string val1;
            Console.WriteLine("s = serialize");
            Console.WriteLine("d = deserialize");
            Console.WriteLine("Enter a value: ");
            val1 = Console.ReadLine();

            switch (val1)
            {
                case "d":
                    deserialize();
                    break;
                case "s":
                    serialize();
                    break;
                default:
                    break;
            }
        }

        static void serialize() 
        {
            string val2;
            Console.WriteLine("d = default filepath");
            Console.WriteLine("o = own filepath");
            Console.WriteLine("Enter a value: ");
            val2 = Console.ReadLine();

            var xmlFilePath = "";

            switch (val2)
            {
                case "d":
                    xmlFilePath = "C:/xmltest/test.config";
                    break;
                case "o":
                    Console.WriteLine("Enter a value: ");
                    xmlFilePath = Console.ReadLine();
                    break;
                default:
                    break;
            }
            var gritec = new Company();
            gritec.Employees = new List<Employee>() {
                new Employee() { Name = "John", Age = 10 },
                new Employee() { Name = "kjd", Age = 10 },
                new Employee() { Name = "John", Age = 10 }
            };

            serializeToXml(gritec, xmlFilePath);

            Console.WriteLine("finished!");
        }

        static void deserialize()
        {
            var xmlFilePath = "C:/xmltest/test.config";
            var gritec = new Company();
            gritec.Employees = new List<Employee>() {
                new Employee() { Name = "John", Age = 10 },
                new Employee() { Name = "John", Age = 10 },
                new Employee() { Name = "John", Age = 10 }
            };

            serializeToXml(gritec, xmlFilePath);
        }

        public static void serializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
            Console.WriteLine("serializing...");
        }
    }
}
