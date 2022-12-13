// -------------------------------------------------------------------------------------------------
// FileName: MinutelyAggregation.cs
// Description: Contains an aggregation class to aggregate chat history minutely.
// Created on 12/12/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.Logics
{
    /// <summary>
    /// A class to aggregate chat history minutely.
    /// </summary>
    public class AggregationMinutely : IAggregation
    {
        /// <summary>
        /// Generates aggregated messages by the minute.
        /// </summary>
        /// <param name="messages">List of <see cref="IMessage"/> to aggregate.</param>
        /// <returns>Returns key-value pairs for aggregated messages.</returns>
        public async Task<IReadOnlyDictionary<string, IList<IMessage>>> AggregateAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(messages, nameof(messages));

            var groupedMessages = new Dictionary<string, IList<IMessage>>();

            // The following task can be done in parallel using multi-threads.
            foreach (var message in messages)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // grouping by datetime
                string groupKey = message.CreatedAt.ToString(Constants.DateTimeFormatByMinute);
                if (!groupedMessages.ContainsKey(groupKey))
                {
                    groupedMessages[groupKey] = new List<IMessage>();
                }
                groupedMessages[groupKey].Add(message);
            }

            // Sorts a dictionary by key.
            var sortedDict = new SortedDictionary<string, IList<IMessage>>(groupedMessages);
            return await Task.FromResult(sortedDict);
        }
    }
}
