namespace MonoGameFrogger.Models
{
    class PlayerModel
    {
        public int Lives { get; set; }
        public float Time { get; set; }

        public PlayerModel()
        {
            Lives = 4;
            Time = 60;
        }
    }
}
