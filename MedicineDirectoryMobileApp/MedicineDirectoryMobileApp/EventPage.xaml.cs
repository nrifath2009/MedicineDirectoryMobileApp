using MedicineDirectoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicineDirectoryMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {   
        List<EventViewModel> events = new List<EventViewModel>();
        public EventPage()
        {
            InitializeComponent();
            BuildEventPickerList();
            BuildEventsList();
            eventDetailGrid.IsVisible = false;
            //BindingContext = this;
        }

        private void BuildEventPickerList()
        {
            List<EventViewModel> events = new List<EventViewModel>();
            for (int i = 1; i < 20; i++)
            {
                eventPicker.Items.Add("Event " + i);
                //Location location = new Location
                //{
                //    Id = i,
                //    LocationName = "Location " + i
                //};
                //locations.Add(location);

            }

        }

        private void eventPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                eventDetailGrid.IsVisible = true;
                var selectedLocation = picker.Items[selectedIndex];
                PopulateEventDetailOnSelectionChange(selectedLocation);
            }
        }
        private void BuildEventsList()
        {
            for (int i = 1; i < 20; i++)
            {
                EventViewModel eventViewModel = new EventViewModel
                {
                    Id = i,
                    EventName = "Event " + i,
                    EventDateTime = DateTime.UtcNow.ToString(),
                    MeetingLink = "http://google.com"
                };
                events.Add(eventViewModel);
            }
        }
        private void PopulateEventDetailOnSelectionChange(string eventName)
        {
            var eventViewModel = events.FirstOrDefault(c => c.EventName.Equals(eventName));
            if (eventViewModel != null)
            {
                this.BindingContext = eventViewModel;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view =  sender as Label;
            if (view != null 
                && view.FormattedText!=null 
                && view.FormattedText.Spans!=null
                && view.FormattedText.Spans[0]!=null)
            {
                var url = view.FormattedText.Spans[0].Text;
                await Launcher.OpenAsync(url);
            }
            
        }
    }
}