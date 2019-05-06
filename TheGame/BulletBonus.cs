using System;
using System.Drawing;

namespace TheGame
{
    public class BulletBonus : IBonus
    {
        public Vector Location { get; set; }
        public double Direction { get; }
        public float Size { get; }
        public int Speed { get; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }
        public int Costs { get; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#B9FFFA");

        public BulletBonus(Vector location, int costs)
        {
            Location = location;
            Size = 1;
            Costs = costs;
            Speed = 0;
            IsAlive = true;
        }
        
        public void UpdateDirection(){}

        public void Kill() => IsAlive = false;

        public void Use(Game game)
        {
            game.Player.BulletsCount += Costs;
            Kill();
        }
    }
}