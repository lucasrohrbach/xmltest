using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace xmlSerializerTest
{
    public class Company
    {
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("year")]
        public int Age { get; set; }
    }
}
