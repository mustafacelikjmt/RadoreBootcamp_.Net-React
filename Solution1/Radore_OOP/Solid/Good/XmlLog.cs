namespace Radore_OOP.Solid.Good
{
    public class XmlLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message + " Xml e kaydedildi");
        }
    }
}