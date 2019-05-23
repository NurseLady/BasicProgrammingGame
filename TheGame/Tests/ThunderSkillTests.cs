using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TheGame.Tests
{
    [TestFixture]
    public class ThunderSkillTests
    {
        [Test]
        public void Creation()
        {
            var game = new Game();
            game.Skill = new ThunderSkill(2);
        }
        
        [Test]
        public void DeactivateWithoutTargets()
        {
            var game = new Game(new List<IGameObject>());
            game.Skill = new ThunderSkill(2);
            
            game.Skill.Use(game);
            game.GameMode();
            Assert.Null(game.Skill);
        }
        
        [Test]
        public void DeactivateWithZeroMaxTargetsCount()
        {
            var game = new Game(new List<IGameObject>());
            game.Skill = new ThunderSkill(0);
            
            game.Skill.Use(game);
            game.GameMode();
            Assert.Null(game.Skill);
        }
        
        [Test]
        public void DeactivateWithZeroDamage()
        {
            var map = new List<IGameObject>();
            map.Add(new SimpleEnemy(new Vector(0,0),0,0,0,0,0 ));
            var game = new Game(map);
            game.Skill = new ThunderSkill(1);
            
            game.Skill.Use(game);
            game.GameMode();
            Assert.Null(game.Skill);
        }
        
        [Test]
        public void CorrectDeactivateGameMode()
        {
            var game = new Game();
            game.Skill = new ThunderSkill(0);
            
            game.Skill.Use(game);
            game.GameMode();
            Action gm = game.UsualGameMode;

            Assert.AreEqual(game.GameMode, gm);
        }
        
        [Test]
        public void KillOneEnemy()
        {
            var map = new List<IGameObject>();
            var enemy = new SimpleEnemy(new Vector(0, 0), 0, 1, 0, 10, 0);
            map.Add(enemy);
            var game = new Game(map);
            game.Skill = new ThunderSkill(1);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.False(game.GameObjects.Contains(enemy));
        }
        
        [Test]
        public void KillAllEnemiesOnUsualMap()
        {
            var map = CreateUsualMap();
            var game = new Game(map);
            game.Skill = new ThunderSkill(6);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.True(game.GameObjects.Where(o => o is IEnemy).ToList().Count == 0);
        }
        
        [Test]
        public void KillOneEnemyOnUsualMap()
        {
            var map = CreateUsualMap();
            var game = new Game(map);
            game.Skill = new ThunderSkill(1);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.True(game.Score == 30);
        }
        
        [Test]
        public void KillTwoEnemiesOnUsualMap()
        {
            var map = CreateUsualMap();
            var game = new Game(map);
            game.Skill = new ThunderSkill(3);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.True(game.Score == 50);
        }
        
        
        [Test]
        public void KillAllEnemiesOnGigantHealthMap()
        {
            var map = CreateGigantHealthMap();
            var game = new Game(map);
            game.Skill = new ThunderSkill(6);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.True(game.GameObjects.Where(o => o is IEnemy).ToList().Count == 0);
        }
        
        [Test]
        public void KillTwoEnemiesOnGigantHealthMap()
        {
            var map = CreateGigantHealthMap();
            var game = new Game(map);
            game.Skill = new ThunderSkill(6);
            
            game.Skill.Use(game);
            while (game.Skill != null)
            {
                game.GameMode();
            }
            Assert.True(game.GameObjects.Where(o => o is IEnemy).ToList().Count == 0);
        }

        private List<IGameObject> CreateUsualMap()
        {
            var map = new List<IGameObject>();
            map.Add(new SmartEnemy(new Vector(200, 300), Math.PI/4, 2,2,7,30));
            map.Add(new SimpleEnemy(new Vector(600, 400), 3, 3,5,3,30));
            map.Add(new SimpleEnemy(new Vector(100, 500), 3, 3,-2,7,20 ));
            return map;
        }
        
        private List<IGameObject> CreateGigantHealthMap()
        {
            var map = new List<IGameObject>();
            map.Add(new SmartEnemy(new Vector(200, 300), Math.PI/4, 2,2,70,30));
            map.Add(new SimpleEnemy(new Vector(600, 400), 3, 3,5,30,30));
            map.Add(new SimpleEnemy(new Vector(100, 500), 3, 3,-2,70,20 ));
            return map;
        }
    }
}
