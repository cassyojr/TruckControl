using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    internal static class TruckSeed
    {
        public static IEnumerable<Truck> Seeds = new List<Truck>()
            {
                new Truck
                {
                    TruckId = 1,
                    Name = "Volvo FH16",
                    ModelYear = 2021,
                    ProductionYear = 2020,
                    TruckModelId = 1,
                    CreationDate = DateTime.Now
                },
                new Truck
                {
                    TruckId = 2,
                    Name = "Volvo FH",
                    ModelYear = 2021,
                    ProductionYear = 2020,
                    TruckModelId = 1,
                    CreationDate = DateTime.Now
                },
                new Truck
                {
                    TruckId = 3,
                    Name = "Volvo FM",
                    ModelYear = 2021,
                    ProductionYear = 2020,
                    TruckModelId = 2,
                    CreationDate = DateTime.Now
                }
            }
            .ToArray();
    }
}
