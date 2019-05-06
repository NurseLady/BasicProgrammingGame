using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace TheGame
{
    public static class GameObjectExtensions
    {
        public static void Draw(this IGameObject gameObject, Game game, Graphics e)
        {
            var v = new Vector(0,0);
            if (gameObject is Bullet)
            {
                v = gameObject.Location;
                e.FillEllipse(new SolidBrush(gameObject.MainСolor),  
                    (float)v.X - gameObject.Size*10, (float)v.Y - gameObject.Size*10, 
                    gameObject.Size * 20, gameObject.Size * 20);
                return;
            }
            var rect = GetObjectBody(gameObject);
            e.FillEllipse(new SolidBrush(gameObject.MainСolor), rect);
            v = new Vector(1, 0).Rotate(gameObject.Direction) * gameObject.Size * 5;
            v += gameObject.Location;
            var color = new Bullet(new Vector(0, 0),0, 0 ).MainСolor;
            e.FillEllipse(new SolidBrush(color),  (float)v.X - gameObject.Size, (float)v.Y - gameObject.Size, 
            gameObject.Size * 2, gameObject.Size * 2);
        }

        public static Rectangle GetObjectBody(this IGameObject gameObject)
        {
            var r = GetObjectRadius(gameObject);
            var leftTopCorner = new Vector(gameObject.Location.X - r, 
             gameObject.Location.Y - r);
            return new Rectangle((int)leftTopCorner.X, (int)leftTopCorner.Y, r * 2, r * 2);
        }

        public static int GetObjectRadius(this IGameObject gameObject)
        {
            return (int) gameObject.Size * 5;
        }
        
        public static double GetActualDistance(this IGameObject a, IGameObject b)
        {
            return a.Location.GetDistance(b.Location) - a.GetObjectRadius() - b.GetObjectRadius();
        }
    }
}