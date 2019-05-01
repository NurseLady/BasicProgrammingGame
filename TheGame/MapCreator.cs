using System;
using System.Collections.Generic;

namespace TheGame
{
    public class MapCreator
    {
        public const int GameWidth = 1080;
        public const int GameHeight = 720;
        
        private static Random random = new Random();

        private static int maxSimpleEnemyCount = 3;
        private static int maxSmartEnemyCount = 2;
        private static int maxBonusCount = 5;
        private static int maxLifeCount = 15;
        private static int maxSpeedCount = 10;
        private static int maxSizeCount = 10;
        private static List<IGameObject> GameObjects = new List<IGameObject>();
        
        
        public static Player GetPlayer()
        {
            return new Player(new Vector(GameWidth / 2, GameHeight / 2), Math.PI / 2);
        }

        public static List<IGameObject> CreateRandomMap()
        {
            AddSimpleEnemies();
            AddSmartEnemies();
            AddBonuses();

            return GameObjects;
        }

        private static void AddBonuses()
        {
            // throw new NotImplementedException();
        }

        private static void AddSmartEnemies()
        {
            //throw new NotImplementedException();
        }

        private static void AddSimpleEnemies()
        {
           // throw new NotImplementedException();
        }
    }
}