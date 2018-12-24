using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System;

namespace LBAuth
{
    [TestFixture]
    public class UnitTest1
    {
        public IWebDriver driver;
        XDocument xdoc = XDocument.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + "ENV.xml");
        Auth auth { set; get; }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            string url = xdoc.Element("conf").Element("url").Element("key").Attribute("url").Value;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [SetUp] // вызывается перед каждым тестом
        public void UnitTest()
        {
            auth = new Auth(driver, xdoc);
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            driver.Quit();
        }


        [Test()]
        public void AuthCorrectMail()
        {
            var actual = "9209";

            auth.AuthCorrectMail();

            Assert.AreEqual(auth.pruf, actual);
        }

        [Test]
        public void AuthFalseMail()
        {
            auth.AuthFalseMail();

            Assert.IsTrue(auth.res);
        }

        [Test]
        public void AuthEmptyData()
        {
            auth.AuthEmptyData();

            Assert.IsTrue(auth.res);
        }

        [Test]
        public void Demo()
        {
            var actual = "https://demo.litebox.ru/LITEBOX/";

            auth.DemoAuth();

            Assert.AreEqual(auth.pruf, actual);
        }

        [Test]
        public void DemoEmpty()
        {
            auth.DemoEmptyMail();

            Assert.IsTrue(auth.res);
        }
    }
}
