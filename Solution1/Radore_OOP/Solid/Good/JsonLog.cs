namespace Radore_OOP.Solid.Good
{
    public class JsonLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message + " Json a kaydedildi");
        }
    }
}