using System.Collections.Generic;

namespace Domain.Entities
{
    public class TruckModel
    {
        public int TruckModelId { get; set; }
        public string Name { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}
