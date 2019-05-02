using System;
using System.Collections.Generic;
using System.Drawing;
namespace TheGame
{
    public static class GameObjectExtensions
    {
         public static void Draw(this IGameObject gameObject, Game game, Graphics e)
         {
             var r = gameObject.Size * 5;
             Vector LeftTopCorner = new Vector(gameObject.Location.X - r, 
                                               gameObject.Location.Y - r);
            var rect = new Rectangle((int)LeftTopCorner.X,
                (int)LeftTopCorner.Y, r * 2, r * 2);
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
            var v = new Vector(1, 0).Rotate(gameObject.Direction) * r ;
            v += gameObject.Location;
            e.FillEllipse(Brushes.Chartreuse,  (float)v.X - gameObject.Size, (float)v.Y - gameObject.Size, 
                gameObject.Size * 2, gameObject.Size * 2);
        }
    }
}