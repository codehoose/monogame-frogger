using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameFrogger.Models
{
    class PlayerModel
    {
        public int Lives { get; set; }
        public float Time { get; set; }
        public int Score { get; set; }
        public int HiScore { get; set; }
        public Vector2 Position { get; set; }
        public int Frame { get; set; }  
        public SpriteEffects Flip { get; set; }

        public PlayerModel()
        {
            Lives = 4;
            Time = 60;  
            HiScore = 12345;
            Frame = 34;
            Position = new Vector2(16 * 6, 224);
        }
    }
}
