using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedicineDirectoryMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void productCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductCategoryPage());
        }

        private async void assistanceButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssistancePage());
        }

        private async void eventButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventPage());
        }
    }
}
