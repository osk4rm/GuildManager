using FluentAssertions;
using GuildManager_WebApp.Pages.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_UnitTests
{
    public class DashTests
    {
        [Theory]
        [InlineData("2023-02-20", "StartDate>2023-02-15,StartDate<2023-02-22")]
        [InlineData("2023-02-22", "StartDate>2023-02-22,StartDate<2023-03-01")]
        [InlineData("2023-02-24", "StartDate>2023-02-22,StartDate<2023-03-01")]
        [InlineData("2023-02-25", "StartDate>2023-02-22,StartDate<2023-03-01")]
        [InlineData("2023-02-26", "StartDate>2023-02-22,StartDate<2023-03-01")]
        public void CalculateThisWeekFilter_ReturnsCorrectFilter(string currentDate, string expectedFilter)
        {
            // Arrange
            var now = DateTime.Parse(currentDate);

            // Act
            var dash = new Dash();
            var result = dash.CalculateThisWeekFilter(now);

            // Assert
            result.Should().Be(expectedFilter);
        }
    }
}
