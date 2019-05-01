using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            var game = new Game();
            DoubleBuffered = true;
            var time = 0;
            var timer = new Timer
            {
                Interval = 1
            };
            timer.Tick += (sender, args) =>
            {
                time++;
                Invalidate();
            };
            timer.Start();
            foreach (var control in ControlElements.Controls)
                Controls.Add(control);
            Paint += (sender, args) =>
            {
                ControlElements.score.Text = game.Score.ToString();
                if (game.IsOver)
                {
                    BackColor = Color.Black;
                    ControlElements.gameOver.Text = "GAME OVER";
                    ControlElements.scoreLabel.Location = new Point(380,
                        ControlElements.gameOver.Bottom + 20);
                    ControlElements.scoreLabel.ForeColor = Color.Red;
                    ControlElements.score.Location = new Point(ControlElements.scoreLabel.Right + 20,
                        ControlElements.scoreLabel.Top);
                    ControlElements.score.ForeColor = Color.Red;
                }
                else
                {
                    game.Player.Draw(game, args.Graphics);
                    foreach (var gameObject in game.GameObjects)
                        gameObject.Draw(game, args.Graphics);
                    game.Update();
                }
            };

            KeyDown += (sender, ev) =>
            {
                var moveKeys = new Keys[3]
                {
                    Keys.Up, Keys.W, Keys.Space
                };
                
                var turnLeftKeys = new Keys[2]
                {
                    Keys.Left, Keys.A
                };
                
                var turnRightKeys = new Keys[2]
                {
                    Keys.Right, Keys.D
                };
                
                if (moveKeys.Contains(ev.KeyCode))
                    game.Player.IsMove = true;
                
                if (turnLeftKeys.Contains(ev.KeyCode))
                    game.Player.Turn = Turn.Left;
                
                if (turnRightKeys.Contains(ev.KeyCode))
                    game.Player.Turn = Turn.Right;
            };
            
            KeyUp += (sender, ev) =>
            {
                var moveKeys = new Keys[3]
                {
                    Keys.Up, Keys.W, Keys.Space
                };
                
                var turnKeys = new Keys[4]
                {
                    Keys.Left, Keys.A, Keys.Right, Keys.D
                };
                
                if (moveKeys.Contains(ev.KeyCode))
                    game.Player.IsMove = false;
                
                if (turnKeys.Contains(ev.KeyCode))
                    game.Player.Turn = Turn.None;
            };

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }
    }
}