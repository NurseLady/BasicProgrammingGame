using System.Drawing;

namespace TheGame
{
    public class SpeedSkill : ISkill
    {
        public bool IsActive { get; private set; }
        private readonly int maxUsingTime;
        private int actualUsingTime = 0;

        public SpeedSkill(int maxUsingTime)
        {
            this.maxUsingTime = maxUsingTime;
        }



        public void Deactivate(Game game)
        {
            game.Skill = null;
        }

        public void Use(Game game)
        {
            if (actualUsingTime < maxUsingTime)
            {
                game.Player.ActualSpeed = game.Player.Speed * 2;
                actualUsingTime++;
                IsActive = true;
            }
            else
                Deactivate(game);
        }

        public override string ToString()
        {
            return $"SpeedSkill {maxUsingTime}";
        }
    }
}