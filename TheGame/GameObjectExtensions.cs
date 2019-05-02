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
            var r = GetObjectRadius(gameObject);
            var rect = GetObjectBody(gameObject);
            switch (gameObject)
            {
                case SimpleEnemy _:
                    e.FillEllipse(Brushes.Gray, rect);
                    break;
                case SmartEnemy _:
                    e.FillEllipse(Brushes.Silver, rect);
                    break;
                case Bonus _:
                    e.FillEllipse(Brushes.Plum, rect);
                    return;
                case Player _:
                    e.FillEllipse(Brushes.Maroon, rect);
                    break;
            }
            var v = new Vector(1, 0).Rotate(gameObject.Direction) * gameObject.Size * 5;
            v += gameObject.Location;
            e.FillEllipse(Brushes.Chartreuse,  (float)v.X - gameObject.Size, (float)v.Y - gameObject.Size, 
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
            return gameObject.Size * 5;
        }
    }
}