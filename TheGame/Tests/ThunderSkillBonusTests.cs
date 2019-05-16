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
    public class ThunderSkillBonusTests
    {
        [Test]
        public void Creation()
        {
            var bonus = new ThunderSkillBonus(new Vector(5, 5), 1);
        }
        
        [Test]
        public void Using()
        {
            var bonus = new ThunderSkillBonus(new Vector(5, 5), 1);
            var game = new Game();
            bonus.Use(game);
            Assert.True(game.Skill is ThunderSkill);          
        }
    }
}