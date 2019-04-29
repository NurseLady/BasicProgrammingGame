using System;
using System.Collections.Generic;

namespace TheGame
{
    public class MapCreator
    {
        public const int GameWidth = 1080;
        public const int GameHeight = 720;
        
        private static Random random = new Random();

        private static int maxSimpleEnemyCount;
        private static int maxSmartEnemyCount;
        private static int maxBonusCount;
        

        public static Player GetPlayer()
        {
            return new Player(new Vector(0, 0), 90);
        }

        public static List<IGameObject> CreateRandomMap()
        {
            return new List<IGameObject>();
        }
    }
}