# PowerDiaryChallengeApp
A console application to view chat history at varying levels of time-based aggregation.

#Dependency

1. > .NET6.0
1. > Ensure.That - 10.1.0
2. > Microsoft.Extensions.DependencyInjection - 7.0.0
3. > Microsoft.Extensions.Logging.Console - 6.0.0

# Get up and running

1. > git clone https://github.com/bbatjargal/PowerDiaryChallengeApp.git
2. > cd PowerDiaryChallengeApp
3. > dotnet restore
4. > dotnet build PowerDiaryChallengeApp.sln
5. > dotnet publish -p:PublishProfile=FolderProfile
6. > cd PowerDiaryChallenge\bin\Debug\net6.0\publish
7. > PowerDiaryChallenge.exe