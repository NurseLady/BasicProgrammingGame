namespace TheGame
{
    public interface ISkill
    {
        bool IsActive { get; }
        void GameMode();
        void Use(Game game);
    }
}