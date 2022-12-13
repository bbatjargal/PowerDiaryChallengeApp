# PowerDiaryChallengeApp
A console application to view chat history at varying levels of time-based aggregation.

# Design principles

- **SOLID**
- *Single-responsibility Principle (SRP)* - A class should have one and only one reason to change, meaning that a class should have only one job.
- *Open-closed Principle (OCP)* - Objects or entities should be open for extension but closed for modification.
- *Liskov Substitution Principle (LSP)* - Objects of a superclass shall be replaceable with objects of its subclasses without changing the behavior of the application.
- *Interface segregation principle (ISP)* - A client should never be forced to implement an interface that it doesn’t use, or clients shouldn’t be forced to depend on methods they do not use.
- *Dependency inversion principle (DIP)* - Entities must depend on abstractions, not on concretions. It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.

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
| 9.|                                | Logics      | IAggregation.cs      | Contains a aggregation interface to aggregate chat history based on a time-based granularity.  |
|10.|                                |             | AggregationHourly.cs       | Contains an aggregation class to aggregate chat history hourly.  |
|10.|                                |             | AggregationMinutely.cs      | Contains an aggregation class to aggregate chat history minutely.  |
|11.|                                |  Models     |  IMessage.cs                   | Contains a model interface to store a message.  |
|12.|                                |             |  Message.cs                    |  Contains a model class to store a message. |
|12.|                                |  Utils      |  AggregationUtil.cs            |  Contains a class which provides utility functions. |
|13.| PowerDiaryChallenge .UnitTests | Helpers     |  TestDataLoader.cs             |  Contains a helper function to load messages for a test run. |
|14.|                                | Logics      | MessageHistoryManagerTests.cs  | Contains unit tests for MessageHistoryManager.  |

# Area of improvements

**In terms of design:**

- To segregate MessageHistoryManager class into different aggregate classes.
- To add async.
- To add events and delegate.
- To add multi-threads.

**In terms of data access components:**

- Adds ORM functionality. (EF, Dapper, or ADO.NET).
- Read from files.

**In terms of functionalities:**

- Add different views like Yearly, Monthly, Daily, and Minutely or Hourly for a particular day.

**In terms of UI clients:**

- Adds a single-page application (SPA) UI using front-end frameworks like React UI or mobile.


