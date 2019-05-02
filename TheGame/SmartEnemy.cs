namespace TheGame
{
    public class SmartEnemy : IEnemy
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Life { get; }
        public bool IsAlive { get; private set; }
        public bool IsMet { get; set; }
        public int Costs { get; }
        
        public int FireSpeed { get; private set; }
        public int MaxBulletsCount { get; private set; }
        public int BulletsCount { get; private set; }
        public int BulletsReloadingSpeed { get; private set; }

        public SmartEnemy(Vector location, double direction, int size, int speed, int life, int costs, double speedFactor = 0.1)
        {
            Location = location;
            Direction = direction;
            Size = size;
            Speed = speed;
            SpeedFactor = speedFactor;
            Life = life;
            Costs = costs;
            IsAlive = true;
        }

        public void UpdateDirection(){}

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}