using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        string login = "";
        string password = "";
        string passwordRep = "";
        public string WebAPIKey = "AIzaSyBc7kRqN2BXIn1GsFHOA_k3645EqYa09Hs";

       // FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://userdb-5ea3f-default-rtdb.europe-west1.firebasedatabase.app/");

        FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://myproject123-acbb2-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<LogPas> lg { get; set; } = new ObservableCollection<LogPas>();
        public Register()
        {
            InitializeComponent();
            myLog.Text = Resource.LoginText;
            myPas.Text = Resource.PasText;
            myRepPas.Text = Resource.RepPas;
            myReg.Text = Resource.Reg;
        }
        async void OnButtonClickedReg(object sender, EventArgs e)
        {

            login = labelLog.Text;
            password = labelPass.Text;
            passwordRep = labelPassRep.Text;
            BindingContext = this;
            if (login != null && password != null& passwordRep!=null && password==passwordRep)
            {
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(login, password);
                    string gettoken = auth.FirebaseToken;
                  var collect=  firebaseClient.Child("Users").PostAsync(new LogPas { Login=login, Password=password});
                 
                  var collect1 = firebaseClient
                        .Child("Users")
                        .AsObservable<LogPas>()
                        .Subscribe((dbevent) => { 
                        if (dbevent.Object !=null)
                            {
                                lg.Add(dbevent.Object);
                            }
                        });
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                }

            }
        }
    }



    public class LogPas { 
         public string Login { get; set; }
         public string Password { get; set; }
    
    
    }
}