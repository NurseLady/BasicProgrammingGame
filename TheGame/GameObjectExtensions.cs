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
                    break;
                case Bullet _:
                    e.FillEllipse(Brushes.Tan, rect);
                    break;
                case Player _:
                    e.FillEllipse(Brushes.Maroon, rect);
                    break;
            }
        }
    }
}