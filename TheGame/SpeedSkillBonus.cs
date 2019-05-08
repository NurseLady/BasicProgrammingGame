using System.Drawing;

namespace TheGame
{
    public class SpeedSkillBonus : IBonus
    {
        public Vector Location { get; set; }
        public double Direction { get; }
        public float Size { get; }
        public int Speed { get; }
        public double SpeedFactor { get; }
        public int Health { get; set; }
        public bool IsAlive { get; private set; }
        public Color MainСolor { get; } = ColorTranslator.FromHtml("#CEFFAD");
        public int Costs { get; }
        public void UpdateDirection(){}

        public SpeedSkillBonus(Vector location, int costs)
        {
            Location = location;
            Size = 1;
            Costs = costs;
            Speed = 0;
            IsAlive = true;
        }
        public void Kill() => IsAlive = false;

        public void Use(Game game)
        {
            game.Skill = new SpeedSkill(Costs);
            Kill();
        }
    }
}