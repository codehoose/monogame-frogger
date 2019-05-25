using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoGameFrogger.Models
{
    class GoalContainerModel
    {
        public IList<GoalModel> Goals { get; }

        public bool GoalsFilled
        {
            get
            {
                int count = 0;
                foreach(var goal in Goals)
                {
                    if (goal.Occupied)
                        count++;
                }

                return count == 5;
            }
        }

        public GoalContainerModel()
        {
            Goals = new List<GoalModel>();

            var x = 8;
            for (var i = 0; i < 5; i++)
            {
                Goals.Add(new GoalModel(new Rectangle(x, 32, 16, 16)));
                x += 48;
            }
        }
    }
}
