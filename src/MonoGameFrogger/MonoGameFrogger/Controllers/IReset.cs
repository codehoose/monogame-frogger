namespace MonoGameFrogger.Controllers
{
    /// <summary>
    /// Interface to reset the game when a player has reached a goal or died.
    /// </summary>
    interface IReset
    {
        /// <summary>
        /// Reset the player
        /// </summary>
        /// <param name="resetMode">Reset mode</param>
        void Reset(ResetMode resetMode);
    }
}
