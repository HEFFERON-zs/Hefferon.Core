using System;

namespace Hefferon.Core.Diagnostics
{
    /// <summary>
    /// Defines functionality of logging provider.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified <paramref name="message"/> as information.
        /// </summary>
        /// <param name="message">Message.</param>
        void Info(string message);

        /// <summary>
        /// Logs the message as information by formatting the arguments
        /// according to the specified <paramref name="messageFormat"/>.
        /// </summary>
        /// <param name="messageFormat">Message format.</param>
        /// <param name="args">Message arguments.</param>
        void Info(string messageFormat, params object[] args);

        /// <summary>
        /// Logs the specified exception as warning.
        /// </summary>
        /// <param name="ex">Exception.</param>
        void Warn(Exception ex);

        /// <summary>
        /// Logs the specified <paramref name="message"/> as warning.
        /// </summary>
        /// <param name="message">Message.</param>
        void Warn(string message);

        /// <summary>
        /// Logs the specified <paramref name="message"/> and exception as warning.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        void Warn(string message, Exception ex);

        /// <summary>
        /// Logs the message as warning by formatting the arguments
        /// according to the specified <paramref name="messageFormat"/>.
        /// </summary>
        /// <param name="messageFormat">Message format.</param>
        /// <param name="args">Message arguments.</param>
        void Warn(string messageFormat, params object[] args);

        /// <summary>
        /// Logs the specified exception as error.
        /// </summary>
        /// <param name="ex">Exception.</param>
        void Error(Exception ex);

        /// <summary>
        /// Logs the specified <paramref name="message"/> as error.
        /// </summary>
        /// <param name="message">Message.</param>
        void Error(string message);

        /// <summary>
        /// Logs the specified <paramref name="message"/> and exception as error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        void Error(string message, Exception ex);

        /// <summary>
        /// Logs the message as error by formatting the arguments
        /// according to the specified <paramref name="messageFormat"/>.
        /// </summary>
        /// <param name="messageFormat">Message format.</param>
        /// <param name="args">Message arguments.</param>
        void Error(string messageFormat, params object[] args);

        /// <summary>
        /// Logs the specified exception as debug.
        /// </summary>
        /// <param name="ex">Exception.</param>
        void Debug(Exception ex);

        /// <summary>
        /// Logs the specified <paramref name="message"/> as debug.
        /// </summary>
        /// <param name="message">Message.</param>
        void Debug(string message);

        /// <summary>
        /// Logs the specified <paramref name="message"/> and exception as debug.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        void Debug(string message, Exception ex);

        /// <summary>
        /// Logs the message as debug by formatting the arguments
        /// according to the specified <paramref name="messageFormat"/>.
        /// </summary>
        /// <param name="messageFormat">Message format.</param>
        /// <param name="args">Message arguments.</param>
        void Debug(string messageFormat, params object[] args);
    }
}