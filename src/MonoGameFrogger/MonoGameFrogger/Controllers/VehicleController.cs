using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;
using System;
using System.Collections.Generic;

namespace MonoGameFrogger.Controllers
{
    /// <summary>
    /// Vehicle controller. Updates every vehicle row in the game.
    /// </summary>
    class VehicleController : IController
    {
        private readonly List<VehicleRowModel> _rows = new List<VehicleRowModel>();
        private readonly PlayerModel _player;
        private readonly IReset _reset;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="player">Player model</param>
        /// <param name="reset">Reset mechanism when a player collides with a vehicle</param>
        /// <param name="rows">Vehicle rows</param>
        public VehicleController(PlayerModel player, IReset reset, IEnumerable<VehicleRowModel> rows)
        {
            _player = player;
            _reset = reset;

            _rows.AddRange(rows);
            foreach (var row in _rows)
            {
                row.StartingPoint = row.OffsetLeft * (row.Direction == VehicleDirection.LeftToRight ? 1f : -1f);
                row.OffsetLeft = row.StartingPoint;
            }
        }

        /// <summary>
        /// Update the vehicles in each row.
        /// </summary>
        /// <param name="deltaTime">Delta time</param>
        public void Update(float deltaTime)
        {   
            foreach (var row in _rows)
            {
                // TODO: Offset needs to be taken into consideration!!
                //var playerArea = new Rectangle((int)_player.Position.X, (int)_player.Position.Y, 16, 16);

                //foreach(var vehicle in row.Vehicles)
                //{
                //    var rRect = new Rectangle(new Point((int)vehicle.Positon.X, (int)vehicle.Positon.Y), new Point(16, 16));
                //    if (rRect.Intersects(playerArea))
                //    {
                //        _reset.Reset(ResetMode.Death);
                //    }
                //}

                if (row.CurrentCooldown > 0)
                {
                    row.CurrentCooldown -= deltaTime;
                    continue;
                }

                row.CurrentCooldown = 0f;
                row.IsCoolingDown = false;

                var distance = row.Speed * deltaTime;
                if (row.Direction == VehicleDirection.RightToLeft)
                {
                    distance *= -1f;
                }

                row.OffsetRight += new Vector2(distance, 0);
                row.OffsetLeft += new Vector2(distance, 0);

                if (Math.Abs(row.OffsetRight.X) >= 224)
                {
                    var sign = row.Direction == VehicleDirection.LeftToRight ? 1f : -1f;
                    var diff = new Vector2(row.OffsetRight.X - (224 * sign), 0);
                    diff += (row.OffsetLeft * sign);
                    row.OffsetRight = row.OffsetLeft;
                    row.OffsetLeft = row.StartingPoint + (diff * sign);
                    if (row.CooldownPeriod > 0)
                    {
                        row.CurrentCooldown = row.CooldownPeriod;
                        row.IsCoolingDown = true;
                    }
                }
            }
        }
    }
}
