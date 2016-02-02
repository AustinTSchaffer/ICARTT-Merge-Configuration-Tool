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
    /// Interfaces with System.Diagnostics.Trace to provide custom message and error logging for the application.
    /// <seealso cref="Trace"/>
    /// </summary>
    public static class Logger
    {

        /// <summary>
        /// Format of the message that will be written to the log file. The fields will be populated in order of occurrance: Datetime (yyyy-mm-dd @ hh:mm:ss:mmm), message code, class, method,  message.
        /// </summary>
        public static readonly string MESSAGE_FORMAT = "{0} {1} --- [{2}.{3}] {4}";

        /// <summary>
        /// Used to prevent issues with threading operations.
        /// </summary>
        private static Mutex mutex = new Mutex();

        /// <summary>
        /// Queue object to hold messages to print to file. Will be useful in the event that messages are generated faster than file writing will allow.
        /// </summary>
        private static Queue<string> messages;

        // TODO message type as an enum that can reference a string name
        // TODO find a place for::::: This log file will be stored in the 'Logs' directory in the directory that contains the binary executable. The name of this log file will be .

        /// <summary>
        /// Initializes the structures necessary for logging messages to the log file. This function must be called before the first 
        /// </summary>
        public static void Setup()
        {

            messages = new Queue<string>();

            // TODO remove suck
            Directory.CreateDirectory("Logs");
            Trace.Listeners.Add(
                new TextWriterTraceListener(
                    Directory.GetCurrentDirectory() +
                    Path.DirectorySeparatorChar +
                    "Logs" +
                    Path.DirectorySeparatorChar +
                    "TextWriterOutput.log", 
                    "myListener"
                )
            );
        }

        /// <summary>
        /// Writes a message, error, or warning to the log file using System.Diagnostics.Trace.
        /// </summary>
        /// TODO change messageType to enum.
        /// <param name="messageType">Type of message</param>
        /// <param name="currentClass">Current executing class</param>
        /// <param name="currentMethod">Current executing method</param>
        /// <param name="message">Message</param>
        public static void Log(Type currentClass, MethodBase currentMethod, string message)
        {
            mutex.WaitOne();
            
            DateTime messDT = DateTime.Now;

            string dateTimeString =
                String.Format(
                    "{0}-{1}-{2} {3}:{4}:{5}.{6}",
                    messDT.Year.ToString("D4"),         messDT.Month.ToString("D2"),
                    messDT.Day.ToString("D2"),          messDT.Hour.ToString("D2"),
                    messDT.Minute.ToString("D2"),       messDT.Second.ToString("D2"),
                    messDT.Millisecond.ToString("D3")
                );

            // Push the message into the queue.
            messages.Enqueue(
                String.Format(
                    MESSAGE_FORMAT,
                    dateTimeString,
                    "ERROR",
                    currentClass.Name,
                    currentMethod.Name,
                    message
                ));
            

            mutex.ReleaseMutex();

            Trace.WriteLine(messages.Dequeue());
        }
    }
}
