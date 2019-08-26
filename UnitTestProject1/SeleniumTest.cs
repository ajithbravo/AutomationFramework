using System;
using System.Drawing;
using System.Drawing.Imaging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using ScreenShotDemo;

namespace UnitTestProject1
{
    [TestFixture]

    public class SeleniumTest
    {
        private TestContext textcontextinstance;
        public TestContext TestContext
        {
            get
            {
                return textcontextinstance;
            }
            set
            {
                textcontextinstance = value;
            }
        }


        IWebDriver driver;
     //  [Test]
        public void ChromeTesting()
        {
             driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.seleniumhq.org/");
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"D:\PracticeC\AutomationTestFramework\AutomationFramework\ScreenShot\screen.png", ImageFormat.Png);
            driver.Close();
            driver.Quit();

        }

      //  [Test]
        public void IETesting()
        {  // System.setProperty("webdriver.ie.driver", "D:\\Eclipse\\IEDriverServer.exe");


            driver = new InternetExplorerDriver();
            //driver.additional.capabilities ={ 'ignoreProtectedModeSettings':true,'ignoreZoomSetting':true,'nativeEvents':false,'acceptSslCerts':true}
            driver.Navigate().GoToUrl("https://www.seleniumhq.org/");            
            driver.Close();
            driver.Quit();          

        }
       
    }
}
