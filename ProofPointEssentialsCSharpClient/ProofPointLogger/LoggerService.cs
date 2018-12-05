using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using ProofPointEssentialsCSharpClient.Models.Logger;
using ProofPointEssentialsCSharpClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofPointEssentialsCSharpClient
{
    public class LoggerService
    {
        public static ILog GetLogger(Type type)
        {
            Setup();
            return log4net.LogManager.GetLogger(type);
        }

        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = AppSettings.ProofPoint_Logs.IsNullOrEmpty() ? @"Logs\EventLog.txt" : AppSettings.ProofPoint_Logs;
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

        //private static string _logMessage;
        //private static string _Error;
        //private static Exception _ex;

        //public static void Log(LoggerModel.LogType logType, string LogMessage, string Error = null, Exception ex = null)
        //{
        //    try
        //    {
        //        _logMessage = LogMessage;
        //        _Error = Error;
        //        _ex = ex;

        //        switch (logType)
        //        {
        //            case LoggerModel.LogType.INFO:
        //                LogInfo();
        //                break;
        //            case LoggerModel.LogType.ERROR:
        //                LogError();
        //                break;
        //            case LoggerModel.LogType.EXCEPTION:
        //                LogException();
        //                break;
        //        }
        //    }
        //    catch
        //    { }
        //}

        //private static void LogInfo()
        //{

        //}

        //private static void LogError()
        //{
        //    throw new NotImplementedException();
        //}

        //private static void LogException()
        //{
        //    throw new NotImplementedException();
        //}
    }
}