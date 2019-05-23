using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework.Internal.Filters;

namespace TheGame
{
    public class Spawner : IGameObject
    {
        public Vector Location { get; set; }
        public double Direction { get; set; }
        public float Size { get; private set; }
        public int Speed { get; }
        public double SpeedFactor { get; }
        public int Health { get; set; } = 10;
        public bool IsAlive { get; private set; } = true;
        public Color MainСolor { get; } = Color.Beige;
        [JsonIgnore]
        private Game game;
        private IGameObject obj;
        private int time = 0;

        public Spawner(IGameObject obj, Vector location, double direction, Game game)
        {
            this.obj = obj;
            Location = location;
            Direction = direction;
            this.game = game;
        }
        
        public Spawner(IGameObject obj, Game game)
        {
            this.obj = obj;
            Location = obj.Location;
            Direction = obj.Direction;
            this.game = game;
        }

        public void SetDirection(double direction)
        {
            Direction = direction;
        }
        public void SetLocation(Vector location)
        {
            Location = location;
        }

        public void UpdateDirection()
        {
            time++;
            if (time == 70) Kill();
            if (time <= 10 || (time > 20 && time < 30) || 
                (time > 40 && time < 50) || (time > 60 && time < 70)) Size = obj.Size / 2;
            else Size = obj.Size;
        }

        public void Kill()
        {
            IsAlive = false;
            var obj = this.obj;
            var type = obj.GetType();
            type.InvokeMember("Direction", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null,
                obj, new object[] {Direction});
            obj.Location = Location;
            
            game.NewObjects.Add(obj);
            
        }

        public void Use(Game game){}

        public IGameObject Clone()
        {
            return new Spawner(obj.Clone(), Location, Direction, game);
        }
    }
}