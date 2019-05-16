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
    public class HealthBonusTests
    {
        [Test]
        public void Creation()
        {
            var bonus = new HealthBonus(new Vector(5, 5), 10);
        }
        
        [Test]
        public void Using()
        {
            var bonus = new HealthBonus(new Vector(5, 5), 10);
            var game = new Game();
            bonus.Use(game);
            Assert.True(game.Player.Health == 20);
            
        }
    }
}