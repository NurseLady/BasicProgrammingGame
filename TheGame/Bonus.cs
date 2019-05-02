using System;

namespace TheGame
{
    public class Bonus : IGameObject
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Life { get; }
        public bool IsAlive { get; private set; }
        public int Costs { get; private set; }

        public Bonus(Vector location, double direction, int costs)
        {
            Location = location;
            Direction = direction;
            Size = 1;
            Costs = costs;
            Speed = 0;
            IsAlive = true;
        }
        
        public void Move(){}

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}