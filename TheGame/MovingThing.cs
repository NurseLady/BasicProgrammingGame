using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    //Всё что угодно что умеет двигаться. Базовый класс, все прочие движущиеся штуки наследуй отсюда
    class MovingThing
    {
        public MovingThing(Vector location, Vector velocity, double direction)
        {
            Location = location;
            Velocity = velocity;
            Direction = direction;
        }

        public readonly Vector Location;
        public readonly Vector Velocity;
        public readonly double Direction;
    }
}
