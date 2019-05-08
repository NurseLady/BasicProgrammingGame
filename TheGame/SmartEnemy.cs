using System.Drawing;

namespace TheGame
{
    public class SmartEnemy : IEnemy
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        public float Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }
        public int Costs { get; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#00A388");
        
        public int FireSpeed { get; private set; }
        public int MaxBulletsCount { get; private set; }
        public int BulletsCount { get; private set; }
        public int BulletsReloadingSpeed { get; private set; }

        public SmartEnemy(Vector location, double direction, float size, int speed, int health, int costs, double speedFactor = 0.1)
        {
            Location = location;
            Direction = direction;
            Size = size;
            Speed = speed;
            SpeedFactor = speedFactor;
            Health = health;
            Costs = costs;
            IsAlive = true;
        }

        public void UpdateDirection(){}

        public void Kill() => IsAlive = false;

        public void Use(Game game)
        {
            if (Size > game.Player.Size)
                game.Player.Health = 0;
            else
            {
                game.Score += Costs;
                Kill();
            }
        }
    }
}