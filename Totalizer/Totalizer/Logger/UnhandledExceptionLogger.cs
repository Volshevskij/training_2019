using System.Web.Http.ExceptionHandling;

namespace Totalizer.Logger
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            var newLog = context.Exception.ToString();
            log4net.GlobalContext.Properties["LogFileName"] = @"Logs\\ErrorLog.log";
            log4net.Config.XmlConfigurator.Configure();
            log.Error(newLog);
        }
    }
}