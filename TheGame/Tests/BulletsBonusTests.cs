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
    public class BulletsBonusTests
    {
        [Test]
        public void Creation()
        {
            var bonus = new BulletBonus(new Vector(5, 5), 10);
        }
        
        [Test]
        public void Using()
        {
            var bonus = new BulletBonus(new Vector(5, 5), 10);
            var game = new Game();
            bonus.Use(game);
            Assert.True(game.Player.BulletsCount == 15);
            
        }
    }
}