namespace Radore_OOP.Solid.Bad
{
    public class Logger
    {
        public DbLog dbLog;
        public XmlLog xmlLog;
        public JsonLog jsonLog;

        public Logger(DbLog dbLog, XmlLog xmlLog, JsonLog jsonLog)
        {
            this.dbLog = dbLog;
            this.xmlLog = xmlLog;
            this.jsonLog = jsonLog;
        }

        public void LogSave(LogType type, string message)
        {
            switch (type)
            {
                case LogType.Xml:
                    xmlLog.xmlSave(message);
                    break;

                case LogType.Db:
                    dbLog.dbSave(message);
                    break;

                case LogType.Json:
                    jsonLog.JsonSave(message);
                    break;
            }
        }
    }
}