using System.Drawing;

namespace TheGame
{
    public class SpeedSkill : ISkill
    {
        public bool IsActive { get; private set; }
        private readonly int maxUsingTime;
        private int actualUsingTime;
        private Game game;

        public SpeedSkill(int maxUsingTime)
        {
            this.maxUsingTime = maxUsingTime;
        }

        public void GameMode()
        {
            if (actualUsingTime <= maxUsingTime)
            {
                game.Player.ActualSpeed = game.Player.Speed * 2;
                actualUsingTime++;
                IsActive = true;
            }
            else
                Deactivate();
        }

        private void Deactivate()
        {
            game.Skill = null;
            game.GameMode -= GameMode;
        }

        public void Use(Game game)
        {
            this.game = game;
            game.GameMode += GameMode;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"SpeedSkill {maxUsingTime}";
        }
    }
}