// -------------------------------------------------------------------------------------------------
// FileName: IDataHandler.cs
// Description: Contains a data handler interface to generate a list of messages.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge.Helpers
{
    /// <summary>
    /// Interface for a Data Handler.
    /// </summary>
    public interface IDataHandler
    {
        /// <summary>
        /// Generates a list of messages.
        /// </summary>
        /// <returns>Returns a list of <see cref="IMessage"/>.</returns>
        IEnumerable<IMessage> GetMessage();
    }
}
