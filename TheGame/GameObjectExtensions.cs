using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace TheGame
{
    public static class GameObjectExtensions
    {
        public static void Draw(this IGameObject gameObject, Game game, Graphics e)
        {
            var rect = GetObjectBody(gameObject);
            e.FillEllipse(new SolidBrush(gameObject.MainСolor), rect);
            
            if (gameObject is IBonus || gameObject is Bullet || gameObject is Spawner) return;
            
            var v = new Vector(1, 0).Rotate(gameObject.Direction) * gameObject.Size * 5;
            v += gameObject.Location;
            var color = new Bullet(new Vector(0, 0),0, 0 ).MainСolor;
            e.FillEllipse(new SolidBrush(color),  (float)v.X - gameObject.Size, (float)v.Y - gameObject.Size, 
            gameObject.Size * 2, gameObject.Size * 2);
        }

        public static Rectangle GetObjectBody(this IGameObject gameObject)
        {
            var r = GetObjectRadius(gameObject);
            var leftTopCorner = new Vector(gameObject.Location.X - r, gameObject.Location.Y - r);
            return new Rectangle((int)leftTopCorner.X, (int)leftTopCorner.Y, r * 2, r * 2);
        }

        public static int GetObjectRadius(this IGameObject gameObject)
        {
            return (int) (gameObject.Size * 5);
        }
        
        public static double GetActualDistance(this IGameObject a, IGameObject b)
        {
            return a.Location.GetDistance(b.Location) - a.GetObjectRadius() - b.GetObjectRadius();
        }

        public static IGameObject FromString(this string s, bool GameObjectFlag)
        {
            if (s == null) return null;
            IGameObject obj = null;
            try
            {
                obj = JsonConvert.DeserializeObject<SimpleEnemy>(s);
            }
            catch
            {}
            try
            {
                obj = JsonConvert.DeserializeObject<SmartEnemy>(s);
            }
            catch
            {}
            try
            {
                obj = JsonConvert.DeserializeObject<BulletBonus>(s);
            }
            catch
            {}
            try
            {
                obj = JsonConvert.DeserializeObject<SpeedSkillBonus>(s);
            }
            catch
            {}
            try
            {
                obj = JsonConvert.DeserializeObject<ThunderSkillBonus>(s);
            }
            catch
            {}

            switch (obj)
            {
                case SimpleEnemy enemy:
                    return enemy;
                case SmartEnemy enemy:
                    return enemy;
                case SpeedSkillBonus bonus:
                    return bonus;
                case ThunderSkillBonus bonus:
                    return bonus;
                case BulletBonus bonus:
                    return bonus;
                default:
                    return null;
            }
        }
    }
}