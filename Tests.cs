using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;

namespace VotingApp
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void LoginTest1a_Correct() //poprawne logowanie
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("jan.kowalski@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsTrue(result == "https://localhost:44361/Default");
        }

        [TestMethod()]
        public void LoginTest1b_Fail_IncorrectMail() //logowanie - zly mail
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("janek.kowalski@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/Default");
        }

        [TestMethod()]
        public void LoginTest1c_Fail_IncorrectPassword() //logowanie - zle haslo
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("jan.kowalski@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("hasło");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/Default");
        }

        [TestMethod()]
        public void RegisterTest2a_Correct() //poprawna rejestracja
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("RegisterButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@student.up.krakow.pl");
            driver.FindElement(By.Id("MainContent_PasswordTxt")).SendKeys("Test123!");
            driver.FindElement(By.Id("MainContent_ConfirmPasswordTxt")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_RegisterButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsTrue(result == "https://localhost:44361/LoginAccount");
        }

        [TestMethod()]
        public void RegisterTest2b_IncorrectMail() //rejestracja - zly mail
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("RegisterButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@up.pl");
            driver.FindElement(By.Id("MainContent_PasswordTxt")).SendKeys("Test123!");
            driver.FindElement(By.Id("MainContent_ConfirmPasswordTxt")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_RegisterButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/LoginAccount");
        }

        [TestMethod()]
        public void RegisterTest2c_WeakPassword() //rejestracja - słabe hasło
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("RegisterButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak3@student.up.krakow.pl");
            driver.FindElement(By.Id("MainContent_PasswordTxt")).SendKeys("test");
            driver.FindElement(By.Id("MainContent_ConfirmPasswordTxt")).SendKeys("test");

            driver.FindElement(By.Id("MainContent_RegisterButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/LoginAccount");
        }

        [TestMethod()]
        public void RegisterTest2d_IncorrectConfirmPassword() //rejestracja - zle powtórzone hasło
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("RegisterButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak3@student.up.krakow.pl");
            driver.FindElement(By.Id("MainContent_PasswordTxt")).SendKeys("Test123!");
            driver.FindElement(By.Id("MainContent_ConfirmPasswordTxt")).SendKeys("test");

            driver.FindElement(By.Id("MainContent_RegisterButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/LoginAccount");
        }

        [TestMethod()]
        public void SendOpinion3a_Correct() //poprawne przesłanie opinii
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("MainContent_Opinion1")).SendKeys("Opinia testowa");
            driver.FindElement(By.Id("MainContent_RadioButtonList1_0")).Click();
            driver.FindElement(By.Id("MainContent_CheckboxList1_1")).Click();
            driver.FindElement(By.Id("MainContent_CheckboxList1_2")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("MainContent_SubmitButton1")).Click();
            Thread.Sleep(3000);

            String result = driver.FindElement(By.Id("MainContent_NotLoggedIn1")).Text;
            Assert.IsTrue(result.Contains("Dziękujemy za przesłanie opinii"));

        }

        [TestMethod()]
        public void SendOpinion3b_EmptyFields() //przesłanie opinii - puste pola
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("MainContent_SubmitButton2")).Click();
            Thread.Sleep(3000);

            String result = driver.FindElement(By.Id("MainContent_NotLoggedIn2")).Text;
            Assert.IsFalse(result.Contains("Dziękujemy za przesłanie opinii"));

        }

        [TestMethod()]
        public void CheckOpinion4a_Correct() //prawidłowe sprawdzanie opinii unikalnym kodem
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("MainContent_Code1")).SendKeys("d33232a021");
            driver.FindElement(By.Id("MainContent_CheckOpinionBtn1")).Click();

            String result = driver.FindElement(By.Id("MainContent_NotLoggedIn1")).Text;
            Assert.IsTrue(result.Contains("Opinia jest poprawnie zapisana"));

        }

        [TestMethod()]
        public void CheckOpinion4b_IncorrectCode() //sprawdzanie opinii - zły unikalny kod
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("LoginButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("marcin.nowak@student.up.krakow.pl");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("MainContent_Code1")).SendKeys("123456");
            driver.FindElement(By.Id("MainContent_CheckOpinionBtn1")).Click();

            String result = driver.FindElement(By.Id("MainContent_NotLoggedIn1")).Text;
            Assert.IsFalse(result.Contains("Opinia jest poprawnie zapisana"));

        }

        [TestMethod()]
        public void TeacherLogin5a_Correct() //prawidłowe logowanie prowadzącego 
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("TeacherButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("tomasz.nowak");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsTrue(result == "https://localhost:44361/TeacherDefault");
        }

        [TestMethod()]
        public void TeacherLogin5b_IncorrectLogin() //logowanie prowadzącego - złe dane
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://localhost:44361/Default";
            Thread.Sleep(2000);

            driver.FindElement(By.Id("TeacherButton")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("tomasz.nowakowski");
            driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Test123!");

            driver.FindElement(By.Id("MainContent_LoginButton")).Click();
            Thread.Sleep(2000);

            String result = driver.Url;
            Assert.IsFalse(result == "https://localhost:44361/TeacherDefault");
        }
    }
}