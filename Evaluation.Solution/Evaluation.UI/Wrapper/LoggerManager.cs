using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Fluent;

namespace Evaluation.UI.Wrapper
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger _Logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            _Logger.Debug(message);
        }

        public void LogError(string message, Exception exception)
        {
            _Logger.Error(exception, message);
        }

        public void LogInfo(string message)
        {
            _Logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _Logger.Warn(message);
        }

        public void SetCorrelationId(string correlationId, string userName)
        {
            ScopeContext.PushProperty("correlationId", correlationId);
            ScopeContext.PushProperty("userName", userName);
        }
    }
}
