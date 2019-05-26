using Microsoft.Xna.Framework;
using MonoGameFrogger.Controllers;
using System.Collections.Generic;

namespace MonoGameFrogger.Models
{
    class VehicleRowModel
    {
        public List<VehicleModel> Vehicles { get; } = new List<VehicleModel>();

        public Vector2 OffsetRight { get; set; }
        public Vector2 OffsetLeft { get; set; }
        public float OffsetDistance { get; }
        public bool IsCoolingDown { get; set; }
        public VehicleGhost Ghost { get; set; }
        public VehicleDirection Direction { get; set; }
        public float Speed { get; set; }
        public float CurrentCooldown { get; set; }
        public float CooldownPeriod { get; set; }
        public Vector2 StartingPoint { get; set; }

        public VehicleRowModel(IEnumerable<VehicleModel> models,
                               float offsetDistance = 0f, 
                               float pixelsPerSecond = 32f,
                               VehicleGhost ghost = VehicleGhost.Ghost,
                               VehicleDirection direction = VehicleDirection.LeftToRight,
                               float cooldownPeriod = -1)
        {
            Vehicles.AddRange(models);
            OffsetRight = Vector2.Zero;
            Speed = pixelsPerSecond;
            OffsetLeft = new Vector2(-(224 + offsetDistance), 0);
            Ghost = ghost;
            OffsetDistance = offsetDistance;
            Direction = direction;
            CooldownPeriod = cooldownPeriod;
        }
    }
}
