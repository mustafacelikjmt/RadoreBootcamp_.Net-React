namespace Radore_OOP.Solid.Good
{
    public class DbLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message + " Db ye kaydedildi");
        }
    }
}