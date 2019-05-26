using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameFrogger.Controllers;
using MonoGameFrogger.Factories;
using MonoGameFrogger.FSM;
using MonoGameFrogger.Models;
using MonoGameFrogger.Views;
using System.Collections.Generic;

namespace MonoGameFrogger.States
{
    /// <summary>
    /// The main game state.
    /// </summary>
    class GameState : BaseState
    {
        private static int ScreenSizeMultiplier = 2;

        private readonly List<BaseView> _views = new List<BaseView>();
        private readonly List<IController> _controllers = new List<IController>();
        private readonly SpriteBatch _spriteBatch;       
        private readonly RenderTarget2D _screen;
        private readonly PlayerModel _playerModel;

        // Moving cars
        // Moving river things
        // Snake
        // Timer
        // Score

        public GameState(StateMachine stateMachine)
            : base(stateMachine)
        {
            _screen = new RenderTarget2D(stateMachine.Game.GraphicsDevice, 224, 256);
            _spriteBatch = new SpriteBatch(stateMachine.Game.GraphicsDevice);

            _playerModel = new PlayerModel(); // TODO: REPLACE WITH MVC
            var goals = new GoalContainerModel();

            _views.Add(new BackgroundView(stateMachine.Game.Content, _spriteBatch));
            _views.Add(new ScoreView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new PlayerView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new FrogPositionView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new GoalView(StateMachine.Game.Content, _spriteBatch, goals));

            var playerController = new PlayerController(_playerModel);
            _controllers.Add(playerController);
            _controllers.Add(new GoalController(_playerModel, goals, playerController));
            _controllers.Add(new HomeAnimationController(goals));

            var bulldozerRowModel = new VehicleRowModel(BulldozerFactory.CreateFirstStage(), 32);
            var racingCarRowModel = new VehicleRowModel(RacingCarFactory.CreateFirstStage(), 0, 128, VehicleGhost.NoGhost, VehicleDirection.LeftToRight, 2);
            var sedanCarRowModel  = new VehicleRowModel(GenericCarFactory.CreateFirstStage(), 0, 32, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var duneBuggyRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(y: 208, frame: 9), 0, 32, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var trucksRowModel = new VehicleRowModel(TruckFactory.CreateFirstStage(), 0, 36, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var models = new [] { bulldozerRowModel, racingCarRowModel, sedanCarRowModel, duneBuggyRowModel, trucksRowModel };

            var vehicleView = new VehicleView(stateMachine.Game.Content, _spriteBatch, models);
            _views.Add(vehicleView);

            var vehicleController = new VehicleController(_playerModel, playerController, models);
            _controllers.Add(vehicleController);
        }

        public override void Draw()
        {
            StateMachine.Game.GraphicsDevice.SetRenderTarget(_screen);
            StateMachine.Game.GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var view in _views)
            {
                view.Draw();
            }

            _spriteBatch.End();

            StateMachine.Game.GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_screen, new Rectangle(0, 0, 224 * ScreenSizeMultiplier, 256 * ScreenSizeMultiplier), Color.White);
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
            foreach (var controller in _controllers)
            {
                controller.Update(deltaTime);
            }
        }
    }
}
