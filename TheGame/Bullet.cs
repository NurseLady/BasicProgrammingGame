using System;

namespace TheGame
{
    public class Bullet : IGameObject
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public bool IsAlive { get; private set; }

        public Bullet(Vector location, double direction, int speed = 40)
        {
            Location = location;
            Direction = direction;
            Size = Int32.MaxValue;
            Speed = speed;
            IsAlive = true;
        }
        
        public void Move()
        {
            var deltaLocation = new Vector(1, 0).Rotate(Direction) * Speed / 10;
            Location = Location + deltaLocation;
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}