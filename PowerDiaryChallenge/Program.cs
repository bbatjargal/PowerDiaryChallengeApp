// -------------------------------------------------------------------------------------------------
// FileName: Program.cs
// Description: Contains the main entry to start the application.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Logics;

namespace PowerDiaryChallenge
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            // Setup DI.
            var serviceCollection = new ServiceCollection()
                .AddLogging(configure => { configure.AddConsole(); })
                .AddSingleton<IDataHandler, DataHandler>()
                .AddSingleton<IAggregation, AggregationMinutely>()
                .AddSingleton<IAggregation, AggregationHourly>()
                .AddTransient<IChatEventViewerApp, ChatEventViewerApp>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Start the application.
            var chatEventViewerApp = serviceProvider.GetRequiredService<IChatEventViewerApp>();
            await chatEventViewerApp.RunAsync(CancellationToken.None);
        }
    }
}