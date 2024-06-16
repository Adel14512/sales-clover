using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Wrapper
{
    public interface ILoggerManager
    {
        void LogError(string message, Exception exception);
        void LogWarning(string message);

        void LogDebug(string message);

        void LogInfo(string message);

        void SetCorrelationId(string correlationId, string userName);
    }
}
