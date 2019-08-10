﻿using Microsoft.Xna.Framework;
using MonoGameFrogger.Models;
using System.Collections.Generic;

namespace MonoGameFrogger.Controllers
{
    /// <summary>
    /// Vehicle controller. Updates every vehicle row in the game.
    /// </summary>
    class VehicleController : BaseMovableController
    {
        private IReset _reset;

        public VehicleController(PlayerModel player, IReset reset, IEnumerable<VehicleRowModel> rows) 
            : base(player, rows)
        {
            _reset = reset;
        }

        protected override void OnCollision(Rectangle rect)
        {
            _reset.Reset(ResetMode.Death);
        }
    }
}
