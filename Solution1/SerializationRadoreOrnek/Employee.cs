using System.Xml.Serialization;

namespace SerializationRadoreOrnek
{
    [Serializable]
    public class Employee
    {
        public string name { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public string department { get; set; }
        public int salary { get; set; }

        [XmlIgnore]
        [NonSerialized]
        public string additionalInfo;
    }
}