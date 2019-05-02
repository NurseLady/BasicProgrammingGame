using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheGame
{
    public static class ControlElements
    {
        public static Control scoreLabel = new Label
        {
            Text = "SCORE: ",
            Font = new Font("Arial", 15),
            Size = new Size(105, 25),
            Location = new Point(0, 600),
            ForeColor = Color.Silver
        };
        public static Control score = new Label
        {
            Font = new Font("Arial", 15),
            AutoSize = true,
            Location = new Point(scoreLabel.Right, 600),
            ForeColor = Color.Silver
        };

        public static Control gameOver = new Label
        {
            Font = new Font("Times New Roman", 42),
            AutoSize = true,
            Location = new Point(300, 350),
            ForeColor = Color.Red
        };
        public static List<Control> Controls = new List<Control>
        {
            scoreLabel, score, gameOver
        };
    }
}
