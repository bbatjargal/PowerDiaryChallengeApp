// -------------------------------------------------------------------------------------------------
// FileName: IChatEventViewerApp.cs
// Description: Contains an application class to view chat history.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using Microsoft.Extensions.Logging;
using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Logics;
using PowerDiaryChallenge.Models;

namespace PowerDiaryChallenge
{
    /// <inheritdoc />
    public class ChatEventViewerApp : IChatEventViewerApp
    {
        // private const int SLEEP_TIMEOUT_IN_SECONDS = 1;

        private IDataHandler _dataHandler;
        private IAggregation _aggregationMinutely;
        private IAggregation _aggregationHourly;
        private IEnumerable<IMessage>? _messages;
        private ILogger<IChatEventViewerApp> _logger;

        public ChatEventViewerApp(IDataHandler dataHandler,
            IEnumerable<IAggregation> aggregationServices,
            ILogger<IChatEventViewerApp> logger)
        {
            _dataHandler = dataHandler;
            _logger = logger;

            _aggregationMinutely = aggregationServices.FirstOrDefault(s => s.GetType() == typeof(AggregationMinutely))!;
            _aggregationHourly = aggregationServices.FirstOrDefault(s => s.GetType() == typeof(AggregationHourly))!;

            EnsureArg.IsNotNull(_aggregationMinutely, nameof(_aggregationMinutely));
            EnsureArg.IsNotNull(_aggregationHourly, nameof(_aggregationHourly));
        }

        /// <inheritdoc />
        public async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                _messages = _dataHandler.GetMessage();
                if (_messages.Count() == 0)
                {
                    _logger.LogInformation("There are 0 message. Exiting the application.");
                    return;
                }

                Console.WriteLine("Starting the PowerDiaryChallenge App. Please use the Ctrl+C key to stop.");
                Console.WriteLine($"There are {_messages.Count()} message(s).");

                bool keepLooping = true;
                while (!cancellationToken.IsCancellationRequested && keepLooping)
                {
                    // Thread.Sleep(TimeSpan.FromSeconds(SLEEP_TIMEOUT_IN_SECONDS));

                    Console.WriteLine("====================================================");
                    Console.WriteLine("Please type your granularity to see message history.");
                    Console.WriteLine("Command texts:  minutely, hourly, or exit;");
                    Console.WriteLine("====================================================");

                    Console.Write("Command: ");
                    string? option = Console.ReadLine();
                    switch (option?.ToLower())
                    {
                        case "minutely":
                            Console.WriteLine("You selected the granularity as Minutely.");
                            var groupedMessagesMinutely = await _aggregationMinutely.AggregateAsync(_messages, cancellationToken);
                            DisplayMessages(groupedMessagesMinutely);
                            break;
                        case "hourly":
                            Console.WriteLine("You selected the granularity as Hourly.");
                            var groupedMessagesHourly = await _aggregationHourly.AggregateAsync(_messages, cancellationToken);
                            DisplayMessages(groupedMessagesHourly);
                            break;
                        case "exit":
                            keepLooping = false;
                            Console.WriteLine("Exiting the application.");
                            break;
                        default:
                            Console.WriteLine("Please type one of the following:  minutely, hourly, or exit;");
                            Console.WriteLine(Environment.NewLine);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while running the {nameof(ChatEventViewerApp)} application.");
            }
            return;
        }
        
        private static void DisplayMessages(IReadOnlyDictionary<string, IList<IMessage>> groupedMessages)
        {
            foreach (string groupKey in groupedMessages.Keys)
            {
                Console.Write(groupKey + ":");
                for (int i = 0; i < groupedMessages[groupKey].Count; i++)
                {
                    Console.Write(new String(' ', i == 0 ? 1 : groupKey.Length + 2));
                    Console.WriteLine(groupedMessages[groupKey][i].Text);
                }
            }
        }
    }
}
