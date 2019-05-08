namespace TheGame
{
    public interface ISkill
    {
        bool IsActive { get; }
        void Deactivate(Game game);
        void Use(Game game);
    }
}