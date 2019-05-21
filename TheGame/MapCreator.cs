using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TheGame
{
    public class MapCreator
    {
        public const int GameWidth = 1000;
        public const int GameHeight = 640;
        
        private Random random = new Random();

        private int maxSimpleEnemyCount = 3;
        private int maxSmartEnemyCount = 2;
        private int maxBonusCount = 5;
        private int maxLifeCount = 15;
        private int maxSpeedCount = 10;
        private int maxSizeCount = 10;
        private double speedFactor = 0.3;
        private List<IGameObject> GameObjects = new List<IGameObject>();
        private Game game;
        private int lvl;
        private Dictionary<string, Spawner> spawners = new Dictionary<string, Spawner>();

        public MapCreator(Game game)
        {
            this.game = game;
            lvl = game.Lvl;
            CreateSpawners();
        }

        private void CreateSpawners()
        {
            spawners.Clear();
            spawners.Add("SimpleEnemy", new Spawner(new SimpleEnemy(new Vector(0,0),0,game.Lvl+1, (game.Lvl+1)*4,5 * (game.Lvl + 1), 25*game.Lvl), game));
            spawners.Add("SmartEnemy", new Spawner(new SmartEnemy(new Vector(0,0),0,game.Lvl+2, (game.Lvl+1)*5,6 * (game.Lvl + 1), 30*game.Lvl), game));
            spawners.Add("EasySimpleEnemy", new Spawner(new SimpleEnemy(new Vector(0,0),0,2, (game.Lvl+1)*4,5 * (game.Lvl + 1), 25*game.Lvl), game));
            
            spawners.Add("BulletBonus", new Spawner(new BulletBonus(new Vector(0,0),(game.Lvl+1)*5), game));
            spawners.Add("SpeedSkillBonus", new Spawner(new SpeedSkillBonus(new Vector(0,0),1), game));
            spawners.Add("ThunderSkillBonus", new Spawner(new ThunderSkillBonus(new Vector(0,0),game.Lvl+2), game));
        }
        
        public Player GetPlayer()
        {
            return new Player(new Vector(GameWidth / 2, GameHeight / 2), -Math.PI / 2, speedFactor: speedFactor);
        }

        public List<IGameObject> CreateRandomMap()
        {
            for (var i = 0; i < 6; i++)
                GameObjects.Add(CreateRandomObject());
            return GameObjects;
        }

        public IGameObject CreateRandomObject()
        {
            var s = spawners.ToList();
            Spawner spawner;

            if (IsThereChance(45))
                spawner = s[random.Next(2)].Value;
            else if (IsThereChance(30))
                spawner = s[2].Value;
            else if (IsThereChance(70))
                spawner = s[random.Next(3, 4)].Value;
            else
                spawner = s[random.Next(4, s.Count)].Value;
            spawner.SetLocation(new Vector(random.Next(10,GameWidth), random.Next(10,GameHeight)));
            spawner.SetDirection(random.NextDouble() * Math.PI);
            return spawner.Clone();
        }

        public void UpdateMap()
        {
            if (game.Lvl > lvl)
            {
                lvl = game.Lvl;
                CreateSpawners();
            }
            if (game.NewObjects.Count == 0 && (game.GameObjects.Count == 0
                || IsThereChance(1) && IsThereChance(1)))
                game.NewObjects.AddRange(CreateRandomMap());
            else if (IsThereChance(1))
                if (IsThereChance(10))
                    game.NewObjects.Add(CreateRandomObject());
        }
        
        private bool IsThereChance(int percents)
        {
            var answer = new List<bool>();
            for (var i = 0; i < percents; i++)
                answer.Add(true);
            for (var i = 0; i < 100 - percents; i++)
                answer.Add(false);
            var a = answer.OrderBy(e => random.Next(100));
            return a.FirstOrDefault();
        }
    }
}