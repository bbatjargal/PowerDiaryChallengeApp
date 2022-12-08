// -------------------------------------------------------------------------------------------------
// FileName: Message.cs
// Description: Contains a model class to store a message.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Enums;

namespace PowerDiaryChallenge.Models
{
    /// <inheritdoc />
    public class Message : IMessage
    {
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; } = string.Empty;
        public EventTypeEnum EventType { get; set; }
        public string HighFivedFrom { get; set; } = string.Empty;
        public string HighFivedTo { get; set; } = string.Empty;
    }
}
