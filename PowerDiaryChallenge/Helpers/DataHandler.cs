// -------------------------------------------------------------------------------------------------
// FileName: DataHandler.cs
// Description: Contains a data handler class to generate a list of messages.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Enums;
using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.Helpers
{
    /// <inheritdoc />
    public class DataHandler : IDataHandler
    {
        /// <inheritdoc />
        public IEnumerable<IMessage> GetMessage()
        {

            DateTime createdDateTime = DateTime.Now;

            List<IMessage> messages = new List<IMessage>
            {
                new Message() { CreatedAt = createdDateTime, EventType = EventTypeEnum.EnteredRoom, Text = "Bob enters the room." },
                new Message() { CreatedAt = createdDateTime.AddMinutes(5), EventType = EventTypeEnum.EnteredRoom, Text = "Kate enters the room." },
                new Message() { CreatedAt = createdDateTime.AddMinutes(15), EventType = EventTypeEnum.Comment, Text = "Bob comments: \"Hey, Kate - high five?\"" },
                new Message() { CreatedAt = createdDateTime.AddMinutes(17), EventType = EventTypeEnum.HighFive, Text = "Kate high-fives Bob.", HighFivedFrom = "Kate", HighFivedTo = "Bob" },
                new Message() { CreatedAt = createdDateTime.AddMinutes(18), EventType = EventTypeEnum.LeftRoom, Text = "Bob leaves" },
                new Message() { CreatedAt = createdDateTime.AddMinutes(20), EventType = EventTypeEnum.Comment, Text = "Kate comments: \"Oh, typical\"" },
                new Message() { CreatedAt = createdDateTime.AddMinutes(21), EventType = EventTypeEnum.LeftRoom, Text = "Kate leaves" },

                new Message() { CreatedAt = createdDateTime.AddHours(1), EventType = EventTypeEnum.EnteredRoom, Text = "Sam enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(5), EventType = EventTypeEnum.EnteredRoom, Text = "Katerine enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(5), EventType = EventTypeEnum.EnteredRoom, Text = "Dona enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(15), EventType = EventTypeEnum.Comment, Text = "Sam comments: \"Hey, Katerine - how are you?\"" },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(16), EventType = EventTypeEnum.HighFive, Text = "Katerine high-fives Sam.", HighFivedFrom = "Katerine", HighFivedTo = "Sam" },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(17), EventType = EventTypeEnum.HighFive, Text = "Kate high-fives Dona.", HighFivedFrom = "Katerine", HighFivedTo = "Dona" },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(18), EventType = EventTypeEnum.LeftRoom, Text = "Sam leaves" },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(20), EventType = EventTypeEnum.Comment, Text = "Katerine comments: \"So, cool\"" },
                new Message() { CreatedAt = createdDateTime.AddHours(1).AddMinutes(21), EventType = EventTypeEnum.LeftRoom, Text = "Katerine leaves" },

                new Message() { CreatedAt = createdDateTime.AddHours(2), EventType = EventTypeEnum.EnteredRoom, Text = "James enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(5), EventType = EventTypeEnum.EnteredRoom, Text = "Tina enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(5), EventType = EventTypeEnum.EnteredRoom, Text = "Paul enters the room." },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(15), EventType = EventTypeEnum.Comment, Text = "James comments: \"Hey, Tina - how was your trip?\"" },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(16), EventType = EventTypeEnum.HighFive, Text = "James high-fives Paul.", HighFivedFrom = "James", HighFivedTo = "Paul" },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(17), EventType = EventTypeEnum.HighFive, Text = "Tina high-fives Paul.", HighFivedFrom = "Tina", HighFivedTo = "Paul" },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(18), EventType = EventTypeEnum.LeftRoom, Text = "James leaves" },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(20), EventType = EventTypeEnum.Comment, Text = "Tina comments: \"It was awesome!\"" },
                new Message() { CreatedAt = createdDateTime.AddHours(2).AddMinutes(21), EventType = EventTypeEnum.LeftRoom, Text = "Tina leaves" }
            };

            return messages;
        }
    }
}
