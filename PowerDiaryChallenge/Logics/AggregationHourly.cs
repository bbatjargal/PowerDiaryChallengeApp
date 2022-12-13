// -------------------------------------------------------------------------------------------------
// FileName: HourlyAggregation.cs
// Description: Contains an aggregation class to aggregate chat history hourly.
// Created on 12/12/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using PowerDiaryChallenge.Enums;
using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Models;
using PowerDiaryChallenge.Utils;

namespace PowerDiaryChallenge.Logics
{
    /// <summary>
    /// A class to aggregate chat history houly.
    /// </summary>
    public class AggregationHourly : IAggregation
    {
        /// <summary>
        /// Generates aggregated messages by the hour.
        /// </summary>
        /// <param name="messages">List of <see cref="IMessage"/> to aggregate.</param>
        /// <returns>Returns key-value pairs for aggregated messages.</returns>
        public async Task<IReadOnlyDictionary<string, IList<IMessage>>> AggregateAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(messages, nameof(messages));

            // The foreach loop can be used for the task below but wanted to display
            // an alternative way to do the same task using parallel LINQ.
            var groupedMessages = messages
                .AsParallel()
                .GroupBy(message => message.CreatedAt.ToString(Constants.DateTimeFormatByHour))
                .ToDictionary(group => group.Key, group => group.ToList());

            // The following task can be done in parallel using multi-threads.
            // Creates a new dictionary which stores aggregated messages.
            var aggregatedMessages = new Dictionary<string, IList<IMessage>>();
            foreach (var groupKey in groupedMessages.Keys)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var listOfMessages = new List<IMessage>();
                foreach (EventTypeEnum eventType in Enum.GetValues(typeof(EventTypeEnum)))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (groupedMessages[groupKey].Any(message => message.EventType == eventType))
                    {
                        IMessage newMessage = AggregationUtil.GetGroupedMessage(groupedMessages[groupKey], eventType);
                        listOfMessages.Add(newMessage);
                    }
                }
                if (!aggregatedMessages.ContainsKey(groupKey))
                {
                    aggregatedMessages[groupKey] = new List<IMessage>();
                }
                aggregatedMessages[groupKey] = listOfMessages;
            }

            // Sorts a dictionary by key.
            var sortedDict = new SortedDictionary<string, IList<IMessage>>(aggregatedMessages);
            return await Task.FromResult(sortedDict);

        }
    }
}
