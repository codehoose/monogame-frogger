using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.FSM;
using MonoGameFrogger.General;
using MonoGameFrogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameFrogger.States
{
    class GameState : BaseState
    {
        SpriteBatch _spriteBatch;

        // Background
        SpriteSheet _blocks;
        Texture2D _home;

        // Moving cars
        // Moving river things
        // Snake
        // Timer
        // Score
        BitmapFont _font;
        PlayerModel _playerModel;
        // Lives remaining

        public GameState(StateMachine stateMachine)
        {
            _spriteBatch = new SpriteBatch(stateMachine.Game.GraphicsDevice);
            var blocksTexture = stateMachine.Game.Content.Load<Texture2D>("blocks");
            _home = stateMachine.Game.Content.Load<Texture2D>("home");
            _blocks = new SpriteSheet(blocksTexture, _spriteBatch, 16, 16);

            var fontTexture = stateMachine.Game.Content.Load<Texture2D>("font");
            var fontSprite = new SpriteSheet(fontTexture, _spriteBatch, 8, 8);
            _font = new BitmapFont(fontSprite);

            _playerModel = new PlayerModel(); // TODO: REPLACE WITH MVC
        }

        public override void Draw()
        {
            _spriteBatch.Begin();

            DrawBackground();
            DrawScore();
            DrawPlayerModel();

            _spriteBatch.End();
        }

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Update(float deltaTime)
        {

        }

        private void DrawPlayerModel()
        {
            for (int i = 0; i < _playerModel.Lives; i++)
            {
                _font.Draw("/", new Vector2(i * 8, 30 * 8), Color.White);
            }

            _font.Draw("TIME", new Vector2(24 * 8, 31 * 8), Color.Yellow);
        }

        private void DrawScore()
        {
            _font.Draw("1-UP", new Vector2(40, 0), Color.White);
            _font.Draw("1337", new Vector2(40, 8), Color.Red);

            _font.Draw("HI-SCORE", new Vector2(88, 0), Color.White);
            _font.Draw("10101", new Vector2(96, 8), Color.Red);
        }

        private void DrawBackground()
        {
            // Blue river
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    _blocks.Draw(new Vector2(x * 16, y * 16), 43, Color.White);
                }
            }

            // The frog homes
            _spriteBatch.Draw(_home, new Vector2(0, 24), Color.White);

            // Sidewalk
            for (int x = 0; x < 14; x++)
            {
                _blocks.Draw(new Vector2(x * 16, 8 * 16), 0, Color.White);
                _blocks.Draw(new Vector2(x * 16, 14 * 16), 0, Color.White);
            }
        }
    }
}
