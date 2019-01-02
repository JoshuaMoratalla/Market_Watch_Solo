using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Market_Watch_Solo.Action;

namespace Market_Watch_Solo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
         

            if (Username.Text == null || Password.Text == null)
            {
                DisplayAlert("Empty Values", "Please Fill in all the the entries", "Return");
            } else
            {
                var Login_Result = new Login_Check(Username.Text, Password.Text);
                if (Login_Result.Validated)
                {
                    var checkoutput = Username.Text + " | " + Password.Text;

                    DisplayAlert("Success", "Credentials are : " + checkoutput, "return");

                } else
                {
                    DisplayAlert("Incorrect Credentials", Login_Result.URL, "Return");
                }
            }

        }
    }
}
