using System;
using System.Drawing;
using Newtonsoft.Json;

namespace TheGame
{
    public class SmartEnemy : IEnemy
    {
        public Vector Location { get; set; }
        public double Direction { get; private set; }
        public float Size { get; }
        public int Speed { get; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }
        public int Costs { get; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#00A388");
        private Vector lastLocation;

        public SmartEnemy(Vector location, double direction, float size, int speed, int health, int costs, double speedFactor = 0.1)
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
            if (!lastLocation.Equals(null) && lastLocation.Equals(Location))
            {
                Direction = (new Vector(1, 0).Rotate(Direction) * (-1)).Angle;
            }

            lastLocation = Location;
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
        
        public IGameObject Clone()
        {
            return new SmartEnemy(Location, Direction, Size, Speed, Health, Costs, SpeedFactor);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}