using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vtora
{
    class Ball
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Radius { get; set; }
        public float Velocity { get; set; }
        public float Angle { get; set; }

        public Rectangle Bounds;

        public float velocityX { set; get; }
        public float velocityY { set; get; }

        Random random;
        public Ball(float x, float y, float radius, float velocity, float angle)
        {
            X = x;
            Y = y;
            Radius = radius;
            Velocity = velocity;
            Angle = angle;
            velocityX = (float)Math.Cos(Angle) * Velocity;
            velocityY = (float)Math.Sin(Angle) * Velocity;
            random = new Random();
        }

        public bool Move()
        {
            float nextX = X + velocityX;
            float nextY = Y + velocityY;
            bool predpostavka = false;
            if (nextX - Radius <= Bounds.Left || (nextX + Radius >= Bounds.Right))
            {
                velocityX = -velocityX;
                predpostavka = true;
            }
            if (nextY - Radius <= Bounds.Top || (nextY + Radius >= Bounds.Bottom))
            {
                velocityY = -velocityY;
                predpostavka = true;
            } 
            X += velocityX;
            Y += velocityY;
            return predpostavka;
        }

        public void Draw(Brush brush, Graphics g )
        {
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }



    }
}
