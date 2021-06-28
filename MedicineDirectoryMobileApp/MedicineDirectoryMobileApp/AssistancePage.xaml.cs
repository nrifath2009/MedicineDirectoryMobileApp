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
    public partial class AssistancePage : ContentPage
    {
        public AssistancePage()
        {
            InitializeComponent();
            BuildAreaList();
        }
        
        private void BuildAreaList()
        {
            List<Location> locations = new List<Location>();
            for (int i = 1; i < 20; i++)
            {
                areaPicker.Items.Add("Location "+i);
                //Location location = new Location
                //{
                //    Id = i,
                //    LocationName = "Location " + i
                //};
                //locations.Add(location);

            }
            
        }

        private void areaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //monkeyNameLabel.Text = picker.Items[selectedIndex];
            }
        }
    }
}