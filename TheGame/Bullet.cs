using System;
using System.Drawing;

namespace TheGame
{
    public class Bullet : IGameObject
    {
        public Vector Location { get; set; }
        public double Direction { get; }
        public float Size { get; }
        public int Speed { get; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#FBFFF4");

        public Bullet(Vector location, double direction, float size, int speed = 40, double speedFactor = 0.1)
        {
            Location = location;
            Direction = direction;
            Size = size / 5;
            Speed = speed;
            SpeedFactor = speedFactor;
            IsAlive = true;
        }
        
        public void UpdateDirection(){}

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}