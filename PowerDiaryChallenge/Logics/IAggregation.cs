// -------------------------------------------------------------------------------------------------
// FileName: IAggregation.cs
// Description: Contains a aggregation interface to aggregate chat history based on a time-based granularity.
// Created on 12/12/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.Logics
{
    /// <summary>
    /// An aggregate interface to get chat history based on a time-based granularity.
    /// </summary>
    public interface IAggregation
    {
        /// <summary>
        /// Returns aggregated chat history based on a time-based granularity.
        /// </summary>
        Task<IReadOnlyDictionary<string, IList<IMessage>>> AggregateAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken);
    }
}
