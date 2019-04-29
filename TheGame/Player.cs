namespace TheGame
{
    public class Player : IGameObject
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public bool IsAlive { get; private set; }

        public Player(Vector location, double direction)
        {
            Location = location;
            Direction = direction;
            Size = 1;
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