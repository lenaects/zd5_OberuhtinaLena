using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd5_oberuhtina_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 :ContentPage
    {
        public Page1 ()
        {
            InitializeComponent();
            var welcomeLabel = new Label
            {
                StyleId = "header",
                Text = "Welcom",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var usernameEntry = new Entry
            {
                Placeholder = "Username",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "styleforIvansk"

            };

            var passwordEntry = new Entry
            {
                Placeholder = "Userpassword",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "styleforIvansk"
            };

            var rememberMeRadioButton = new RadioButton
            {
                Content = "Remember me",
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White,



            };

            var signInButton = new Button
            {
                Text = "Sign in",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var signInLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    rememberMeRadioButton,
                    signInButton,
                    new Label{ Text = "I forgot!", HorizontalOptions = LayoutOptions.End }
                }
            };

            var errorMessageLabel = new Label
            {
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center
            };




            signInButton.Clicked += (sender, e) =>
            {

                if (string.IsNullOrWhiteSpace(usernameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
                {
                    errorMessageLabel.Text = "Введите логин и пароль";
                } else
                {

                    string username = usernameEntry.Text;
                    string password = passwordEntry.Text;
                    Navigation.PushAsync(new MainPage(username));
                }
            };


            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(30),
                Children =
                {
                    welcomeLabel,
                    usernameEntry,
                    passwordEntry,
                    signInButton,
                    errorMessageLabel,
                    rememberMeRadioButton,
                    signInLayout,



                }
            };
            Content = stackLayout;
        }
    }
}