using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ClickerGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainActivity : ContentPage
    {
        public static BaseDatos DB;
        string dbFile = "SongsDB.db3";
        string login1 = "";
        string password = "";
        public static int moneycount = 0;
        public int money = 1; //Просто единица, на нее не смотреть
        public static int multiply = 1;
        string dbPath = Path.Combine(
     Environment.GetFolderPath(Environment.SpecialFolder.Personal),
     "friends2.db");

        public MainActivity() { }
        public MainActivity(string login,string password)
        {

            this.login1 = login;
            this.password = password;

        
            // dbpr = App.Database.GetItem(login);
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // var dbPath = System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, dbFile);
            //DB = new BaseDatos(dbPath);
            InitializeComponent();
            var db = new SQLiteConnection(dbPath);
           // db.CreateTable<DBProgress>();
            var stocksStartingWithA = db.Query<DBProgress>("SELECT * FROM Items WHERE login = ?", login1);
            foreach (var s in stocksStartingWithA)
            {
                moneycount = s.balance;
                multiply = s.upgr;
            }

            labelMoney.Text = moneycount.ToString()+" G";
        }
        async void OnButtonClickedClick (object sender, EventArgs e)
        {
            moneycount = mcount(money,multiply,moneycount);
            labelMoney.Text =Convert.ToString( moneycount)+" G";
        }


        public int mcount(int money, int multiply, int moneycount) { return money * multiply + moneycount; }
        async void OnButtonClickedStore(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Store(), true);
        }

        async void OnButtonClickedMap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GMap(), true);
        }

        async void OnButtonClickedSave(object sender, EventArgs e)
        {

            //работа с бд
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<DBProgress>();
            var stocksStartingWithA = db.Query<DBProgress>("SELECT * FROM Items WHERE login = ?",login1);
               foreach (var s in stocksStartingWithA)
               {
                   Console.WriteLine("a " + s.login);
               }
            DBProgress dbpr = new DBProgress();
            dbpr.login = login1;
            dbpr.balance = moneycount;
            dbpr.upgr = multiply;
            if (stocksStartingWithA.Count == 0){
                db.Insert(dbpr);
            }
            else
            {
                var stocksStartingWithA1 = db.Query<DBProgress>("UPDATE Items set balance=?,upgr=? WHERE login = ?", moneycount, multiply,login1);              
            }         

        }
    }
}