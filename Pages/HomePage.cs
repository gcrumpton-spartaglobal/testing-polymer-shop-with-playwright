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

        public HomePage(IPage page)
        {
            _page = page;
            _shopHome = _page.GetByRole(AriaRole.Link, new() { Name = "SHOP home" });
            _mensOuterwearNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Men's Outerwear" });
            _ladiesOuterwearNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Ladies Outerwear" });
            _mensTShirtsNavBarLink = _page.Locator("#tabContainer").GetByRole(AriaRole.Link, new() { Name = "Men's T-Shirts" });
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

        public async Task ClickMensOuterwearNavBarLinkAsync()
        {
            await _mensOuterwearNavBarLink.ClickAsync();
        }

        public async Task ClickLadiesOuterwearNavBarLinkAsync()
        {
            await _ladiesOuterwearNavBarLink.ClickAsync();
        }

        public async Task ClickMensTShirtsNavBarLinkAsync()
        {
            await _mensTShirtsNavBarLink.ClickAsync();
        }
    }
}
