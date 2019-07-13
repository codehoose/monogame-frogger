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
        //private readonly DebugView _debugView;

        private VehicleRowModel _duneBuggyRowModel;

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

            //_debugView = new DebugView(StateMachine.Game.Content, _spriteBatch);

            _views.Add(new BackgroundView(stateMachine.Game.Content, _spriteBatch));
            _views.Add(new ScoreView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new PlayerView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new FrogPositionView(stateMachine.Game.Content, _spriteBatch, _playerModel));
            _views.Add(new GoalView(StateMachine.Game.Content, _spriteBatch, goals));
            //_views.Add(_debugView);

            //_debugView.AddRect("river", new Rectangle(0, 48, 256, 80), new Color(Color.Red, 0.1f));

            var playerController = new PlayerController(_playerModel);
            _controllers.Add(playerController);
            _controllers.Add(new GoalController(_playerModel, goals, playerController));
            _controllers.Add(new HomeAnimationController(goals));

            var bulldozerRowModel = new VehicleRowModel(BulldozerFactory.CreateFirstStage(), 32);
            var racingCarRowModel = new VehicleRowModel(RacingCarFactory.CreateFirstStage(), 0, 128, VehicleGhost.NoGhost, VehicleDirection.LeftToRight, 2);
            var sedanCarRowModel  = new VehicleRowModel(GenericCarFactory.CreateFirstStage(), 0, 32, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            _duneBuggyRowModel = new VehicleRowModel(GenericCarFactory.CreateFirstStage(y: 208, frame: 9), 0, 32, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var trucksRowModel = new VehicleRowModel(TruckFactory.CreateFirstStage(), 0, 36, VehicleGhost.Ghost, VehicleDirection.RightToLeft);
            var models = new [] { bulldozerRowModel, racingCarRowModel, sedanCarRowModel, _duneBuggyRowModel, trucksRowModel };

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
            //int count = 0;
            //foreach (var model in _duneBuggyRowModel.Vehicles)
            //{
            //    _debugView.RemoveRect($"car{count}");
            //    _debugView.AddRect($"car{count}", new Rectangle(new Point((int)model.Positon.X + (int)_duneBuggyRowModel.OffsetDistance + (int)_duneBuggyRowModel.OffsetRight.X, (int)model.Positon.Y), new Point(16, 16)), Color.Purple);

            //    var xl = model.Positon + _duneBuggyRowModel.OffsetLeft;
            //    var posLeft = new Point((int)xl.X, (int)xl.Y);

            //    _debugView.RemoveRect($"car{count}ghost");
            //    _debugView.AddRect($"car{count}ghost", new Rectangle(new Point((int)posLeft.X, (int)model.Positon.Y), new Point(16, 16)), Color.Red);

            //    count++;
            //}

            foreach (var controller in _controllers)
            {
                controller.Update(deltaTime);
            }
        }
    }
}
