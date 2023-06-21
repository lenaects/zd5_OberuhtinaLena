using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd5_oberuhtina_2
{
    public partial class App :Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new Page1();
            MainPage = new NavigationPage(new Page1())
            {
                BarBackgroundColor = Color.FromHex("#2F2F2F"),
                BarTextColor = Color.White,
            };
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
