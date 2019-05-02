namespace TheGame
{
    public class SimpleEnemy : IEnemy
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Health { get; private set; }
        public bool IsAlive { get; private set; }
        public bool IsMet { get; set; }
        public int Costs { get; private set; }

        public SimpleEnemy(Vector location, double direction, int size, int speed, int health, int costs, double speedFactor = 0.1)
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
        
        public void UpdateDirection()
        {
            Direction += 0.01;
        }

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