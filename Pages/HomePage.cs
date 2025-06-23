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
    }
}
