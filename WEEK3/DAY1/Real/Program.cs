using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeLogProcessor
{
    // Represents a single log entry
    class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        // Constructor to initialize a log entry
        public LogEntry(DateTime timestamp, string logLevel,
                        string message, string exception = null)
        {
            Timestamp = timestamp;
            LogLevel = logLevel;
            Message = message;
            Exception = exception;
        }
    }

    // Processes and manages log entries
    class LogProcessor
    {
        // StringBuilder is used to efficiently build log messages
        private StringBuilder buffer;

        // Maximum number of logs that can be stored in the buffer
        private int bufferCapacity;

        // Stores error messages separately
        private List<string> errorLogs;

        public LogProcessor(int capacity)
        {
            bufferCapacity = capacity;
            buffer = new StringBuilder();
            errorLogs = new List<string>();
        }

        // Processes a single log entry
        public void ProcessLog(LogEntry log)
        {
            // StringBuilder avoids creating many temporary string objects
            buffer.AppendLine(
                $"{log.Timestamp:yyyy-MM-dd HH:mm:ss} " +
                $"[{log.LogLevel}] {log.Message}"
            );

            // Store ERROR logs separately
            if (log.LogLevel.Equals("ERROR",
                StringComparison.OrdinalIgnoreCase))
            {
                string errorMessage =
                    $"{log.Timestamp:yyyy-MM-dd HH:mm:ss} " +
                    $"{log.Message}";

                if (!string.IsNullOrEmpty(log.Exception))
                {
                    errorMessage += $" | Exception: {log.Exception}";
                }

                errorLogs.Add(errorMessage);
            }

            // Flush when buffer reaches its capacity
            if (GetBufferCount() >= bufferCapacity)
            {
                FlushBuffer();
            }
        }

        // Returns the number of log entries currently in the buffer
        private int GetBufferCount()
        {
            // Count newline characters to determine number of entries
            int count = 0;

            foreach (char c in buffer.ToString())
            {
                if (c == '\n')
                    count++;
            }

            return count;
        }

        // Writes buffered logs to the file/system
        private void FlushBuffer()
        {
            if (buffer.Length == 0)
                return;

            Console.WriteLine("----- BUFFER FLUSHED -----");

            // In a real application, this data would be written to a file
            // using File.AppendAllText() or a StreamWriter.
            Console.Write(buffer.ToString());

            // Clear the StringBuilder after flushing
            buffer.Clear();

            Console.WriteLine("--------------------------\n");
        }

        // Flush remaining logs at the end
        public void CompleteProcessing()
        {
            if (buffer.Length > 0)
            {
                FlushBuffer();
            }
        }

        // Displays all error logs
        public void DisplayErrorSummary()
        {
            Console.WriteLine("\n===== ERROR SUMMARY =====");

            Console.WriteLine($"Total Errors: {errorLogs.Count}");

            foreach (string error in errorLogs)
            {
                Console.WriteLine(error);
            }

            Console.WriteLine("=========================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Buffer can store 3 log entries before flushing
            LogProcessor processor = new LogProcessor(3);

            // Creating different log entries
            LogEntry log1 = new LogEntry(
                DateTime.Now,
                "INFO",
                "Application started"
            );

            LogEntry log2 = new LogEntry(
                DateTime.Now,
                "INFO",
                "User logged in"
            );

            LogEntry log3 = new LogEntry(
                DateTime.Now,
                "ERROR",
                "Database connection failed",
                "SqlException: Connection timeout"
            );

            LogEntry log4 = new LogEntry(
                DateTime.Now,
                "WARNING",
                "Memory usage is high"
            );

            LogEntry log5 = new LogEntry(
                DateTime.Now,
                "ERROR",
                "File could not be processed",
                "FileNotFoundException"
            );

            // Process all logs
            processor.ProcessLog(log1);
            processor.ProcessLog(log2);
            processor.ProcessLog(log3);

            processor.ProcessLog(log4);
            processor.ProcessLog(log5);

            // Flush any remaining logs
            processor.CompleteProcessing();

            // Display error summary
            processor.DisplayErrorSummary();
        }
    }
}