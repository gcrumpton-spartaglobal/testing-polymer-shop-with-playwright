using Microsoft.Playwright;
using Xunit;

namespace testing_polymer_shop_with_playwright
{
    public class SimpleTest
    {
        [Fact]
        public async Task CheckPolymerShopPageTitle()
        {
            // Arrange
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            // Act
            await page.GotoAsync("https://shop.polymer-project.org/");
            var title = await page.TitleAsync();
            // Assert
            Assert.Equal("Home - SHOP", title);
        }
    }
}
