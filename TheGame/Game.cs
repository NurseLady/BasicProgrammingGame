using System.Collections.Generic;

namespace TheGame
{
    public class Game
    {
        public Player Player { get; private set; }
        public int Score { get; private set; }
        public bool IsOver { get; private set; }
        public List<IGameObject> GameObjects { get; private set; }

        private int Height;
        private int Width;
        
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
            Player.Move();
        }

        public IGameObject FindIntersectedObject()
        {
            throw new System.NotImplementedException();
        }

        private void MoveAllObjects()
        {
            foreach (var gameObject in GameObjects)
            {
                Move(gameObject);
            }
        }

        private void Move(IGameObject gameObject)
        {
            gameObject.UpdateDirection();
            var deltaLocation = new Vector(1, 0).Rotate(gameObject.Direction) 
                                * gameObject.Speed * gameObject.SpeedFactor;
            gameObject.Location += deltaLocation;
        }
    }
}