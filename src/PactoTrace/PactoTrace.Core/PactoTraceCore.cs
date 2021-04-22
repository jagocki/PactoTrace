using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging.Abstractions;
using PactoTrace;

namespace PactoTrace.Core
{
    public class PactoTraceCore : IGenericEventSink
    {

        ILogger logger;


        public PactoTraceCore(ILogger<PactoTraceCore> logger)
        {
            this.logger = logger;
            Unit.eventSinkBuilder = () => { return this; };
        }

        //public void EndScope()
        //{
        //    if (scope != null)
        //    {
        //        scope.Dispose();
        //    }
        //}

        public void LogInformation(string s)
        {
            logger.Log(LogLevel.Information, s);
        }

        public void LogTrace(string s)
        {
            logger.Log(LogLevel.Trace, s);
        }

        public void LogDebug(string s)
        {
            logger.Log(LogLevel.Debug, s);
        }

        public void LogError(string s)
        {
            logger.Log(LogLevel.Error, s);
        }

        public void LogWarning(string s)
        {
            logger.Log(LogLevel.Warning, s);
        }

        public void LogCritical(string s)
        {
            logger.Log(LogLevel.Critical, s);
        }
        public IDisposable StartScope(string scopeName)
        {
            return logger.BeginScope("scope: " + scopeName);
        }

        //manage packages
        //https://www.visualstudiogeeks.com/azure/devops/perfecting-continuous-delivery-of-nuget-packages-for-azure-artifacts
    }


}
