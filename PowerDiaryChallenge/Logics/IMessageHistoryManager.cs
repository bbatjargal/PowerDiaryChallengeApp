// -------------------------------------------------------------------------------------------------
// FileName: IMessageHistoryManager.cs
// Description: Contains a manager interface to aggregate chat history based on a time-based granularity.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.Logics
{
    /// <summary>
    /// A manager to aggregate chat history based on a time-based granularity.
    /// </summary>
    public interface IMessageHistoryManager
    {
        /// <summary>
        /// Generates aggregated messages by the minute.
        /// </summary>
        /// <param name="messages">List of <see cref="IMessage"/> to aggregate.</param>
        /// <returns>Returns key-value pairs for aggregated messages.</returns>
        IReadOnlyDictionary<string, IList<IMessage>> GetMessagesByMinute(IEnumerable<IMessage> messages);

        /// <summary>
        /// Generates aggregated messages by the hour.
        /// </summary>
        /// <param name="messages">List of <see cref="IMessage"/> to aggregate.</param>
        /// <returns>Returns key-value pairs for aggregated messages.</returns>
        IReadOnlyDictionary<string, IList<IMessage>> GetMessagesByHour(IEnumerable<IMessage> messages);
    }
}
