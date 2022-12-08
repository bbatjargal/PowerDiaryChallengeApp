# PowerDiaryChallengeApp
A console application to view chat history at varying levels of time-based aggregation.

# Design principles

- SOLID

# Dependency

- `.NET6.0`
- `Ensure.That - 10.1.0`
- `Microsoft.Extensions.DependencyInjection - 7.0.0`
- `Microsoft.Extensions.Logging.Console - 6.0.0`

# Clone the repository

1. `git clone https://github.com/bbatjargal/PowerDiaryChallengeApp.git`

# To run the console application

1. `cd PowerDiaryChallengeApp`
1. `dotnet restore`
1. `dotnet build PowerDiaryChallengeApp.sln`
1. `dotnet publish -p:PublishProfile=FolderProfile`
1. `cd PowerDiaryChallenge\bin\Debug\net6.0\publish`
1. `PowerDiaryChallenge.exe`


# To run unit tests

1. `cd PowerDiaryChallengeApp`
1. `dotnet restore`
1. `dotnet test PowerDiaryChallenge.UnitTests\PowerDiaryChallenge.UnitTests.csproj`

# Project structure

| *№*| *Project*                      | *Directory* | *File name*               |  *Description* |
|--- |---                             |---          |---                             |---|
| 1. |  PowerDiaryChallenge           |  Enums      | EventTypeEnum.cs               |  Contains event type enums to represent message event types. | 
| 2. |                                |             |  GranularityEnum.cs            |  Contains granularity enums to represent an "aggregation level". |
| 3. |                                |  Helpers    |  Constants.cs                  | Contains constants.  |
| 4. |                                |             | DataHandler.cs                 |  Contains a data handler class to generate a list of messages. |
| 5. |                                |             |  IDataHandler.cs               | Contains a data handler interface to generate a list of messages.  |
| 6. |                                | Logics      | IMessageHistoryManager.cs      | Contains a manager interface to aggregate chat history based on a time-based granularity.  |
| 7. |                                |             | MessageHistoryManager.cs       | Contains a manager class to aggregate chat history based on a time-based granularity.  |
| 8. |                                |  Models     |  IMessage.cs                   | Contains a model interface to store a message.  |
| 9. |                                |             |  Message.cs                    |  Contains a model class to store a message. |
| 10.|                                |             | ChatEventViewerApp.cs          | Contains an application class to view chat history.  |
| 11.|                                |             | IChatEventViewerApp.cs         | Contains an application interface to view chat history.  |
| 12.|                                |             | Program.cs                     |  Contains the main entry to start the application. |
| 13.| PowerDiaryChallenge .UnitTests | Helpers     |  TestDataLoader.cs             |  Contains a helper function to load messages for a test run. |
| 14.|                                | Logics      | MessageHistoryManagerTests.cs  | Contains unit tests for MessageHistoryManager.  |