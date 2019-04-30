namespace TheGame
{
    public class Player : IGameObject
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public bool IsAlive { get; private set; }

        public Player(Vector location, double direction, int speed = 10)
        {
            Location = location;
            Direction = direction;
            Size = 1;
            Speed = speed;
            IsAlive = true;
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}