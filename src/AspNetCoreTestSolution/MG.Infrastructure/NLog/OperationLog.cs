using System;
using NLog;

namespace MG.Infrastructure.NLog
{
    public class SysLogger
    {
        readonly static Logger operLogger = LogManager.GetLogger("operlogger");

        public static void Info(int type,string operUserName, string operIp, string content)
        {
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, "", content);
            theEvent.Properties["Type"] = type;
            theEvent.Properties["OperUser"] = operUserName;
            theEvent.Properties["IP"] = operIp;
            operLogger.Log(theEvent);
        }

        public static void Error(int type,string operUserName, string operIp, string content,Exception ex)
        {
            LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, "", null, content, null, ex);
            theEvent.Properties["Type"] = type;
            theEvent.Properties["OperUser"] = operUserName;
            theEvent.Properties["IP"] = operIp;
            operLogger.Log(theEvent);
        }

        public static void Flush()
        {
            LogManager.Flush();
        }
    }
}
