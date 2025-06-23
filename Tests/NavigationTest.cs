using Microsoft.Playwright;
using Xunit;
using testing_polymer_shop_with_playwright.Pages;

namespace testing_polymer_shop_with_playwright.Tests
{
    public class NavigationTest
    {
        [Fact]
        public async Task CheckHomePageTitle()
        {
            // Arrange
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = new HomePage(await browser.NewPageAsync());
            // Act
            await page.GotoAsync();
            var title = await page.TitleAsync();
            // Assert
            Assert.Equal("Home - SHOP", title);
        }
    }
}
