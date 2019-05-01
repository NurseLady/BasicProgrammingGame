using System;
using System.Collections.Generic;
using System.Drawing;
namespace TheGame
{
    public static class GameObjectExtensions
    {
         public static void Draw(this IGameObject gameObject, Game game, Graphics e)
        {
            var rnd = new Random();

            var d = gameObject.Size * 10;
            Vector LeftTopCorner = new Vector(gameObject.Location.X - d / 2, 
                                              gameObject.Location.Y - d / 2);
            var rect = new Rectangle((int)LeftTopCorner.X,
                (int)LeftTopCorner.Y, d, d);
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
                    break;
                case Bullet _:
                    e.FillEllipse(Brushes.Tan, rect);
                    break;
                case Player _:
                    e.FillEllipse(Brushes.Maroon, rect);
                    break;
            }
            var v = new Vector(1, 0).Rotate(gameObject.Direction) * d / 2;
            v += gameObject.Location;
            e.FillEllipse(Brushes.Chartreuse, (float) v.X - 2, (float)v.Y - 2, 4, 4);
        }
    }
}