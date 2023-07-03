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
using UDB.Views;
using Xamarin.Essentials;

namespace UDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        public void btn1(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<Person>();

            var item = new Person()
            {
                FirstName = UserFirstName.Text,
                LastName = UserLastName.Text,
                DateOfBirth= Dofb.Text,
                Gender = Gender.Text,
                Address = address.Text,
                Email = mail.Text,
                Password= password.Text,
                ConfirmPassword= confirmpassword.Text
            };
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {

                var result = await this.DisplayAlert("Successfull", "Your Registration is Success", "Ok", "Cancel"); 
                
                if(result)
                    await Navigation.PushAsync(new LoginPage());
            });
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}