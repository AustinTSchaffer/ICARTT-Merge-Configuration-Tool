using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.Logging
{
    /// <summary>
    /// Interfaces with System.Diagnostics.Trace to provide custom message and error logging for the application. This log file will be stored in a directory named 'Logs' in the directory that contains the binary executable. The name of this log file will be 'ICARTT_Merge_Config_Log_YYYYMMDD.log'.
    /// <seealso cref="Trace"/>
    /// </summary>
    public static class Logger
    {
        #region readonly

        /// <summary>
        /// Used to trim incoming names to size.
        /// </summary>
        public static readonly int
            MAX_CLASS_NAME_LENGTH = 20,
            MAX_METHOD_NAME_LENGTH = 20;

        /// <summary>
        /// Format of the message that will be written to the log file. The fields will be populated in order of occurrance: Datetime, message code, class, message indent,  message.
        /// </summary>
        public static readonly string
            DATE_TIME_FORMAT = "{0}-{1}-{2} {3}:{4}:{5}.{6}",
            MESSAGE_FORMAT = "{0} {1,7} --- [{2," + MAX_CLASS_NAME_LENGTH.ToString() + "}].[{3," + MAX_METHOD_NAME_LENGTH.ToString() + "}] {4}{5}",
            NAME_OVERFLOW_REPLACEMENT = "...",
            MESSAGE_INDENT = "    ";


        /// <summary>
        /// Logs file name and location information.
        /// </summary>
        public static readonly string
            LOG_FILE_DIRECTORY_NAME = "Logs",

            LOG_FILE_DIRECTORY_PATH = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + LOG_FILE_DIRECTORY_NAME + Path.DirectorySeparatorChar,

            LOG_FILE_NAME = String.Format("ICARTT_Merge_Config_Log_{0}{1}{2}.log", DateTime.Now.Year.ToString("D4"), DateTime.Now.Month.ToString("D2"), DateTime.Now.Day.ToString("D2"));


        /// <summary>
        /// Minimum length of message queue to begin triggering warnings.
        /// </summary>
        private static readonly short HIGH_MESSAGE_COUNT_WARNING = 50;


        /// <summary>
        /// Name of the TextWriterTraceListener. Used for adding and removing the listener.
        /// </summary>
        private static readonly string LOG_FILE_WRITER_TRACE_LISTENER_NAME = "logFileTextWriterListener";

        #endregion


        #region private class utilities

        /// <summary>
        /// Queue object to hold messages to print to file. Will be useful in the event that messages are generated faster than file writing will allow.
        /// </summary>
        private static Queue<string> messageQueue;

        /// <summary>
        /// Flag to control access to the message queue.
        /// </summary>
        private static bool messageQueueIsOpen = false;


        /// <summary>
        /// Separate thread for digesting messages in Queue.
        /// </summary>
        private static Thread messageLoggingThread;

        /// <summary>
        /// Flag to notify if the thread to stop running.
        /// </summary>
        private static bool messageLoggingThreadRunning = false;

        /// <summary>
        /// Flag to notify message logging thread to begin closing.
        /// </summary>
        private static bool messageLoggingThreadClosing = false;

        /// <summary>
        /// Used to prevent issues with threading operations.
        /// </summary>
        private static Mutex mutex = new Mutex();


        #endregion


        /// <summary>
        /// Log file message codes.
        /// </summary>
        public enum MessageCode
        {
            Message,
            Warning,
            Error,
            Exception
        }


        /// <summary>
        /// Initializes the structures necessary for logging messages to the log file. This function must be called before the first log message can be written.
        /// </summary>
        public static void Setup()
        {
            messageLoggingThreadClosing = false;

            if (null == messageQueue || messageQueue.Count() != 0)
                messageQueue = new Queue<string>();

            messageQueueIsOpen = true;

            Directory.CreateDirectory(LOG_FILE_DIRECTORY_PATH);

            TextWriterTraceListener twtl = new TextWriterTraceListener(
                    LOG_FILE_DIRECTORY_PATH + LOG_FILE_NAME,
                    LOG_FILE_WRITER_TRACE_LISTENER_NAME
                    );

            if (!Trace.Listeners.Contains(twtl))
                Trace.Listeners.Add(twtl);

            if (null == messageLoggingThread || !messageLoggingThread.IsAlive)
            {
                messageLoggingThread = new Thread(new ThreadStart(Logger.LogUpdateLoop));
                messageLoggingThread.Start();
                messageLoggingThreadRunning = true;
            }

            Logger.Log(MessageCode.Message, typeof(Logger), MethodBase.GetCurrentMethod(), "Ready to accept and digest messages.");
        }


        /// <summary>
        /// Loop for digesting messages in the queue. Must be used in its own thread.
        /// </summary>
        private static void LogUpdateLoop()
        {
            while (messageLoggingThreadRunning)
            {
                if (messageQueue.Count() != 0)
                {
                    if (messageQueue.Count >= HIGH_MESSAGE_COUNT_WARNING)
                    {
                        Log(MessageCode.Warning, typeof(Logger), MethodBase.GetCurrentMethod(), String.Format("WARNING: {0} messages in Queue", messageQueue.Count()));
                    }
                    Trace.WriteLine(messageQueue.Dequeue());
                }
                else if (messageLoggingThreadClosing)
                {
                    Trace.Listeners.Remove(LOG_FILE_WRITER_TRACE_LISTENER_NAME);
                    messageLoggingThreadRunning = false;
                }

            }
        }


        /// <summary>
        /// Updates flags to tell logging thread that it's time to exit.
        /// </summary>
        public static void Close()
        {
            messageQueueIsOpen = false;
            messageLoggingThreadClosing = true;
        }


        /// <summary>
        /// Returns true if the logger is currently accepting messages
        /// </summary>
        public static bool MessageQueueIsOpen { get { return messageQueueIsOpen; } }


        /// <summary>
        /// Writes a message, error, or warning to the log file using System.Diagnostics.Trace. Method is hidden becuase it contains a flag that allows the Logger to bypass the queue.
        /// </summary>
        /// <param name="bypassQueue">Flag to allow logger to bypass queue</param>
        /// <param name="code">Message code</param>
        /// <param name="currentClass">Current executing class</param>
        /// <param name="currentMethod">Current executing method</param>
        /// <param name="message">Message to write. Cam accept multiple strings, which will be written to multiple lines. Please avoid using special characters.</param>
        public static void Log(MessageCode code, Type currentClass, MethodBase currentMethod, params string[] message)
        {
            if (!messageQueueIsOpen)
                return;

            DateTime messDT = DateTime.Now;

            string dateTimeString =
                String.Format(
                    DATE_TIME_FORMAT,
                    messDT.Year.ToString("D4"), messDT.Month.ToString("D2"),
                    messDT.Day.ToString("D2"), messDT.Hour.ToString("D2"),
                    messDT.Minute.ToString("D2"), messDT.Second.ToString("D2"),
                    messDT.Millisecond.ToString("D3")
                );

            for (int i = 0; i < message.Length; ++i)
            {
                string className = currentClass.Name;
                string methodName = currentMethod.Name;


                // If the name of the incoming class is too long, then it will be trimmed to size, including the addition of the characters that will signify that the class name was too long to be printed in full.
                if (className.Length > MAX_CLASS_NAME_LENGTH) className = NAME_OVERFLOW_REPLACEMENT + className.Substring(className.Length + NAME_OVERFLOW_REPLACEMENT.Length - MAX_CLASS_NAME_LENGTH);

                // Same for incoming method name.
                if (methodName.Length > MAX_METHOD_NAME_LENGTH) methodName = NAME_OVERFLOW_REPLACEMENT + methodName.Substring(methodName.Length + NAME_OVERFLOW_REPLACEMENT.Length - MAX_METHOD_NAME_LENGTH);


                string formattedMessage =
                    String.Format(
                        MESSAGE_FORMAT,
                        dateTimeString,
                        code.ToString("G").ToUpper(),
                        className,
                        methodName,
                        ((i == 0) ? "" : MESSAGE_INDENT),
                        message[i]
                        );

                mutex.WaitOne();
                messageQueue.Enqueue(formattedMessage);
                mutex.ReleaseMutex();
            }
        }


        /// <summary>
        /// Writes a log message with default code being "Message"
        /// </summary>
        /// <param name="currentClass">Current executing class</param>
        /// <param name="currentMethod">Current executing method</param>
        /// <param name="message">Message to write. Cam accept multiple strings, which will be written to multiple lines. Please avoid using special characters.</param>
        public static void Log(Type currentClass, MethodBase currentMethod, params string[] message) { Log(MessageCode.Message, currentClass, currentMethod, message); }
    }
}
