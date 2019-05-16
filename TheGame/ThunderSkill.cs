using System;
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
        private Vector playerLocation;
        private double playerDirection;
        private Bullet bullet;
        private Action gameMode;
        
        public ThunderSkill(int maxTargetsCount)
        {
            this.maxTargetsCount = maxTargetsCount;
        }
        
        public void GameMode()
        {
            game.MoveAllObjects(Move);
            game.UpdateListOfObjects();

            if (bullet == null || (bullet != null && !bullet.IsAlive))
            {
                
                nextTarget = GetNextTarget(GetEnemiesList(game.GameObjects));
                if (nextTarget == null || damage <= 0 || actualTargetsCount == maxTargetsCount)
                {
                    Deactivate();
                    return;
                }
                bullet = new Bullet(lastTarget.Location, GetBulletDirection(), damage, 70);
                game.GameObjects.Add(bullet);
                damage -= (int) ((double) maxDamage / maxTargetsCount + 0.002 * lastTarget.GetActualDistance(nextTarget));
                
                actualTargetsCount++;
                lastTarget = nextTarget;
            }
            game.Player.Move(game);
            game.Player.Location = playerLocation;
            game.Player.Direction = playerDirection;
        }
        private void Deactivate()
        {
            game.Skill = null;
            game.GameMode = gameMode;

        }

        public void Use(Game game)
        {
            this.game = game;
            playerLocation = game.Player.Location;
            playerDirection = game.Player.Direction;
            
            gameMode = game.GameMode;
            game.GameMode = GameMode;   
            IsActive = true;
            lastTarget = new SmartEnemy(game.Player.Location, 0, 0, 0, 0, 0);
            lastTarget.Kill();
            maxDamage = FindMaxHealth(game.GameObjects);
            damage = maxDamage;
        }

        private int FindMaxHealth(List<IGameObject> gameObjects)
        {
            var health = GetEnemiesList(gameObjects)
                .OrderByDescending(o => o.Health)
                .FirstOrDefault()?.Health;
            if (health != null)
                return (int) health;
            return 0;
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
        
        private IEnemy GetNextTarget(List<IEnemy> enemies)
        {        
            return enemies.OrderByDescending(GetAttraction).FirstOrDefault();
        }

        private double GetAttraction(IEnemy enemy)
        {
            var k1 = 1;
            var k2 = 1;
            var k3 = 0.5;
            var fine = (enemy.Health - damage)*k3;
            return enemy.Costs * k1 + k2 / lastTarget.GetActualDistance(enemy) - Math.Abs(fine);
        }
        
        public override string ToString()
        {
            return $"ThunderSkill {maxTargetsCount}";
        }
    }
}