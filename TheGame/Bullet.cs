using System;

namespace TheGame
{
    public class Bullet : IGameObject
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        public float Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }

        public Bullet(Vector location, double direction, float size, int speed = 40, double speedFactor = 0.1)
        {
            Location = location;
            Direction = direction;
            Size = size / 10;
            Speed = speed;
            SpeedFactor = speedFactor;
            IsAlive = true;
        }
        
        public void UpdateDirection(){}

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}