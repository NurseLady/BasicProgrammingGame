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
    public class SpeedSkillBonusTests
    {
        [Test]
        public void Creation()
        {
            var bonus = new SpeedSkillBonus(new Vector(5, 5), 1);
        }
        
        [Test]
        public void Using()
        {
            var bonus = new SpeedSkillBonus(new Vector(5, 5), 1);
            var game = new Game();
            bonus.Use(game);
            Assert.True(game.Skill is SpeedSkill);          
        }
    }
}