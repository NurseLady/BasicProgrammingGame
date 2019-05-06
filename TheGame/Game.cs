using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGame
{
    public class Game
    {
        public Player Player { get; private set; }
        public int Score { get; set; }
        public bool IsOver { get; private set; }
        public List<IGameObject> GameObjects { get; private set; }

        public readonly int Height;
        public readonly int Width;
        
        public Game()
        {
            Player = MapCreator.GetPlayer();
            Width = MapCreator.GameWidth;
            Height = MapCreator.GameHeight;
            GameObjects = MapCreator.CreateRandomMap();
            Score = 0;
            IsOver = false;
        }

        public void Update()
        {
            MoveAllObjects();
            Player.Move(this);
            if (!Player.IsAlive)
            {
                IsOver = true;
                return;
            }
            HandlePlayerIntersection();
            UpdateListOfObjects();
        }

        private void UpdateListOfObjects()
        {
            GameObjects = GameObjects.Where(o => o.IsAlive).ToList();
        }

        private void HandlePlayerIntersection() => FindIntersectedObject(Player)?.Use(this);
        
        private IGameObject FindIntersectedObject(IGameObject gameObject)
        {
            var nearest = GameObjects
                .Where(o => o != gameObject)
                .OrderBy(o => o.GetActualDistance(gameObject))
                .FirstOrDefault();
            if (nearest != null)
                return nearest.GetActualDistance(gameObject) < 1 ? nearest : null;
            return null;
        }
        
        private void MoveAllObjects()
        {
            foreach (var gameObject in GameObjects)
                Move(gameObject);
        }

        private void Move(IGameObject gameObject)
        {
            gameObject.UpdateDirection();
            CheckWallCollision(gameObject);
            DoKill(gameObject);
        }

        private void DoKill(IGameObject gameObject)
        {
            if (!(gameObject.Health > 0 || gameObject is Bonus || gameObject is Bullet))
            {
                if (gameObject is IEnemy enemy)
                    Score += enemy.Costs;
                gameObject.Kill();
            }
            else if (gameObject is Bullet && FindIntersectedObject(gameObject) != null
                                          && !(FindIntersectedObject(gameObject) is Bullet))
            {
                FindIntersectedObject(gameObject).Health -= (int)(gameObject.Size * 10);
                gameObject.Kill();
            }
        }

        private void CheckWallCollision(IGameObject gameObject)
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