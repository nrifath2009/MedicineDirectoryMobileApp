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
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer",
                    Name = "Product " + i,
                    ImageUrl = "https://cdn.mos.cms.futurecdn.net/GazNjf2Z9LLmxnVPHpSTk4-480-80.jpg",
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

            var categoryProducts =  products.Where(c => c.CategoryId == selectedCategoryId);
            productListTable.ItemsSource = categoryProducts;
            //foreach (var item in categoryProducts)
            //{
            //    ImageCell imageCell = new ImageCell
            //    {
            //        DetailColor = Color.Black,
            //        TextColor = Color.Black,
            //        ImageSource = item.ImageUrl,
            //        Text = item.Name,
            //        Detail = item.Description
            //    };

            //}


        }

        private async void ImageCell_Tapped(object sender, EventArgs e)
        {
            var imageCell =  sender as ImageCell;
            if (imageCell != null)
            {
                var selectedProduct = imageCell.BindingContext as Product;
                if (selectedProduct != null)
                {
                    await Navigation.PushAsync(new ProductDetailPage(selectedProduct));
                }
            }
        }
    }
}