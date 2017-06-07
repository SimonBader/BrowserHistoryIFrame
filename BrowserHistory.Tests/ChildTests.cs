using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BrowserHistory.Tests.Pages;
using OpenQA.Selenium.PhantomJS;

namespace BrowserHistory.Tests
{
    [TestClass]
    public class ChildTests

    {
        [TestMethod]
        public void ChildFormSubmitTest()
        {
            using (IWebDriver driver = new PhantomJSDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:8080/");
                IWebElement parentStartAction = driver.FindElement(By.Name("parent_start"));
                parentStartAction.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("ParentStart", StringComparison.OrdinalIgnoreCase));

                using (var child = new ChildIFrame(driver))
                {
                    const string testMessage = "Beate";
                    var inputField = child.GetFirstNameField();
                    inputField.SendKeys(testMessage);
                    var submitButton = child.GetSubmitButton();
                    submitButton.Click();

                    var resultField = child.GetResultField();
                    Assert.AreEqual(testMessage, resultField.GetAttribute("value"));
                }

                const string parentTestMessage = "parentMessage";
                IWebElement parentAnotherField = driver.FindElement(By.Name("parent_another_field"));
                parentAnotherField.SendKeys(parentTestMessage);
                Assert.AreEqual(parentTestMessage, parentAnotherField.GetAttribute("value"));

                using (var child = new ChildIFrame(driver))
                {
                    const string testMessage = "fill those out as well";
                    var inputField = child.GetInputField();
                    inputField.SendKeys(testMessage);
                    Assert.AreEqual(testMessage, inputField.GetAttribute("value"));
                }
            }
        }
    }
}
