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
    public partial class ProductListPage : ContentPage
    {
        private List<Product> products = new List<Product>();
        private int selectedCategoryId = 0;
        public ProductListPage(int categoryId)
        {
            InitializeComponent();
            BuildProductList();
            selectedCategoryId = categoryId;
            LoadCategoryWiseProduct();
        }

        private void BuildProductList()
        {
            Random random = new Random();
            for (int i = 1; i < 60; i++)
            {
                Product product = new Product
                {
                    Description = "Simple Description",
                    Name = "Product " + i,
                    Id = i,
                    CategoryId = random.Next(1, 30)
                };
                products.Add(product);
            }
        }

        private void LoadCategoryWiseProduct()
        {
            StackLayout categoryStackLayout = new StackLayout
            {
                Padding = 10
            };

            foreach (var item in products.Where(c => c.CategoryId == selectedCategoryId))
            {
                Button categoryBtn = new Button
                {
                    Text = item.Name,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 16,
                    TextColor = Color.FromHex("0F0F1E"),
                    BackgroundColor = Color.FromHex("FFF")
                };
                categoryStackLayout.Children.Add(categoryBtn);
            }

            productScrollView.Content = categoryStackLayout;
        }
    }
}