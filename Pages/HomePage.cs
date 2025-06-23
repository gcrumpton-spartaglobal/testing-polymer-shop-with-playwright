using Microsoft.Playwright;

namespace testing_polymer_shop_with_playwright.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync("https://shop.polymer-project.org/");
        }

        public async Task<string> TitleAsync()
        {
            return await _page.TitleAsync();
        }
    }
}
