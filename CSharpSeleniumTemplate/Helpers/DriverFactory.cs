using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;

namespace CSharpSeleniumTemplate.Helpers
{
    public class DriverFactory
    {
        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {
            string browser = ConfigurationManager.AppSettings["browser"].ToString();
            string execution = ConfigurationManager.AppSettings["execution"].ToString();
            string seleniumHub = ConfigurationManager.AppSettings["seleniumHub"].ToString();

            if (INSTANCE == null)
            {
                switch (browser)
                {
                    case "chrome":
                        if (execution.Equals("local"))
                        {
                            ChromeOptions chrome = new ChromeOptions();
                            chrome.AddArgument("start-maximized");
                            chrome.AddArgument("--window-size=1920,1080");
                            chrome.AddArgument("enable-automation");
                            chrome.AddArgument("--no-sandbox");
                            chrome.AddArgument("--disable-infobars");
                            chrome.AddArgument("--disable-dev-shm-usage");
                            chrome.AddArgument("--disable-browser-side-navigation");
                            chrome.AddArgument("--disable-gpu");
                            chrome.AddArgument("--headless");
                            chrome.PageLoadStrategy = PageLoadStrategy.Normal;
                            INSTANCE = new ChromeDriver(chrome);
                        }

                        if (execution.Equals("remota"))
                        {
                            ChromeOptions chrome = new ChromeOptions();
                            chrome.AddArgument("no-sandbox");
                            chrome.AddArgument("--allow-running-insecure-content");
                            chrome.AddArgument("--lang=pt-BR");
                            chrome.AddArgument("--window-size=1920,1080");
                            //chrome.AddArgument("maxInstances=5");

                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), chrome.ToCapabilities());
                        }

                        break;

                    case "ie":
                        if (execution.Equals("local"))
                        {
                            #region implement capabilities
                            //new line code
                            //DesiredCapabilities ie = new DesiredCapabilities();

                            //DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorerOptions();
                            //InternetExplorerOptions ieOptions = new InternetExplorerOptions();

                            //capabilities.setCapability(InternetExplorerDriver.INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS, true);

                            //ie.setCapability(CapabilityType.ForSeleniumServer.ENSURING_CLEAN_SESSION, true);
                            //ieOptions.setCapability(InternetExplorerDriver.ENABLE_PERSISTENT_HOVERING, true);
                            //ieOptions.EnableNativeEvents("requireWindowFocus", true);

                            //desiredcapabilities capabilities = new desiredcapabilities().;
                            //desiredcapabilities capabilities = new desiredcapabilities.internetexploreroptions();

                            //capabilities.SetCapability("requireWindowFocus", true);
                            //capabilities.SetCapability(InternetExplorerDriver.IGNORE_ZOOM_SETTING, false);
                            //capabilities.SetCapability("ie.ensureCleanSession", true);
                            //capabilities.SetCapability(InternetExplorerDriver.INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS, true);
                            //capabilities.SetCapability(InternetExplorerDriver.FORCE_CREATE_PROCESS, true);
                            #endregion
                            
                            //exist line in projt
                            INSTANCE = new InternetExplorerDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            InternetExplorerOptions ie = new InternetExplorerOptions();
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), ie.ToCapabilities());
                        }

                        break;

                    case "firefox":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new FirefoxDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            FirefoxOptions firefox = new FirefoxOptions();
                            firefox.SetPreference("intl.accept_languages", "pt-BR");
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), firefox.ToCapabilities());
                        }

                        break;

                    case "edge":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new EdgeDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            EdgeOptions edge = new EdgeOptions();
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), edge.ToCapabilities());
                        }

                        break;

                    case "opera":
                        if (execution.Equals("local"))
                        {
                            INSTANCE = new OperaDriver();
                        }

                        if (execution.Equals("remota"))
                        {
                            OperaOptions opera = new OperaOptions();
                            INSTANCE = new RemoteWebDriver(new Uri(seleniumHub), opera.ToCapabilities());
                        }

                        break;

                    default:
                        throw new Exception("O browser informado não existe ou não é suportado pela automação");
                }
            }
        }

        public static void QuitInstace()
        {
            INSTANCE.Quit();
            INSTANCE.Dispose();
            INSTANCE = null;
        }
    }
}
