using ClickerGame;
using NUnit.Framework;

namespace UnitTest
{

    public class AppInitializer

    {

        public static IApp StartApp(Platform platform)

        {

            if (platform == Platform.Android)

            {

                IApp iApp = ConfigureApp

                 .Android

                 .ApkFile("/Users/Documents/ProjectName/ProjectName.Android/bin/Release/ProjectName.apk")

                 //Apk file path    

                 .Debug()

                 .EnableLocalScreenshots()

                 .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

                return iApp;

            }

            else

            {

                IApp app = ConfigureApp

                .iOS

                .StartApp();

                return app;

            }

        }

    }


    public class Tests
    {
    



        private MainPage mainpage;
        private MainActivity mainact;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void formulaClick()
        {
            mainact = new MainActivity();
            int res = mainact.mcount(1, 2, 1);
            Assert.Pass("Formula: money * multiply + moneycount. Result " +res.ToString());
        }

        [Test]
        public void labelTest()
        {
            app.Query(c => c.Marked("MyButton"))
            mainact = new MainActivity();
           bool res = App.Ta
            Assert.Pass("Formula: money * multiply + moneycount. Result " + res.ToString());
        }
    }
}