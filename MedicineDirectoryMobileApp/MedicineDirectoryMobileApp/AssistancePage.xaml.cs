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
        List<Assistance> assistances = new List<Assistance>();
        public AssistancePage()
        {
            InitializeComponent();
            BuildAreaList();
            BuildAssistantList();
            assistanceDetailGrid.IsVisible = false;
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
                assistanceDetailGrid.IsVisible = true;
                var selectedLocation = picker.Items[selectedIndex];
                PopulateAssistanceOnSelectionChange(selectedLocation);
            }
        }
        private void BuildAssistantList()
        {            
            for (int i = 1; i < 20; i++)
            {
                Assistance assistance = new Assistance
                {
                    Id = i,
                    Name = "Assistance " + i,
                    Email=$"a{i}@mail.com",
                    Mobile="455456546546545",
                    LocationName = "Location " + i
                };
                assistances.Add(assistance);
            }
        }
        private void PopulateAssistanceOnSelectionChange(string locationName)
        {
            var assistance =  assistances.FirstOrDefault(c => c.LocationName.Equals(locationName));
            if (assistance != null)
            {
                this.BindingContext = assistance;
            }
        }
    }
}