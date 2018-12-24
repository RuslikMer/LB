using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace LBAuth
{
    class Auth
    {
        public IWebDriver driver { set; get; }
        public string pruf { set; get; }
        public bool res { set; get; }
        public string pass { set; get; }
        public string phone { set; get; }
        public string mail { set; get; }
        XDocument xdoc { set; get; }
        Helper help { set; get; }

        public Auth(IWebDriver driver, XDocument xdoc)
        {
            this.driver = driver;
            help = new Helper(driver);
            pass = xdoc.Element("conf").Element("pass").Element("key").Attribute("pass").Value;
            phone = xdoc.Element("conf").Element("phone").Element("key").Attribute("phone").Value;
            mail = xdoc.Element("conf").Element("mail").Element("key").Attribute("mail").Value;
            this.xdoc = xdoc;
        }

        public void AuthCorrectMail()
        {
            help.FindByNameSendkeys("email", mail);
            help.FindByNameSendkeys("password", pass);
            help.FindByIdClick("login-submit-btn");
            driver.Navigate().Refresh();

            pruf = help.FindByXpathText("//*[@class=\"UserID\"]/span");
        }

        public void AuthFalseMail()
        {
            help.FindByNameSendkeys("email", "litbox@rsvhr.com");
            help.FindByNameSendkeys("password", pass);
            help.FindByIdClick("login-submit-btn");

            try
            {
                var alert = help.FindByCss(".alert");
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
        }

        public void AuthEmptyData()
        {
            help.FindByIdClick("login-submit-btn");

            try
            {
                var alert = help.FindByCss(".input--filled");
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
        }

        public void DemoAuth()
        {
            help.FindByLinkTextClick("Демо-режим");
            help.FindByNameSendkeys("username", mail);
            help.FindByCssClick(".btn-block");
            driver.Navigate().Refresh();

            pruf = driver.SwitchTo().Window(driver.WindowHandles.ToList().Last()).Url;
        }

        public void DemoEmptyMail()
        {
            help.FindByLinkTextClick("Демо-режим");
            var pre = help.FindByName("username");
            help.FindByCssClick(".btn-block");
            var post = help.FindByName("username");

            if (pre != post)
            {
                res = true;
            }
            else
            {
                res = false;
            }
        }
    }
}
