using MedicineDirectoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicineDirectoryMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductCategoryPage : ContentPage
    {
        ObservableCollection<ProductCategory> productCategories = new ObservableCollection<ProductCategory>();
        public ObservableCollection<ProductCategory> ProductCategories { get { return productCategories; } }
        public ProductCategoryPage()
        {
            InitializeComponent();
            //ProductCategoryView.ItemsSource = ProductCategories;

            for (int i = 0; i < 30; i++)
            {
                productCategories.Add(new ProductCategory { Id = 1, CategoryName = "Test Category "+(i+1) });
            }

            BuildLayout();
        }
        private void BuildLayout()
        {
            StackLayout categoryStackLayout = new StackLayout
            {
                Padding = 10
            };

            foreach (var item in ProductCategories)
            {
                Button categoryBtn = new Button
                {
                    Text = item.CategoryName,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 18,
                    HeightRequest=50,
                    TextColor = Color.FromHex("FFF"),
                    BackgroundColor = Color.FromHex("EB1C24")
                };
                categoryBtn.BindingContext = item;
                categoryBtn.Clicked += CategoryBtn_Clicked;
                categoryStackLayout.Children.Add(categoryBtn);
            }
            
            productCategoryScrollView.Content = categoryStackLayout;
        }

        private async void CategoryBtn_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var category =  button.BindingContext as ProductCategory;
                if (category != null)
                {
                    await Navigation.PushAsync(new ProductListPage(category.Id));
                }
            }
        }
    }
}