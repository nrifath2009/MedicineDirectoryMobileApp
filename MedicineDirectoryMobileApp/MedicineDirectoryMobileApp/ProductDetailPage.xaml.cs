using MedicineDirectoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicineDirectoryMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {   
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            this.BindingContext = product;
        }
    }
}