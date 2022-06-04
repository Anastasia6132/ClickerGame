using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClickerGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Store : ContentPage
    {
        public static int moneycount = MainActivity.moneycount;
        public int money = 1; //Просто единица, на нее не смотреть
        public static int multiply = MainActivity.multiply;

        int descCost = 10;
        public Store()
        {

            int nextmult = multiply + 1;
            InitializeComponent();
            labelMoney.Text = MainActivity.moneycount.ToString() + " G";
            labelMult.Text = "Multiply: " + nextmult.ToString() + " G";
            labelCost.Text = "Cost: " + descCost.ToString() +" G";
            curMult.Text = "Current multiply: " + MainActivity.multiply.ToString() + " G";

        }

        async void OnButtonClickedBuyUp(object sender, EventArgs e)
        {
            if (MainActivity.moneycount >= descCost)
            {
                int nextmult = multiply + 1;
                MainActivity.multiply += 1;
                MainActivity.moneycount -= descCost;              
                money = MainActivity.moneycount;               
                labelMoney.Text = MainActivity.moneycount.ToString() + " G";
                labelMult.Text = "Multiply: "+nextmult.ToString() + " G";
                labelCost.Text = "Cost: "+ descCost.ToString() + " G";
                curMult.Text = "Current multiply: " + MainActivity.multiply.ToString() + " G";

            }
        }
    }
}