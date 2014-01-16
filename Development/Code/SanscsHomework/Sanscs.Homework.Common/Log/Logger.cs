using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging.Database;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System.Diagnostics;
using System.IO;
namespace Sanscs.Homework.Common.Log
{
    public class Logger
    {
        private static Logger _instance;
        private LogWriter defaultWriter;
        private Logger()
        {
            TraceManager traceMgr;
            
            DatabaseProviderFactory factory = new DatabaseProviderFactory(new SystemConfigurationSource(false).GetSection);
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);

            LoggingConfiguration loggingConfiguration = BuildProgrammaticConfig();
            defaultWriter = new LogWriter(loggingConfiguration);

            // Create a TraceManager object for use in activity tracing example.
            traceMgr = new TraceManager(defaultWriter);
            try
            {
                if (!Directory.Exists(@"C:\Temp"))
                {
                    Directory.CreateDirectory(@"C:\Temp");
                }
            }
            catch
            {
                //Console.WriteLine(@"WARNING: Folder C:\Temp cannot be created for disk log files");
                //Console.WriteLine();
            }
        }
        private static readonly object lockHelper = new object();
        public  static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        _instance = new Logger();
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// log info 
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            if (defaultWriter.IsLoggingEnabled())
            {
                string[] logCategories = new string[] { "DiskFiles" };
                defaultWriter.Write(info, logCategories);                //writing message
            }
        }

        private LoggingConfiguration BuildProgrammaticConfig()
        {
            // Formatters
            TextFormatter briefFormatter = new TextFormatter("Timestamp: {timestamp(local)}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}ActivityId: {property(ActivityId)}{newline}Severity: {severity}{newline}Title:{title}{newline}");
            TextFormatter extendedFormatter = new TextFormatter("Timestamp: {timestamp}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}Severity: {severity}{newline}Title: {title}{newline}Activity ID: {property(ActivityId)}{newline}Machine: {localMachine}{newline}App Domain: {localAppDomain}{newline}ProcessId: {localProcessId}{newline}Process Name: {localProcessName}{newline}Thread Name: {threadName}{newline}Win32 ThreadId:{win32ThreadId}{newline}Extended Properties: {dictionary({key} - {value}{newline})}");

            // Category Filters
            ICollection<string> categories = new List<string>();
            categories.Add("BlockedByFilter");

            // Log Filters
            var priorityFilter = new PriorityFilter("Priority Filter", 2, 99);
            var logEnabledFilter = new LogEnabledFilter("LogEnabled Filter", true);
            var categoryFilter = new CategoryFilter("Category Filter", categories, CategoryFilterMode.AllowAllExceptDenied);

            // Trace Listeners
            //var causeLoggingErrorTraceListener = new FormattedDatabaseTraceListener(DatabaseFactory.CreateDatabase("DoesNotExist"), "WriteLog", "AddCategory", null);
            //var databaseTraceListener = new FormattedDatabaseTraceListener(DatabaseFactory.CreateDatabase("ExampleDatabase"), "WriteLog", "AddCategory", extendedFormatter);
            var flatFileTraceListener = new FlatFileTraceListener(@"C:\Temp\FlatFile.log", "----------------------------------------", "----------------------------------------", briefFormatter);
            var eventLog = new EventLog("Application", ".", "Enterprise Library Logging");
            var eventLogTraceListener = new FormattedEventLogTraceListener(eventLog);
            var rollingFlatFileTraceListener = new RollingFlatFileTraceListener(@"C:\Temp\RollingFlatFile.log", "----------------------------------------", "----------------------------------------", extendedFormatter, 20, "yyyy-MM-dd", RollFileExistsBehavior.Increment, RollInterval.None, 3);
            var unprocessedFlatFileTraceListener = new FlatFileTraceListener(@"C:\Temp\Unprocessed.log", "----------------------------------------", "----------------------------------------", extendedFormatter);
            var xmlTraceListener = new XmlTraceListener(@"C:\Temp\XmlLogFile.xml");
            xmlTraceListener.Filter = new EventTypeFilter(SourceLevels.Error);

            // Build Configuration
            var config = new LoggingConfiguration();
            config.Filters.Add(priorityFilter);
            config.Filters.Add(logEnabledFilter);
            config.Filters.Add(categoryFilter);

            config.AddLogSource("BlockedByFilter", SourceLevels.All, true).AddTraceListener(eventLogTraceListener);
            //config.AddLogSource("CauseLoggingError", SourceLevels.All, true).AddTraceListener(causeLoggingErrorTraceListener);
            //config.AddLogSource("Database", SourceLevels.All, true).AddTraceListener(databaseTraceListener);
            // The defaults for the asynchronous wrapper are:
            //   bufferSize: 30000
            //   disposeTimeout: infinite
            //config.AddLogSource("AsyncDatabase", SourceLevels.All, true).AddAsynchronousTraceListener(databaseTraceListener);
            config.AddLogSource("DiskFiles", SourceLevels.All, true).AddTraceListener(flatFileTraceListener);

            config.AddLogSource("General", SourceLevels.All, true).AddTraceListener(eventLogTraceListener);
            config.AddLogSource("Important", SourceLevels.All, true).AddTraceListener(eventLogTraceListener);
            config.LogSources["Important"].AddTraceListener(rollingFlatFileTraceListener);

            // Special Sources Configuration
            config.SpecialSources.Unprocessed.AddTraceListener(unprocessedFlatFileTraceListener);
            config.SpecialSources.LoggingErrorsAndWarnings.AddTraceListener(eventLogTraceListener);

            return config;
        }
    }
}
