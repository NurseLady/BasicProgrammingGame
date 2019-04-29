namespace TheGame
{
    public class SmartEnemy : IEnemy
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public bool IsAlive { get; private set; }
        public bool IsMet { get; set; }

        public SmartEnemy(Vector location, double direction, int size)
        {
            Location = location;
            Direction = direction;
            Size = size;
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