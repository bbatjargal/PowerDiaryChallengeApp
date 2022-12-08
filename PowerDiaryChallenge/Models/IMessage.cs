// -------------------------------------------------------------------------------------------------
// FileName: IMessage.cs
// Description: Contains a model interface to store a message.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------
        
using PowerDiaryChallenge.Enums;

namespace PowerDiaryChallenge.Models
{
    /// <summary>
    /// Model to store a message.
    /// </summary>
    public interface IMessage
    {
        DateTime CreatedAt { get; set; }
        string Text { get; set; }
        EventTypeEnum EventType { get; set; }
        string HighFivedFrom { get; set; }
        string HighFivedTo { get; set; }
    }
}
