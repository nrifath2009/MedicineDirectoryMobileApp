using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineDirectoryMobileApp.ViewModels
{
    public class Assistance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
