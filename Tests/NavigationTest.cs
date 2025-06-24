using Microsoft.Playwright;
using Xunit;
using testing_polymer_shop_with_playwright.Pages;
using Microsoft.Playwright.Xunit;

namespace testing_polymer_shop_with_playwright.Tests
{
    public class NavigationTest : PageTest
    {
        // Property to hold the browser instance
        public IBrowser Browser { get; private set; }

        // Run this method before any tests in the class are run
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        }

        // Run this method after all tests in the class have run
        public override async Task DisposeAsync()
        {
            await base.DisposeAsync();
        }

        [Fact]
        public async Task CheckHomePageTitle()
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            var title = await page.TitleAsync();

            // Assert
            Assert.Equal("Home - SHOP", title);
        }

        [Fact]
        public async Task CheckClickShopHomeLink()
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickShopHomeAsync();
            var title = await page.TitleAsync();

            // Assert
            Assert.Equal("Home - SHOP", title);
        }

        [Fact]
        public async Task CheckClickMensOuterwearNavBarLink()
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickMensOuterwearNavBarLinkAsync();
            await Task.Delay(1000); // Wait for navigation to complete
            var title = await page.TitleAsync();

            // Assert
            Assert.Equal("Men's Outerwear - SHOP", title);
        }

        [Fact]
        public async Task CheckClickLadiesOuterwearNavBarLink()
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickLadiesOuterwearNavBarLinkAsync();
            await Task.Delay(1000); // Wait for navigation to complete
            var title = await page.TitleAsync();

            // Assert
            Assert.Equal("Ladies Outerwear - SHOP", title);
        }
    }
}
