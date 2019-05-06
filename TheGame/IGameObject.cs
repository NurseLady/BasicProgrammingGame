using System.Drawing;

namespace TheGame
{
    public interface IGameObject
    {
        Vector Location { get; set; } 
        double Direction { get; } 
        float Size { get;  }
        int Speed { get; }
        double SpeedFactor { get; }
        int Health { get; set; }
        bool IsAlive { get; }
        Color MainСolor { get; }
        
        void UpdateDirection();
        void Kill();
        void Use(Game game);
    }
}