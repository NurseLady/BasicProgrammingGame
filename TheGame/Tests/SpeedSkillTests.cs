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
    public class SpeedSkillTests
    {
        [Test]
        public void Creation()
        {
            var game = new Game();
            game.Skill = new SpeedSkill(1);
        }
        
        [Test]
        public void Deactivate()
        {
            var game = new Game();
            game.Skill = new SpeedSkill(0);
            game.Skill.Use(game);
            game.GameMode();
            Assert.Null(game.Skill);
        }
        
        [Test]
        public void Using()
        {
            var game = new Game();
            game.Skill = new SpeedSkill(1);
            game.Skill.Use(game);
            game.GameMode();
            Assert.True(Math.Abs(game.Player.ActualSpeed - 45) < 0.00001);
        }
    }
}