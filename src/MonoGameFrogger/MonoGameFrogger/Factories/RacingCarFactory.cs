using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;
using System.Collections.Generic;

namespace MonoGameFrogger.Factories
{
    static class RacingCarFactory
    {
        public static IEnumerable<VehicleModel> CreateFirstStage()
        {
            List<VehicleModel> models = new List<VehicleModel>();

            models.Add(new VehicleModel(6, new Vector2(0, 160)));
            //models.Add(new VehicleModel(7, new Vector2(64, 192)));
            //models.Add(new VehicleModel(7, new Vector2(128, 192)));
            //models.Add(new VehicleModel(7, new Vector2(128 + 64, 192)));

            return models;
        }
    }
}
