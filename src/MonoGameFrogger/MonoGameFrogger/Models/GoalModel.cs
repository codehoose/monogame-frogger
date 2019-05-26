using Microsoft.Xna.Framework;

namespace MonoGameFrogger.Models
{
    class GoalModel
    {
        public bool Occupied { get; set; }

        public Rectangle Area { get; }

        public int Frame { get; set; }

        public GoalModel(Rectangle rect)
        {
            Area = rect;
            Occupied = false;
            Frame = 0;
        }
    }
}
