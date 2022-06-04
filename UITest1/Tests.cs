using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    //[TestFixture(Platform.Android)]
   // [TestFixture(Platform.iOS)]
    public class Tests
    {
        private MainPage mainpage;
        private MainActivity mainact;
      
      /*  IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }*/
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


    }
}
