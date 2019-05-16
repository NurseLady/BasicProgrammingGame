using System.Drawing;

namespace TheGame
{
    public class Player : IGameObject
    {
        public Vector Location { get; set; }
        public double Direction { get; internal set; }
        private double TurnAngle { get; set; } = 0.07;
        public float Size { get; private set; }
        public int Speed { get; private set; }
        public double SpeedFactor { get; }
        public int Health { get; set; } = 10;
        public bool IsFire { private get; set; }
        public bool IsMove { private get; set; } = false;
        public Turn Turn { private get; set; } = Turn.None;
        public bool IsAlive { get; private set; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#FF6037");

        public int FireSpeed { get; } = 10;
        private int FirePause = 0;
        public int BulletsCount { get; set; } = 5;
        public double ActualSpeed { get; set; } = 0;

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
            Size = 2 + game.Score / 20;
            if (Health == 0)
            {
                Kill();
                return;
            }
            UpdateDirection();
            if (IsMove && ActualSpeed < Speed)
                ActualSpeed += 0.5;
            else if (ActualSpeed > 0)
                ActualSpeed -= 0.5;
            var deltaLocation = new Vector(1, 0).Rotate(Direction) * ActualSpeed * SpeedFactor;
            var newLocation = Location + deltaLocation;
            if (newLocation.X > 0 && newLocation.Y > 0
                                  && newLocation.X < game.Width && newLocation.Y < game.Height)
                Location = newLocation;

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

        private void DoFire(Game game)
        {
            if (BulletsCount <= 0) return;
            
            var playerR = this.GetObjectRadius();
            var bulletLocation = new Vector(1,0).Rotate(Direction) * (playerR + Size / 2 + 2);
            bulletLocation += Location;
            var bullet = new Bullet(bulletLocation, Direction, Size, speedFactor:SpeedFactor);
            game.GameObjects.Add(bullet);
            FirePause = FireSpeed;
            BulletsCount--;
        }

        public void Kill() => IsAlive = false;
        
        public void Use(Game game){}
    }
}