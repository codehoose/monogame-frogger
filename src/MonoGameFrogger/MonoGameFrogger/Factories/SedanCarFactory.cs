using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;
using System.Collections.Generic;

namespace MonoGameFrogger.Factories
{
    static class SedanCarFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage(float x= 0,float y = 176)
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(8, new Vector2(x+ 208, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 64, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 64 - 64, y)));
            models.Add(new VehicleModel(8, new Vector2(x + 208 - 64 - 64 - 64, y)));

            return models;
        }
    }
}
