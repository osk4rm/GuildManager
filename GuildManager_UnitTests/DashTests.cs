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
        [Fact]
        public void CalculateThisWeekFilter_ReturnsCorrectFilter()
        {
            // Arrange
            var expectedStartDate = DateTime.Now.AddDays(((int)DayOfWeek.Wednesday - (int)DateTime.Now.DayOfWeek + 7) % 7 - 7).Date;
            var expectedEndDate = expectedStartDate.AddDays(7).Date;
            var expectedFilter = $"StartDate>{expectedStartDate.ToString("yyyy-MM-dd")},StartDate<{expectedEndDate.ToString("yyyy-MM-dd")}";

            // Act
            Dash dash = new Dash();
            var result = dash.CalculateThisWeekFilter();

            // Assert
            result.Should().Be(expectedFilter);
        }
    }
}
