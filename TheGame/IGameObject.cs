namespace TheGame
{
    public interface IGameObject
    {
        Vector Location { get; set; } 
        double Direction { get; } 
        int Size { get;  }
        int Speed { get; }
        double SpeedFactor { get; }
        int Health { get; set; }
        bool IsAlive { get; }
        
        void UpdateDirection();
        void Kill();
        void Use(Game game);
    }
}