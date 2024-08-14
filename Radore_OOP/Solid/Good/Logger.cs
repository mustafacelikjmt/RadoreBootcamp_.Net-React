namespace Radore_OOP.Solid.Good
{
    public class Logger
    {
        public ILog _log;

        public Logger(ILog log)
        {
            _log = log;
        }

        public void LogSave(string message)
        {
            _log.Log(message);
        }
    }
}