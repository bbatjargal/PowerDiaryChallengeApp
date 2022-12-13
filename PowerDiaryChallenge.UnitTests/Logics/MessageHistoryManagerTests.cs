﻿// -------------------------------------------------------------------------------------------------
// FileName: MessageHistoryManagerTests.cs
// Description: Contains unit tests for MessageHistoryManager.
// Created on 12/08/2022 by Batjargal Bayarsaikhan.
// -------------------------------------------------------------------------------------------------

using PowerDiaryChallenge.Helpers;
using PowerDiaryChallenge.Logics;
using PowerDiaryChallenge.UnitTests.Helpers;

namespace PowerDiaryChallenge.UnitTests.Logics
{

    /// <summary>
    /// Unit tests to validate the functionality of <see cref="MessageHistoryManager"/> class.
    /// </summary>
    public class MessageHistoryManagerTests
    {
        private readonly IAggregation aggregationMinutely;
        private readonly IAggregation aggregationHourly;
        private readonly DateTime TestStartDateTime = new DateTime(2022, 12, 8, 7, 5, 35);

        public MessageHistoryManagerTests()
        {
            aggregationMinutely = new AggregationMinutely();
            aggregationHourly = new AggregationHourly();
        }

        [Fact]
        public async void GivenTheMessages_WhenGetMessagesByMinute_ThenMessagesShouldBeAggregatedByMinute()
        {
            // Arrange
            var initialMessages = TestDataLoader.GetMessage(TestStartDateTime);
            var expected = new List<string>()
            {
                TestStartDateTime.ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(5).ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(15).ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(17).ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(18).ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(20).ToString(Constants.DateTimeFormatByMinute),
                TestStartDateTime.AddMinutes(21).ToString(Constants.DateTimeFormatByMinute),
            };

            // Act
            var actual = await aggregationMinutely.AggregateAsync(initialMessages, CancellationToken.None);

            // Assert
            Assert.Equal(expected.Count, actual.Count);
            Assert.True(actual.Keys.ToList().SequenceEqual(expected));
        }

        [Fact]
        public async void GivenTheMessages_WhenGetMessagesByHour_ThenMessagesShouldBeAggregatedByHour()
        {
            // Arrange  
            var initialMessages = TestDataLoader.GetMessage(TestStartDateTime);
            var expected = new List<string>() 
            { 
                TestStartDateTime.ToString(Constants.DateTimeFormatByHour) 
            };

            // Act
            var actual = await aggregationHourly.AggregateAsync(initialMessages, CancellationToken.None);

            // Assert
            Assert.Equal(expected.Count, actual.Count);
            Assert.True(actual.Keys.ToList().SequenceEqual(expected));
        }
    }
}
