using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace AutomationTest
{

    public abstract class TestBase
    {

        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new PhantomJSDriver();           //FirefoxDriver();
            driver.Manage().Window.Maximize();
            OnOneTimeSetUp();
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine(@"Running {0}", GetTestName());
            OnSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            OnTearDown();
            string ResultTest = string.Empty;
            ResultTest = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            if (driver == null) return;

            try
            {
                //Here the code to capture javascipt errors
            }
            finally
            {
                if (ResultTest.Equals("Failed"))
                {
                    SendMessageEmail(GetTestName());
                    CaptureImage(ResultTest, string.Empty);
                }
            }
            Console.WriteLine(@"" + ResultTest + " {0}", GetTestName());
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OnOneTimeTearDown();
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
        }

        protected virtual void OnOneTimeSetUp()
        {
        }

        protected virtual void OnSetUp()
        {
        }

        protected virtual void OnTearDown()
        {
        }

        protected virtual void OnOneTimeTearDown()
        {
        }

        private static string GetTestName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }

        public string msgerror(string var1, string var2)
        {
            return "Error: the values " + var1 + " = " + var2 + " Should be equals";
        }

        private void CaptureImage(string folder, string captureName)
        {
            try
            {
                var captureDriver = driver as ITakesScreenshot;
                if (captureDriver != null)
                {
                    var screenshot = captureDriver.GetScreenshot();
                    var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, folder);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string captureSuffix = string.Empty;
                    if (!string.IsNullOrEmpty(captureName))
                    {
                        captureSuffix = "_" + captureName;
                    }

                    var filename = string.Format("{0}{1}.png", TestContext.CurrentContext.Test.FullName, captureSuffix);
                    screenshot.SaveAsFile(Path.Combine(path, filename), ImageFormat.Png);
                }
            }
            catch
            {
            }
        }

        public void SendMessageEmail(string match)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("kevinricar24@gmail.com");
            mail.To.Add("kevin.sejin@globant.com");
            mail.CC.Add("kevin.sejin@globant.com");
            mail.Subject = "Urgent !!! CNN NewSource page has been hacked";
            mail.Body = "Please verify the text from test " + match + " [" + DateTime.Now.ToString() + "]\nHere the link to verify " + GlobalsWords.URLPage;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("kevinricar24@gmail.com", "Ingesis#24");
            SmtpServer.EnableSsl = true;
            string value = string.Empty;
            try
            {
                SmtpServer.Send(mail);
                value = "The mail was sent successfully";
            }
            catch (Exception ex)
            {
                value = "Error sending mail, please verify the details:" + ex.Message;
            }
            Console.WriteLine(value);
        }

    }
}
