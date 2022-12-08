// -------------------------------------------------------------------------------------------------
// FileName: IChatEventViewerApp.cs
// Description: Contains an application interface to view chat history.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

namespace PowerDiaryChallenge
{
    /// <summary>
    /// Core application to view chat history at varying levels of time-based aggregation.
    /// </summary>
    public interface IChatEventViewerApp
    {
        /// <summary>
        /// Main function to start the application.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task Run(CancellationToken cancellationToken);
    }
}
