namespace TheGame
{
    public interface IGameObject
    {
        Vector Location { get; set; } 
        double Direction { get; } 
        int Size { get;  }
        int Speed { get; }
        double SpeedFactor { get; }
        int Life { get; }
        bool IsAlive { get; }
        
        void UpdateDirection();
        void Kill();
        void Use(Game game);
    }
}