// -------------------------------------------------------------------------------------------------
// FileName: MessageHistoryManager.cs
// Description: Contains a manager class to aggregate chat history based on a time-based granularity.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using PowerDiaryChallenge.Enums;
using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Models;
using System.Text;

namespace PowerDiaryChallenge.Logics
{
    /// <inheritdoc />
    public class MessageHistoryManager : IMessageHistoryManager
    {

        /// <inheritdoc />
        public IReadOnlyDictionary<string, IList<IMessage>> GetMessagesByMinute(IEnumerable<IMessage> messages)
        {
            EnsureArg.IsNotNull(messages, nameof(messages));

            var groupedMessages = new Dictionary<string, IList<IMessage>>();

            // The following task can be done in parallel using multi-threads.
            foreach (var message in messages)
            {
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
            return sortedDict;
        }

        /// <inheritdoc />
        public IReadOnlyDictionary<string, IList<IMessage>> GetMessagesByHour(IEnumerable<IMessage> messages)
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
                var listOfMessages = new List<IMessage>();
                foreach (EventTypeEnum eventType in Enum.GetValues(typeof(EventTypeEnum))) 
                {
                    if (groupedMessages[groupKey].Any(message => message.EventType == eventType))
                    {
                        IMessage newMessage = GetGroupedMessage(groupedMessages[groupKey], eventType);
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
            return sortedDict;
        }

        private IMessage GetGroupedMessage(IList<IMessage> messages, EventTypeEnum eventType)
        {
            IMessage message = new Message();
            int eventCount = messages.Where(message => message.EventType == eventType).Count();

            switch (eventType)
            {
                case EventTypeEnum.EnteredRoom:
                case EventTypeEnum.LeftRoom:
                case EventTypeEnum.Comment:
                    message.Text = GenerateMessage(eventType, eventCount);
                    break;
                case EventTypeEnum.HighFive:
                    IEnumerable<IMessage> highFivedMessages = messages.Where(message => message.EventType == eventType);
                    int countHighFivedFrom = highFivedMessages.GroupBy(message => message.HighFivedFrom).Count();
                    int countHighFivedTo = highFivedMessages.GroupBy(message => message.HighFivedTo).Count();
                    message.Text = GenerateMessage(eventType, eventCount, countHighFivedFrom, countHighFivedTo);
                    break;
            }
            return message;
        }

        private string GenerateMessage(EventTypeEnum eventType, int eventCount, int countHighFivedFrom = 0, int countHighFivedTo = 0) 
        {
            StringBuilder sb = new StringBuilder();

            switch (eventType)
            {
                case EventTypeEnum.EnteredRoom:
                case EventTypeEnum.LeftRoom:
                    sb.Append(eventCount);
                    sb.Append(eventCount == 1 ? " person " : " people ");
                    sb.Append(eventType == EventTypeEnum.LeftRoom ? "left" : "entered");
                    break;
                case EventTypeEnum.Comment:
                    sb.Append(eventCount);
                    sb.Append(eventCount == 1 ? " comment" : " comments");
                    break;
                case EventTypeEnum.HighFive:
                    sb.Append(countHighFivedFrom);
                    sb.Append(countHighFivedFrom == 1 ? " person " : " people ");
                    sb.Append("high-fived ");
                    sb.Append(countHighFivedTo);
                    sb.Append(" other ");
                    sb.Append(countHighFivedTo == 1 ? "person" : "people");
                    break;
            }

            return sb.ToString();
        }
    }
}
