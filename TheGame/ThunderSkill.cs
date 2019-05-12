using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TheGame
{
    public class ThunderSkill : ISkill
    {
        public bool IsActive { get; private set; }
        private IEnemy lastTarget;
        private IEnemy nextTarget;
        private readonly int maxTargetsCount;
        private int actualTargetsCount = 0;
        private int maxDamage;
        private int damage;
        private Game game;
        
        public ThunderSkill(int maxTargetsCount)
        {
            this.maxTargetsCount = maxTargetsCount;
        }
        
        public void GameMode()
        {
            game.MoveAllObjects(Move);
            game.UpdateListOfObjects();
            if (!lastTarget.IsAlive)
            {
                nextTarget = GetNextTargetByDijkstra(GetEnemiesList(game.GameObjects));
                if (nextTarget == null || damage == 0 || actualTargetsCount == maxTargetsCount)
                {
                    Deactivate();
                    return;
                }
                    var bullet = new Bullet(lastTarget.Location, GetBulletDirection(), damage, 50);
                    game.GameObjects.Add(bullet);
                    damage -= maxDamage / maxTargetsCount;
                    actualTargetsCount++;
                    lastTarget = nextTarget;
            }
            
        }
        private void Deactivate()
        {
            game.Skill = null;
            game.GameMode -= GameMode;
            game.GameMode += game.UsualGameMode;
        }

        public void Use(Game game)
        {
            this.game = game;
            game.GameMode += GameMode;
            game.GameMode -= game.UsualGameMode;
            IsActive = true;
            lastTarget = new SmartEnemy(game.Player.Location, 0, 0, 0, 0, 0);
            lastTarget.Kill();
            maxDamage = FindMaxHealth(game.GameObjects);
            damage = maxDamage;
        }

        private int FindMaxHealth(List<IGameObject> gameObjects)
        {
            return GetEnemiesList(gameObjects)
                .OrderBy(o => o.Health)
                .First().Health;
        }

        private List<IEnemy> GetEnemiesList(List<IGameObject> gameObjects)
        {
            return gameObjects
                .OfType<IEnemy>()
                .ToList();
        }

        private double GetBulletDirection()
        {
            var v = nextTarget.Location - lastTarget.Location;
            return v.Angle;
        }

        private void Move(IGameObject gameObject)
        {
            if (gameObject is Bullet)
                game.CheckWallCollision(gameObject);
            game.DoKill(gameObject);
        }
        
        class DijkstraData
        {
            public IEnemy Previous { get; set; }
            public int Cost { get; set; }
        }
        
        private IEnemy GetNextTargetByDijkstra(List<IEnemy> enemies)
        {
/*            var track = new Dictionary<IEnemy, DijkstraData>();
            var notVisited = enemies;
            track[lastTarget] = new DijkstraData{Cost = 0, Previous = null};

            while (true)
            {
                IEnemy toOpen = null;
                var bestCost = int.MinValue;
                
                foreach (var enemy in notVisited)
                    if (track.ContainsKey(enemy) && track[enemy].Cost > bestCost)
                    {
                        bestCost = track[enemy].Cost;
                        toOpen = enemy;
                    }
            }*/
            return enemies.FirstOrDefault();

        }
        
        public override string ToString()
        {
            return $"ThunderSkill {maxTargetsCount}";
        }
    }
}