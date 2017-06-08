using System;
using OpenQA.Selenium;

namespace BrowserHistory.Tests.Pages
{
    internal class ChildIFrame : IDisposable
    {
        private readonly IWebDriver _driver;

        public ChildIFrame(IWebDriver driver)
        {
            _driver = driver.SwitchTo().Frame("child");
        }

        public void Dispose()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public IWebElement GetFirstNameField()
        {
            return _driver.FindElement(By.Name("firstName"));
        }

        public IWebElement GetSubmitButton()
        {
            return _driver.FindElement(By.Name("child_submit"));
        }

        public IWebElement GetResultField()
        {
            return _driver.FindElement(By.Name("child_result"));
        }

        public IWebElement GetInputField()
        {
            return _driver.FindElement(By.Name("child_another_field"));
        }
    }
}
