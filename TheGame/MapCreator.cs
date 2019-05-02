using System;
using System.Collections.Generic;

namespace TheGame
{
    public class MapCreator
    {
        public const int GameWidth = 1000;
        public const int GameHeight = 640;
        
        private static Random random = new Random();

        private static int maxSimpleEnemyCount = 3;
        private static int maxSmartEnemyCount = 2;
        private static int maxBonusCount = 5;
        private static int maxLifeCount = 15;
        private static int maxSpeedCount = 10;
        private static int maxSizeCount = 10;
        private static double speedFactor = 0.3 ;
        private static List<IGameObject> GameObjects = new List<IGameObject>();
        
        
        public static Player GetPlayer()
        {
            return new Player(new Vector(GameWidth / 2, GameHeight / 2), -Math.PI / 2, speedFactor: speedFactor);
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
            GameObjects.Add(new Bonus(new Vector(30, 200), Math.PI/3, 70));
        }

        private static void AddSmartEnemies()
        {
            GameObjects.Add(new SmartEnemy(new Vector(200, 300), 3, 2,5,3,3, speedFactor));
        }

        private static void AddSimpleEnemies()
        {
           GameObjects.Add(new SimpleEnemy(new Vector(600, 400), 3, 3,5,3,3, speedFactor ));
        }
    }
}