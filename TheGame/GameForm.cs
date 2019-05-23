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
            ClientSize = new Size(1000, 640);
            var game = new Game();
            DoubleBuffered = true;
            BackColor = ColorTranslator.FromHtml("#2F2933");
            
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
                ControlElements.Score.Text = game.GlobalScore.ToString();
                ControlElements.Bullets.Text = game.Player.BulletsCount.ToString();
                ControlElements.Health.Text = game.Player.Health.ToString();
                ControlElements.Skill.Text = game.Skill?.ToString();
                ControlElements.Lvl.Text = game.Lvl.ToString();
                if (game.IsOver)
                {
                    ControlElements.GameOver.Left = 500 - ControlElements.GameOver.Width / 2;
                    ControlElements.GameOver.Top = 320 - ControlElements.GameOver.Height / 2;
                    ControlElements.GameOver.Text = "GAME OVER";
                }
                else
                {
                    ControlElements.GameOver.Text = "";
                    game.Player.Draw(game, args.Graphics);
                    foreach (var gameObject in game.GameObjects)
                        gameObject.Draw(game, args.Graphics);
                    game.Update();
                }
            };

            KeyDown += (sender, ev) =>
            {
                var moveKeys = new Keys[2]
                {
                    Keys.Up, Keys.W
                };
                
                var turnLeftKeys = new Keys[2]
                {
                    Keys.Left, Keys.A
                };
                var useSkill = new Keys[3]
                {
                    Keys.ShiftKey, Keys.ControlKey, Keys.Q
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
                
                if (ev.KeyCode == Keys.Space)
                    game.Player.IsFire = true;
                
                if (useSkill.Contains(ev.KeyCode))
                    game.Skill?.Use(game);

                if (ev.KeyCode == Keys.R)
                    game = new Game();
                
                if (ev.KeyCode == Keys.S)
                    Saver.SaveTheGame(game);

                if (ev.KeyCode == Keys.L)
                    game = Saver.LoadTheGame();

            };
            
            KeyUp += (sender, ev) =>
            {
                var moveKeys = new Keys[2]
                {
                    Keys.Up, Keys.W
                };
                
                var turnKeys = new Keys[4]
                {
                    Keys.Left, Keys.A, Keys.Right, Keys.D
                };
                
                var fireKey = Keys.Space;             
                if (moveKeys.Contains(ev.KeyCode))
                    game.Player.IsMove = false;
                
                if (turnKeys.Contains(ev.KeyCode))
                    game.Player.Turn = Turn.None;
                
                if (ev.KeyCode == fireKey)
                    game.Player.IsFire = false;
            };

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }
    }
}