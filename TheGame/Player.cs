namespace TheGame
{
    public class Player : IGameObject
    {
        public Vector Location { get; private set; }
        public double Direction { get; private set; }
        public double TurnAngle { get; private set; } = 0.07;
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Life { get; }
        public bool IsFire { get; private set; }
        public bool IsMove { get; set; } = false;
        public Turn Turn { get; set; } = Turn.None;
        public bool IsAlive { get; private set; }
        
        public int FireSpeed { get; private set; }
        public int BulletsCount { get; private set; }
        private double ActualSpeed = 0;

        public Player(Vector location, double direction, int speed = 15, double speedFactor = 0.1)
        {
            Location = location;
            Direction = direction;
            Size = 2;
            Speed = speed;
            SpeedFactor = speedFactor;
            IsAlive = true;
        }

        public void Move()
        {
            UpdateDirection();
            if (IsMove && ActualSpeed < Speed)
                ActualSpeed += 0.5;
            else if (ActualSpeed > 0)
                ActualSpeed -= 0.5;
            var deltaLocation = new Vector(1, 0).Rotate(Direction) * ActualSpeed * SpeedFactor;
            Location = Location + deltaLocation;
        }

        public void UpdateDirection()
        {
                Direction += (int) Turn * TurnAngle;
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}