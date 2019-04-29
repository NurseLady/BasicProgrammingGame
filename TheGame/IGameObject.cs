namespace TheGame
{
    public interface IGameObject
    {
        Vector Location { get; } 
        double Direction { get; } 
        int Size { get;  }
        bool IsAlive { get; }
        
        void Move();
        void Kill();
        void Use(Game game);
    }
}