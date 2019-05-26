using Microsoft.Xna.Framework;

namespace MonoGameFrogger.Models
{
    class VehicleModel
    {
        public Vector2 Positon { get; }

        public int Frame { get; }

        public VehicleModel(int frame, Vector2 pos)
        {
            Positon = pos;
            Frame = frame;
        }
    }
}
