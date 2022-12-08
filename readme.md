# PowerDiaryChallengeApp
A console application to view chat history at varying levels of time-based aggregation.

#Dependency

- `.NET6.0`
- `Ensure.That - 10.1.0`
- `Microsoft.Extensions.DependencyInjection - 7.0.0`
- `Microsoft.Extensions.Logging.Console - 6.0.0`

# Get up and running

1. `git clone https://github.com/bbatjargal/PowerDiaryChallengeApp.git`
1. `cd PowerDiaryChallengeApp`
1. `dotnet restore`
1. `dotnet build PowerDiaryChallengeApp.sln`
1. `dotnet publish -p:PublishProfile=FolderProfile`
1. `cd PowerDiaryChallenge\bin\Debug\net6.0\publish`
1. `PowerDiaryChallenge.exe`