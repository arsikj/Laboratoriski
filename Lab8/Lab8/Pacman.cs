using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab8
{
    class Pacman
    {
        public int X { get; set; }
        public int Y { get; set; }
        public enum Direction
        {
            Up, 
            Down,
            Left,
            Right
        }
        public Direction direction { get; set; }
        static public readonly int radius = 20;
        public int speed { get; set; }
        public bool otvorena { get; set; }
        Brush brush;

        public Pacman()
        {
            this.speed = Pacman.radius;
            this.X = 7;
            this.Y = 5;
            direction = Direction.Right;
            brush = new SolidBrush(Color.Yellow);
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public void Move(int width, int height)
        {
            if (direction == Direction.Up)
            {
                if (Y == 0)
                {
                    Y = height;
                }
                Y --;
                
            }
            else if (direction == Direction.Right)
            {
                X ++;
                X %= width;
            }
            else if (direction == Direction.Left)
            {
                if (X == 0)
                {
                    X = width ;
                }
                X --;
               
            }
            else
            {
                Y ++;
                Y %= height;
            }
            otvorena = !otvorena;
        }

        public void Draw(Graphics g)
        {
            if (otvorena)
            {
                if (direction == Direction.Right)
                {
                    g.FillPie(brush, X * radius * 2 + (radius * 2 - Form1.foodImage.Height) / 2, Y * radius * 2 + (radius * 2 - Form1.foodImage.Width) / 2, 2 * radius, 2 * radius, 45, 360 - 90);
                }
                else if (direction == Direction.Left)
                {
                    g.FillPie(brush, X * radius * 2 + (radius * 2 - Form1.foodImage.Height) / 2, Y * radius * 2 + (radius * 2 - Form1.foodImage.Width) / 2, 2 * radius, 2 * radius, 180 + 45, 360 - 90);
                }
                else if (direction == Direction.Up)
                {
                    g.FillPie(brush, X * radius * 2 + (radius * 2 - Form1.foodImage.Height) / 2, Y * radius * 2 + (radius * 2 - Form1.foodImage.Width) / 2, 2 * radius, 2 * radius, 360 - 45, 360 - 90);
                }
                else
                {
                    g.FillPie(brush, X * radius * 2 + (radius * 2 - Form1.foodImage.Height) / 2, Y * radius * 2 + (radius * 2 - Form1.foodImage.Width) / 2, 2 * radius, 2 * radius, 90 + 45, 360 - 90);
                }
            }
            else
            {
                g.FillEllipse(brush, X * radius * 2 + (radius * 2 - Form1.foodImage.Height) / 2, Y * radius * 2 + (radius * 2 - Form1.foodImage.Width) / 2, radius * 2, radius * 2);
            }
        }
   
    }
}
