using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheGame
{
    public static class ControlElements
    {
        public static Control scoreLabel = new Label
        {
            Text = "Score: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, 620),
            ForeColor = Color.Silver
        };
        public static Control score = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(scoreLabel.Right, 620),
            ForeColor = Color.Silver
        };
        public static Control bulletsLabel = new Label
        {
            Text = "Bullets: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, 20),
            ForeColor = Color.Blue
        };
        public static Control bullets = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(bulletsLabel.Right, 20),
            ForeColor = Color.Silver
        };

        public static Control healthLabel = new Label
        {
            Text = "Health: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(20, bulletsLabel.Bottom),
            ForeColor = Color.Crimson
        };
        public static Control health = new Label
        {
            Font = new Font("Arial", 10),
            AutoSize = true,
            Location = new Point(healthLabel.Right, bulletsLabel.Bottom),
            ForeColor = Color.Silver
        };

        public static Control skillLabel = new Label()
        {
            Text = "Skill: ",
            Font = new Font("Arial", 10),
            Size = new Size(65, 25),
            Location = new Point(bullets.Right, bullets.Bottom),
            ForeColor = Color.Silver
        };
        public static Control gameOver = new Label
        {
            Font = new Font("Arial", 42),
            AutoSize = true,
            Location = new Point(300, 350),
            ForeColor = Color.Silver
        };
        public static List<Control> Controls = new List<Control>
        {
            scoreLabel, score, bulletsLabel, bullets, healthLabel, health, gameOver
        };
    }
}
