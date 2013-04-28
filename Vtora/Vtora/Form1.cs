using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vtora
{
    public partial class Form1 : Form
    {
        Ball ball;
        Graphics graphics;
        Brush brush;
        Pen pen;
        Rectangle bounds;
        Bitmap doubleBuffer;
        static readonly int FRAMES_PER_SECOND = 30;
        Random random;
        public Form1()
        {
            InitializeComponent();
            bounds = new Rectangle(10, 10, this.Bounds.Width - 40, this.Bounds.Height - 60);
            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            ball = new Ball(Width / 2, Height / 2, 20, 10, (float)(Math.PI / 3.2));
            ball.Bounds = bounds;
            Show();
            brush = new SolidBrush(Color.Blue);
            pen = new Pen(Color.Red);
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000 / FRAMES_PER_SECOND;
            timer.Start();
            random = new Random();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            bounds = new Rectangle(10, 10, this.Bounds.Width - 40, this.Bounds.Height -60);
            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            ball.Bounds = bounds;
            
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.White);
            if (ball.Move())
            {
                pen = new Pen(Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)));
                brush = new SolidBrush(Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)));
            }
            g.DrawRectangle(pen, bounds);
            ball.Draw(brush, g);
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > (ball.X - ball.Radius) && e.X < (ball.X + ball.Radius) && e.Y > (ball.Y - ball.Radius) && e.Y < (ball.Y + ball.Radius))
            {
                brush = new SolidBrush(Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)));
                ball.velocityX = -ball.velocityX;
                ball.velocityY = -ball.velocityY;
            }
        }
    }
}
