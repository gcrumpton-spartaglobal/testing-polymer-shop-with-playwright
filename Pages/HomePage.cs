using Microsoft.Playwright;

namespace testing_polymer_shop_with_playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly ILocator _shopHome;
        private readonly ILocator _mensOuterwearNavBarLink;
        private readonly ILocator _ladiesOuterwearNavBarLink;
        private readonly ILocator _mensTShirtsNavBarLink;
        private readonly ILocator _ladiesTShirtsNavBarLink;

        public HomePage(IPage page)
        {
            _page = page;
            _shopHome = _page.GetByRole(AriaRole.Link, new() { Name = "SHOP home" });
            _mensOuterwearNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Men's Outerwear" });
            _ladiesOuterwearNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Ladies Outerwear" });
            _mensTShirtsNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Men's T-Shirts" });
            _ladiesTShirtsNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Ladies T-Shirts" });
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://shop.polymer-project.org/");
        }

        public async Task<string> TitleAsync()
        {
            return await _page.TitleAsync();
        }

        public async Task ClickShopHomeAsync()
        {
            await _shopHome.ClickAsync();
        }

        public async Task ClickNavBarLinkAsync(string navBarOptionText)
        {
            switch (navBarOptionText)
            {
                case "Men's Outerwear":
                    await _mensOuterwearNavBarLink.ClickAsync();
                    break;

                case "Ladies Outerwear":
                    await _ladiesOuterwearNavBarLink.ClickAsync();
                    break;

                case "Men's T-Shirts":
                    await _mensTShirtsNavBarLink.ClickAsync();
                    break;

                case "Ladies T-Shirts":
                    await _ladiesTShirtsNavBarLink.ClickAsync();
                    break;

                default:
                    throw new ArgumentException($"No navigation link found for: {navBarOptionText}", nameof(navBarOptionText));
            }
        }
    }
}
