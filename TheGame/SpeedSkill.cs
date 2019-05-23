using System;

namespace TheGame
{
    public class SpeedSkill : ISkill
    {
        public bool IsActive { get; private set; }
        private readonly int maxUsingTime;
        private int actualUsingTime;
        private Game game;
        private Action gameMode;

        public SpeedSkill(int maxUsingTime)
        {
            this.maxUsingTime = maxUsingTime;
        }

        public void GameMode()
        {
            if (actualUsingTime < maxUsingTime)
            {
                game.Player.ActualSpeed = game.Player.Speed * 3;
                actualUsingTime++;
                IsActive = true;
            }
            else
                Deactivate();
        }

        private void Deactivate()
        {
            game.Skill = null;
            game.GameMode = gameMode;
        }

        public void Use(Game game)
        {
            this.game = game;
            gameMode = game.GameMode;
            game.GameMode += GameMode;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"SpeedSkill {maxUsingTime}";
        }
        
        public ISkill FromString(string str)
        {
            return new SpeedSkill(int.Parse(str.Split()[1]));
        }
    }
}