using System;
using System.Collections.Generic;
using System.Text;

namespace PactoTrace
{
    public interface IGenericEventSink
    {
        void LogInformation(string s);

        void LogTrace(string s);
        void LogDebug(string s);
        void LogError(string s);

        void LogWarning(string s);

        void LogCritical(string s);
        IDisposable StartScope(string scopeName);

        //void EndScope();
    }
}
