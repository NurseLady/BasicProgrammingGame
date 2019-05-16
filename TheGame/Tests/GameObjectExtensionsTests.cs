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
    public class GameObjectsExtensionsTest
    {
        [Test]
        public void GetObjectRadiusTest()
        {
            var obj = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            Assert.AreEqual(10, obj.GetObjectRadius());
        }
        
        [Test]
        public void GetObjectBodyTest()
        {
            var obj = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            var rect = new Rectangle(-10, -10, 20,20);
            Assert.AreEqual(rect, obj.GetObjectBody());
        }
        
        [Test]
        public void GetActualDistanceZeroTest()
        {
            var obj1 = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            var obj2 = new SimpleEnemy(new Vector(0,20), 0,2,0,0,0);
            Assert.AreEqual(0, obj1.GetActualDistance(obj2));
        }
        
        [Test]
        public void GetActualDistanceUnderZeroTest()
        {
            var obj1 = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            var obj2 = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            Assert.True(obj1.GetActualDistance(obj2) < 0);
        }
        
        [Test]
        public void GetActualDistanceNotZeroTest()
        {
            var obj1 = new SimpleEnemy(new Vector(0,0), 0,2,0,0,0);
            var obj2 = new SimpleEnemy(new Vector(0,30), 0,2,0,0,0);
            Assert.AreEqual(10, obj1.GetActualDistance(obj2));
        }
    }
}