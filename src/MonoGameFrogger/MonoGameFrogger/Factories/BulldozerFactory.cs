using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;
using System.Collections.Generic;

namespace MonoGameFrogger.Factories
{
    static class BulldozerFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage()
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(7, new Vector2(0, 192)));
            models.Add(new VehicleModel(7, new Vector2(64, 192)));
            models.Add(new VehicleModel(7, new Vector2(128, 192)));
            models.Add(new VehicleModel(7, new Vector2(128 + 64, 192)));

            return models;
        }
    }
}
