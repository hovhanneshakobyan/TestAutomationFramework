using CoreLayer.Driver;
using CoreLayer.Helper;
using OpenQA.Selenium;

namespace BusinessLayer
{
    public class MainPage
    {
        private IWebDriver Driver => DriverManager.Driver;

        // Main elements as per task requirements finding by locators
        private readonly By MenuButton = By.CssSelector("#react-burger-menu-btn");
        private readonly By HeaderLabel = By.CssSelector(".app_logo");
        private readonly By CartIcon = By.CssSelector(".shopping_cart_link");
        private readonly By SortingDropdown = By.CssSelector(".product_sort_container");
        private readonly By InventoryItems = By.CssSelector(".inventory_item");

        public bool IsAt()
        {
            Logger.Info("Verifying Main Page elements...");

            try
            {
                WaitHelper.WaitForElementVisible(Driver, MenuButton, 10);
                WaitHelper.WaitForElementVisible(Driver, HeaderLabel, 10);
                WaitHelper.WaitForElementVisible(Driver, CartIcon, 10);
                WaitHelper.WaitForElementVisible(Driver, SortingDropdown, 10);

                // at least one inventory item is present
                var items = Driver.FindElements(InventoryItems);
                bool hasInventoryItems = items.Count > 0;

                if (!hasInventoryItems)
                {
                    Logger.Warn("No inventory items found on Main Page");
                    return false;
                }

                Logger.Info($"Main Page verification successful. Found {items.Count} inventory items.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Main Page verification failed: {ex.Message}", ex);
                return false;
            }
        }
    }
}