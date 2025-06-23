using Microsoft.Playwright;

namespace testing_polymer_shop_with_playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private readonly ILocator _shopHome;

        public HomePage(IPage page)
        {
            _page = page;
            _shopHome = _page.GetByRole(AriaRole.Link, new() { Name = "SHOP home" });
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
    }
}
