using System;

namespace TruckControl.Models
{
    public class TruckViewModel
    {
        public int Id { get; set; }
        public string TruckName { get; set; }
        public string TruckModelName { get; set; }
        public int ProductionYear { get; set; }
        public int ModelYear { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
