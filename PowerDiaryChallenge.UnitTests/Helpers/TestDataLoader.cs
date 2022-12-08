// -------------------------------------------------------------------------------------------------
// FileName: TestDataLoader.cs
// Description: Contains a helper function to load messages for a test run.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Enums;
using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.UnitTests.Helpers
{
    /// <summary>
    /// A helper class for a test run.
    /// </summary>
    public static class TestDataLoader
    {
        /// <summary>
        /// A helper function to load test messages.
        /// </summary>
        /// <param name="dateTime">Test start date time for test messages.</param>
        /// <returns>Returns a list of <see cref="IMessage"/></returns>
        public static IEnumerable<IMessage> GetMessage(DateTime dateTime)
        {
            List<IMessage> messages = new List<IMessage>
            {
                new Message()
                {
                    CreatedAt = dateTime,
                    EventType = EventTypeEnum.EnteredRoom,
                    Text = "Bob enters the room."
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(18),
                    EventType = EventTypeEnum.LeftRoom,
                    Text = "Bob leaves"
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(5),
                    EventType = EventTypeEnum.EnteredRoom,
                    Text = "Kate enters the room."
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(17),
                    EventType = EventTypeEnum.HighFive,
                    Text = "Kate high-fives Bob.",
                    HighFivedFrom = "Kate",
                    HighFivedTo = "Bob"
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(15),
                    EventType = EventTypeEnum.Comment,
                    Text = "Bob comments: \"Hey, Kate - high five?\""
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(20),
                    EventType = EventTypeEnum.Comment,
                    Text = "Kate comments: \"Oh, typical\""
                },
                new Message()
                {
                    CreatedAt = dateTime.AddMinutes(21),
                    EventType = EventTypeEnum.LeftRoom,
                    Text = "Kate leaves"
                }
            };

            return messages;
        }
    }
}
