// -------------------------------------------------------------------------------------------------
// FileName: AggregationUtil.cs
// Description: Contains a class which provides utility functions.
// Created on 12/12/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using PowerDiaryChallenge.Enums;
using PowerDiaryChallenge.Models;
using System.Text;

namespace PowerDiaryChallenge.Utils
{
    /// <summary>
    /// A class which provides utility functions.
    /// </summary>
    public static class AggregationUtil
    {
        /// <summary>
        /// Generates a grouped message.
        /// </summary>
        /// <returns>Returns a <see cref="IMessage"/>.</returns>
        public static IMessage GetGroupedMessage(IList<IMessage> messages, EventTypeEnum eventType)
        {
            EnsureArg.IsNotNull(messages, nameof(messages));

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

        private static string GenerateMessage(EventTypeEnum eventType, int eventCount, int countHighFivedFrom = 0, int countHighFivedTo = 0)
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
