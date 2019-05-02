namespace TheGame
{
    public class Player : IGameObject
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        private double TurnAngle { get; set; } = 0.07;
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Life { get; }
        public bool IsFire { get; set; }
        public bool IsMove { get; set; } = false;
        public Turn Turn { get; set; } = Turn.None;
        public bool IsAlive { get; private set; }

        public int FireSpeed { get; private set; } = 10;
        private int FirePause = 0;
        public int BulletsCount { get; private set; } = 5;
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

        public void Move(Game game)
        {
            UpdateDirection();
            if (IsMove && ActualSpeed < Speed)
                ActualSpeed += 0.5;
            else if (ActualSpeed > 0)
                ActualSpeed -= 0.5;
            var deltaLocation = new Vector(1, 0).Rotate(Direction) * ActualSpeed * SpeedFactor;
            Location = Location + deltaLocation;
            
            if (FirePause != 0)
                FirePause--;
            else
                if (IsFire)
                    DoFire(game);
        }

        public void UpdateDirection()
        {
            Direction += (int) Turn * TurnAngle;
        }

        public void DoFire(Game game)
        {
            if (BulletsCount > 0)
            {
                var playerR = this.GetObjectRadius();
                var bulletLocation = new Vector(1,0).Rotate(Direction) * (playerR + 1);
                bulletLocation += Location;
                var bullet = new Bullet(bulletLocation, Direction, Size, speedFactor:SpeedFactor);
                game.GameObjects.Add(bullet);
                FirePause = FireSpeed;
                BulletsCount--;
            }
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}