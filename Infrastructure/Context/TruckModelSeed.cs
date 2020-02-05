using Domain.Entities;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    internal static class TruckModelSeed
    {
        public static IEnumerable<TruckModel> Seeds = new List<TruckModel>()
            {
                new TruckModel { TruckModelId = 1, Name = "FH" },
                new TruckModel { TruckModelId = 2, Name = "FM" }
            }
            .ToArray();
    }
}
