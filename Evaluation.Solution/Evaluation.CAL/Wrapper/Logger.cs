using NLog;
using System;
using System.Runtime.CompilerServices;

namespace Evaluation.CAL.Wrapper
{
    /// <summary>
    /// The logger class.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Gets or sets a value indicating whether the status of the logger is enabled.
        /// </summary>
        /// <value>The name of the counter.</value>
        public static bool Enabled
        {
            get
            {
                return LogManager.IsLoggingEnabled();
            }

            set
            {
                if (value)
                {
                    while (!Enabled)
                    {
                        LogManager.EnableLogging();
                    }
                }
                else
                {
                    while (Enabled)
                    {
                        LogManager.DisableLogging();
                    }
                }
            }
        }

        /// <summary>
        /// The SetCorrelationId method
        /// </summary>
        /// <param name="correlationId">The correlationId value</param>
        /// <param name="userName">The username value</param>
        public static void SetCorrelationId(string correlationId, string userName)
        {
            MappedDiagnosticsLogicalContext.Set("correlationId", correlationId);
            MappedDiagnosticsLogicalContext.Set("userName", userName);
        }

        /// <summary>
        /// The generate correlation id.
        /// </summary>
        public static void GenerateCorrelationId()
        {
            MappedDiagnosticsLogicalContext.Set("correlationId", Guid.NewGuid().ToString());
            MappedDiagnosticsLogicalContext.Set("userName", string.Empty);
        }

        /// <summary>
        /// Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Trace(
            string message,
            Exception exception = null,
            [CallerFilePath] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Trace, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Debug(
            string message,
            Exception exception = null,
            [CallerFilePathAttribute] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Debug, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Info(
            string message,
            Exception exception = null,
            [CallerFilePathAttribute] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Info, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Warn(
            string message,
            Exception exception = null,
            [CallerFilePathAttribute] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Warn, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Error(
            string message,
            Exception exception = null,
            [CallerFilePathAttribute] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Error, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        public static void Fatal(
            string message,
            Exception exception = null,
            [CallerFilePathAttribute] string callerPath = "",
            [CallerMemberName] string callerMember = "",
            [CallerLineNumber] int callerLine = 0)
        {
            Log(LogLevel.Fatal, message, exception, callerPath, callerMember, callerLine);
        }

        /// <summary>
        /// Writes the specified diagnostic message.
        /// </summary>
        /// <param name="level">Level Value.</param>
        /// <param name="message">Message Value.</param>
        /// <param name="exception">Exception Value.</param>
        /// <param name="callerPath">Caller Path Value.</param>
        /// <param name="callerMember">Caller Member Value.</param>
        /// <param name="callerLine">Caller Line Value.</param>
        private static void Log(LogLevel level, string message, Exception exception = null, string callerPath = "", string callerMember = "", int callerLine = 0)
        {
            // get the source-file-specific logger
            var logger = LogManager.GetLogger(callerPath);

            // quit processing any further if not enabled for the requested logging level
            if (!logger.IsEnabled(level))
            {
                return;
            }

            // log the event with caller information bound to it
            var logEvent = new LogEventInfo(level, "Caller Path " + callerPath + " Caller Member " + callerMember + " Caller Line " + callerLine, message) { Exception = exception };
            logEvent.Properties.Add("callerpath", callerPath);
            logEvent.Properties.Add("callermember", callerMember);
            logEvent.Properties.Add("callerline", callerLine);
            logger.Log(logEvent);
        }
    }
}