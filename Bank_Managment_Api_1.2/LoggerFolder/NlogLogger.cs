using System;
using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;
using LogLevel = NLog.LogLevel;

namespace Bank_Managment_Api_1._2.LoggerFolder;

public class NlogLogger
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    static void Main(string[] args)
    {
        // Create logging configuration
        var config = new LoggingConfiguration();

        // Define file target with JSON layout
        var fileTarget = new FileTarget { FileName = "APPLog.log" };
        fileTarget.Layout = new JsonLayout
        {
            Attributes = {
                new JsonAttribute("timestamp", "${date:format=yyyy-MM-ddTHH:mm:ssZ}"),
                new JsonAttribute("level", "${level}"),
                new JsonAttribute("message", "${message}"),
                new JsonAttribute("exception", "${exception:format=Message}")
            }
        };
        config.AddTarget("file", fileTarget);

        // Define console target
        var consoleTarget = new ConsoleTarget();
        config.AddTarget("console", consoleTarget);

        // Create logging rules
        var fileRule = new LoggingRule("*", LogLevel.Info, fileTarget);
        config.LoggingRules.Add(fileRule);

        var consoleRule = new LoggingRule("*", LogLevel.Debug, consoleTarget);
        config.LoggingRules.Add(consoleRule);

        // Set configuration
        LogManager.Configuration = config;

        // Log messages
        Logger.Info("Hello from Nlog");
        Logger.Error("Error from Nlog");
    }
}


