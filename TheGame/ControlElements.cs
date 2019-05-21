using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheGame
{
    public static class ControlElements
    {
        public static readonly Control ScoreLabel = new Label
        {
            Text = "Score: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, 620),
            ForeColor = Color.Silver
        };
        public static readonly Control Score = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(ScoreLabel.Right, 620),
            ForeColor = Color.Silver
        };

        private static readonly Control BulletsLabel = new Label
        {
            Text = "Bullets: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, 20),
            ForeColor = Color.Blue
        };
        public static readonly Control Bullets = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(BulletsLabel.Right, 20),
            ForeColor = Color.Silver
        };

        private static readonly Control HealthLabel = new Label
        {
            Text = "Health: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, BulletsLabel.Bottom),
            ForeColor = Color.Crimson
        };
        public static readonly Control Health = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(HealthLabel.Right, BulletsLabel.Bottom),
            ForeColor = Color.Silver
        };

        private static readonly Control SkillLabel = new Label()
        {
            Text = "Skill: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(Bullets.Right, 20),
            ForeColor = Color.Silver
        };

        internal static readonly Control Skill = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(SkillLabel.Right, 20),
            ForeColor = Color.Silver
        };
        
        public static readonly Control LvlLabel = new Label
        {
            Text = "Level: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(Health.Right, SkillLabel.Bottom),
            ForeColor = Color.Silver
        };
        public static readonly Control Lvl = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(LvlLabel.Right, SkillLabel.Bottom),
            ForeColor = Color.Silver
        };
        
        public static readonly Control GameOver = new Label
        {
            Font = new Font("Arial", 42),
            AutoSize = true,
            Location = new Point(250, 320),
            ForeColor = Color.Silver
        };
        public static readonly List<Control> Controls = new List<Control>
        {
            ScoreLabel, Score, BulletsLabel, Bullets, HealthLabel, Health, SkillLabel, Skill, LvlLabel, Lvl, GameOver
        };
    }
}
