using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;
namespace TheGame
{
    // [JsonConverter(typeof(BaseConverter))]
    public class Game
    {
        public Player Player { get; set; }
        public int Score { get; set; }
        public int GlobalScore { get; set; }
        public bool IsOver { get; private set; }
        public List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();
        public List<IGameObject> NewObjects { get; set; } = new List<IGameObject>();
        public ISkill Skill { get; set; }
        [JsonIgnore]
        public Action GameMode { get; set; }
        private MapCreator Creator { get; set; }
        public int Lvl { get; set; } = 1;

        public readonly int Height;
        public readonly int Width;
        
        public Game()
        {
            GameMode = UsualGameMode;
            Creator = new MapCreator(this);
            Player = Creator.GetPlayer();
            Width = MapCreator.GameWidth;
            Height = MapCreator.GameHeight;
            GameObjects = Creator.CreateRandomMap();
            Score = 0;
            IsOver = false;
        }

        public Game(List<IGameObject> map)
        {
            GameMode = UsualGameMode;
            Creator = new MapCreator(this);
            Player = Creator.GetPlayer();
            Width = MapCreator.GameWidth;
            Height = MapCreator.GameHeight;
            GameObjects = map;
            Score = 0;
            IsOver = false;
            GameMode = UsualGameMode;
        }

        public void Update()
        {
            GameMode();
            if (!Player.IsAlive)
                IsOver = true;
        }

        internal void UsualGameMode()
        {
            if (Score > 500 * Lvl)
            {
                Lvl++;
                Score = 0;
            }
            GlobalScore = Score + 500 * (Lvl - 1);
            Creator.UpdateMap();
            GameObjects.AddRange(NewObjects);
            NewObjects.Clear();
            MoveAllObjects(Move);
            Player.Move(this);
            HandlePlayerIntersection();
            UpdateListOfObjects();
        }

        internal void UpdateListOfObjects()
        {
            GameObjects = GameObjects.Where(o => o.IsAlive).ToList();
        }

        internal void HandlePlayerIntersection() => FindIntersectedObject(Player)?.Use(this);

        internal IGameObject FindIntersectedObject(IGameObject gameObject)
        {
            var nearest = GameObjects
                .Where(o => o != gameObject)
                .OrderBy(o => o.GetActualDistance(gameObject))
                .FirstOrDefault();
            if (nearest != null)
                return nearest.GetActualDistance(gameObject) < 1 ? nearest : null;
            return null;
        }

        internal void MoveAllObjects(Action<IGameObject> move)
        {
            foreach (var gameObject in GameObjects)
                move(gameObject);
        }

        private void Move(IGameObject gameObject)
        {
            gameObject.UpdateDirection();
            CheckWallCollision(gameObject);
            DoKill(gameObject); 
        }

        internal void DoKill(IGameObject gameObject)
        {
            if (!(gameObject.Health > 0 || gameObject is IBonus || gameObject is Bullet))
            {
                if (gameObject is IEnemy enemy)
                    Score += enemy.Costs;
                gameObject.Kill();
            }
            else
            {
                var intersectedObject = FindIntersectedObject(gameObject);
                
                if (!(gameObject is Bullet) || intersectedObject == null || intersectedObject is Bullet ||
                    intersectedObject is IBonus || intersectedObject is Spawner) return;
                
                var obj = FindIntersectedObject(gameObject);
                obj.Health -= (int)Math.Ceiling(gameObject.Size * 5);
                
                if (obj.Health <= 0)
                    DoKill(obj);
                
                gameObject.Kill();
            }
        }

        internal void CheckWallCollision(IGameObject gameObject)
        {
            var newLocation = GetNewLocation(gameObject);
            if (!(newLocation.X > 0) || !(newLocation.Y > 0) || !(newLocation.X < Width) || !(newLocation.Y < Height))
            {
                if (gameObject is Bullet)
                    gameObject.Kill();
            }
            else
                gameObject.Location = newLocation;
        }

        private Vector GetNewLocation(IGameObject gameObject)
        {
            var deltaLocation = new Vector(1, 0).Rotate(gameObject.Direction) 
                                * gameObject.Speed * gameObject.SpeedFactor;
            return gameObject.Location + deltaLocation;
        }
    }
}