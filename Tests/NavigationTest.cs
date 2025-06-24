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

        [Theory]
        [InlineData("Men's Outerwear")]
        [InlineData("Ladies Outerwear")]
        [InlineData("Men's T-Shirts")]
        [InlineData("Ladies T-Shirts")]
        public async Task CheckClickNavBarLink(string navBarOptionText)
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickNavBarLinkAsync(navBarOptionText);
            await Task.Delay(1000); // Wait for navigation to complete
            var title = await page.TitleAsync();

            // Assert
            Assert.Contains(navBarOptionText, title);
        }

        [Fact]
        public async Task CheckClickShoppingCartIcon()
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickShoppingCartIconAsync();
            await Task.Delay(1000); // Wait for navigation to complete
            var title = await page.TitleAsync();

            // Assert
            Assert.Equal("Your cart - SHOP", title);
        }

        [Theory]
        [InlineData("Men's Outerwear Shop Now")]
        [InlineData("Ladies Outerwear Shop Now")]
        [InlineData("Men's T-Shirts Shop Now")]
        [InlineData("Ladies T-Shirts Shop Now")]
        public async Task CheckClickShopNowButton(string ariaLabelText)
        {
            // Arrange
            var context = await Browser.NewContextAsync();
            var page = new HomePage(await context.NewPageAsync());

            // Act
            await page.GotoAsync();
            await page.ClickShopNowButtonAsync(ariaLabelText);
            await Task.Delay(1000); // Wait for navigation to complete
            var title = await page.TitleAsync();

            // Assert
            Assert.Contains(ariaLabelText.Replace("Shop Now", ""), title);
        }
    }
}
