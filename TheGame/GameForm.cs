﻿using System;
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
                ControlElements.score.Text = game.Score.ToString();
                ControlElements.bullets.Text = game.Player.BulletsCount.ToString();
                ControlElements.health.Text = game.Player.Health.ToString();
                if (game.IsOver)
                {
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