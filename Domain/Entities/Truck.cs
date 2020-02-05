using System;

namespace Domain.Entities
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int ModelYear { get; set; }
        public DateTime CreationDate { get; set; }

        public int TruckModelId { get; set; }
        public TruckModel TruckModel { get; set; }
    }
}
