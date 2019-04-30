namespace TheGame
{
    public class SimpleEnemy : IEnemy
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public bool IsAlive { get; private set; }
        public bool IsMet { get; set; }

        public SimpleEnemy(Vector location, double direction, int size, int speed)
        {
            Location = location;
            Direction = direction;
            Size = size;
            Speed = speed;
            IsAlive = true;
            
        }
        
        public void Move()
        {
            Direction += 0.3;
            var deltaLocation = new Vector(1, 0).Rotate(Direction) * Speed / 10;
            Location = Location + deltaLocation;
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}