using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Ajf.RideShare.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        //[Test]
        //[Category("Selenium")]
        //public void TestMethod1()
        //{
        //    using (var chromeDriver = new ChromeDriver())
        //    {
        //        chromeDriver.Manage().Window.Maximize();
        //        chromeDriver.Navigate().GoToUrl("http://localhost/RideShare");
        //        var emailTextBox = chromeDriver.FindElementById("Email");
        //        emailTextBox.Clear();
        //        emailTextBox.SendKeys("frank@email.dk");

        //        var passwordTextBox = chromeDriver.FindElementById("Password");
        //        passwordTextBox.Clear();
        //        passwordTextBox.SendKeys("Frank1");
        //    }
        //}

        [Test]
        //[Category("Selenium")]
        public void TestMethod2()
        {
            Assert.Pass("This is good");
        }
    }
}