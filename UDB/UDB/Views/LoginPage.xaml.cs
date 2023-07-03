using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDB.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UDB.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());

        }

       async void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<Person>().Where(u => u.FirstName.Equals(UserName.Text) && u.Password.Equals(UPassword.Text)).FirstOrDefault();
            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () => {

                    var result = await this.DisplayAlert("Failed", "Please Enter the Correct Credentials", "Ok", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                    else
                        await Navigation.PushAsync(new WelcomePage());

                });
            }
        }
    }
}