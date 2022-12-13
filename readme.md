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

|*№*| *Project*                      | *Directory* | *File name*                    |  *Description* |
|---|---                             |---          |---                             |---|
| 1.|   PowerDiaryChallenge          |     -       | ChatEventViewerApp.cs          | Contains an application class to view chat history.  |
| 2.|                                |             | IChatEventViewerApp.cs         | Contains an application interface to view chat history.  |
| 3.|                                |             | Program.cs                     |  Contains the main entry to start the application. |
| 4.|                                |  Enums      | EventTypeEnum.cs               |  Contains event type enums to represent message event types. | 
| 5.|                                |             |  GranularityEnum.cs            |  Contains granularity enums to represent an "aggregation level". |
| 6.|                                |  Helpers    |  Constants.cs                  | Contains constants.  |
| 7.|                                |             | DataHandler.cs                 |  Contains a data handler class to generate a list of messages. |
| 8.|                                |             |  IDataHandler.cs               | Contains a data handler interface to generate a list of messages.  |
| 9.|                                | Logics      | IMessageHistoryManager.cs      | Contains a manager interface to aggregate chat history based on a time-based granularity.  |
|10.|                                |             | MessageHistoryManager.cs       | Contains a manager class to aggregate chat history based on a time-based granularity.  |
|11.|                                |  Models     |  IMessage.cs                   | Contains a model interface to store a message.  |
|12.|                                |             |  Message.cs                    |  Contains a model class to store a message. |
|13.| PowerDiaryChallenge .UnitTests | Helpers     |  TestDataLoader.cs             |  Contains a helper function to load messages for a test run. |
|14.|                                | Logics      | MessageHistoryManagerTests.cs  | Contains unit tests for MessageHistoryManager.  |

# Area of improvements

In terms of design:

1. To segregate MessageHistoryManager class into different aggregate classes.
2. To add async.
3. To add events and delegate.
4. To add multi-threads.

In terms of data access components:

1. Adds ORM functionality. (EF, Dapper, or ADO.NET).
2. Read from files.

In terms of functionalities:

1. Add different views like Yearly, Monthly, Daily, and Minutely or Hourly for a particular day.

In terms of UI clients:

1: Adds a single-page application (SPA) UI using front-end frameworks like React UI or mobile.


