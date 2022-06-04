using ClickerGame;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        private MainPage mainpage;
        private MainActivity mainact;

        /*
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        
        */


        [Test]
        public void formulaClick()
        {
            mainact = new MainActivity();
            int res = mainact.mcount(1, 2, 1);
            Assert.Pass("Formula: money * multiply + moneycount. Result " + res.ToString());
        }
        [Test]
        public void testLogin()
        {
            mainpage = new MainPage();
           
        }

        [Test]
        public void testLabel()
        {
            mainpage = new MainPage();
            try
            {
                Assert.AreEqual("Login", mainpage.myLogTest);
                Assert.AreEqual("Password", mainpage.myPasTest);

            }
            catch
            {
                Assert.AreEqual("Логин", mainpage.myLogTest);
                Assert.AreEqual("Пароль", mainpage.myPasTest);
            }


        }
    }
}