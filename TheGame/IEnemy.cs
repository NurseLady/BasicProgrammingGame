namespace TheGame
{
    public interface IEnemy : IGameObject
    {
        bool IsMet { get; set; }
        int Costs { get; }
    }
}