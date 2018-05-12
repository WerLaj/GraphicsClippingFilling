using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicsClippingFilling
{
    public partial class Form1 : Form
    {
        public Bitmap bmp;
        public Bitmap pixel;
        public Bitmap bmp2;
        public Graphics graphics;

        Point v1;
        Point v2;
        Point circle;

        bool getv1 = false;
        bool getv2 = false;
        bool getcricle = false;

        int radius = 50;
        int thickness = 1;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = null;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp2 = new Bitmap(pictureBox1.Width * 2, pictureBox1.Height * 2);
            pixel = new Bitmap(1, 1);
            pictureBox1.Image = bmp;
            graphics = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getv1 = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getv2 = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getcricle = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void drawLinuButton_Click(object sender, EventArgs e)
        {
            lineDDA(v1.X, v1.Y, v2.X, v2.Y);
        }

        void lineDDA(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
                temp = y1;
                y1 = y2;
                y2 = temp;
            }
            float dy = y2 - y1;
            float dx = x2 - x1;
            float m = dy / dx;
            float y = y1;
            for (int x = x1; x <= x2; ++x)
            {
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x, (int)y);
                bmp.SetPixel(x, (int)y, Color.Blue);
                y += m;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            supersampling(v1.X, v1.Y, v2.X, v2.Y, thickness);
        }

        void supersampling(int x1, int y1, int x2, int y2, int thickness)
        {
            int x1B = x1 * 2;
            int x2B = x2 * 2;
            int y1B = y1 * 2;
            int y2B = y2 * 2;
            int t = 2 * thickness;
            float dy = y2B - y1B;
            float dx = x2B - x1B;
            float m = dy / dx;
            float y = y1B;
            int radius = t;
            for (int x = x1B; x <= x2B; ++x)
            {
                int Left = x - radius;
                int Right = x + radius;
                int Top = (int)y - radius;
                int Bottom = (int)y + radius;
                for (int j = Top; j <= Bottom; ++j)
                {
                    for (int k = Left; k <= Right; ++k)
                    {
                        double c1 = x - k;
                        int c2 = (int)y - j;
                        double dist = Math.Pow(c1, 2.0) + Math.Pow(c2, 2.0);
                        if (dist <= Math.Pow(radius, 2))
                        {
                            /*pixel.SetPixel(0, 0, Color.Black);
                            graphics.DrawImageUnscaled(pixel, k, j);*/
                            bmp2.SetPixel(k, j, Color.Black);
                        }
                    }
                }
                y += m;
            }

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    float avg = (bmp2.GetPixel(2 * i, 2 * j).R + bmp2.GetPixel(2 * i + 1, 2 * j).R + bmp2.GetPixel(2 * i, 2 * j + 1).R + bmp2.GetPixel(2 * i + 1, 2 * j + 1).R) / 4;
                    Color c = Color.FromArgb((int)(avg), (int)(avg), (int)(avg));
                    /*pixel.SetPixel(0, 0, c);
                    graphics.DrawImageUnscaled(pixel, i, j);*/
                    bmp.SetPixel(i, j, c);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (getv1)
            {
                v1 = new Point(e.X, e.Y);
                ver1.Text = "x : " + e.X + " y : " + e.Y;
            }
            if (getv2)
            {
                v2 = new Point(e.X, e.Y);
                ver2.Text = "x : " + e.X + " y : " + e.Y;
            }
            if (getcricle)
            {
                circle = new Point(e.X, e.Y);
                circleLabel.Text = "x : " + e.X + " y : " + e.Y;
            }

            pictureBox1.Cursor = Cursors.Default;
            getv1 = false;
            getv2 = false;
            getcricle = false;
        }

        void MidpointCircle(int radius, int x0, int y0)
        {
            /*
            int d = (5 - radius * 4) / 4;
            int x = 0;
            int y = radius;

            do
            {
                // ensure index is in range before setting (depends on your image implementation)
                // in this case we check if the pixel location is within the bounds of the image before setting the pixel
                if (centerX + x >= 0 && centerX + x <= pictureBox1.Width - 1 && centerY + y >= 0 && centerY + y <= pictureBox1.Height - 1) bmp.SetPixel(centerX + x, centerY + y, Color.Blue);
                if (centerX + x >= 0 && centerX + x <= pictureBox1.Width - 1 && centerY - y >= 0 && centerY - y <= pictureBox1.Height - 1) bmp.SetPixel(centerX + x, centerY - y, Color.Blue);
                if (centerX - x >= 0 && centerX - x <= pictureBox1.Width - 1 && centerY + y >= 0 && centerY + y <= pictureBox1.Height - 1) bmp.SetPixel(centerX - x, centerY + y, Color.Blue);
                if (centerX - x >= 0 && centerX - x <= pictureBox1.Width - 1 && centerY - y >= 0 && centerY - y <= pictureBox1.Height - 1) bmp.SetPixel(centerX - x, centerY - y, Color.Blue);
                if (centerX + y >= 0 && centerX + y <= pictureBox1.Width - 1 && centerY + x >= 0 && centerY + x <= pictureBox1.Height - 1) bmp.SetPixel(centerX + y, centerY + x, Color.Blue);
                if (centerX + y >= 0 && centerX + y <= pictureBox1.Width - 1 && centerY - x >= 0 && centerY - x <= pictureBox1.Height - 1) bmp.SetPixel(centerX + y, centerY - x, Color.Blue);
                if (centerX - y >= 0 && centerX - y <= pictureBox1.Width - 1 && centerY + x >= 0 && centerY + x <= pictureBox1.Height - 1) bmp.SetPixel(centerX - y, centerY + x, Color.Blue);
                if (centerX - y >= 0 && centerX - y <= pictureBox1.Width - 1 && centerY - x >= 0 && centerY - x <= pictureBox1.Height - 1) bmp.SetPixel(centerX - y, centerY - x, Color.Blue);
                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;
            } while (x <= y);*/

            int d = 1 - radius;
            int x = 0;
            int y = radius;
            pixel.SetPixel(0, 0, Color.Blue);
            graphics.DrawImageUnscaled(pixel, x + x0, y + y0);
            bmp.SetPixel(x + x0, y + y0, Color.Blue);
            while (y >= x)
            {
                if (d < 0) //move to E
                    d += 2 * x + 3;
                else //move to SE
                {
                    d += 2 * x - 2 * y + 5;
                    --y;
                }
                ++x;
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 + x, y0 + y);
                bmp.SetPixel(x0 + x, y0 + y, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 + y, y0 + x);
                bmp.SetPixel(x0 + y, y0 + x, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 - y, y0 + x);
                bmp.SetPixel(x0 - y, y0 + x, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 - x, y0 + y);
                bmp.SetPixel(x0 - x, y0 + y, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 - x, y0 - y);
                bmp.SetPixel(x0 - x, y0 - y, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 - y, y0 - x);
                bmp.SetPixel(x0 - y, y0 - x, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 + y, y0 - x);
                bmp.SetPixel(x0 + y, y0 - x, Color.Blue);
                pixel.SetPixel(0, 0, Color.Blue);
                graphics.DrawImageUnscaled(pixel, x0 + x, y0 - y);
                bmp.SetPixel(x0 + x, y0 - y, Color.Blue);
            }
        }

        public float cover(float d, float r)
        {
            float cov = 0;

            if (d <= r)
            {
                double a = Math.Acos(d / r);
                float c1 = Convert.ToSingle((1 / Math.PI) * a);
                float c2 = Convert.ToSingle((d * Math.Sqrt(r * r - d * d)) / (Math.PI * r * r));
                cov = c1 - c2;
            }
            else
            {
                cov = 0;
            }

            return cov;
        }

        public float coverage(float w, float D)
        {
            float cov = 0;
            float r = (float)pixel.Width / 2;

            if (w >= r)
            {
                if (w <= D)
                {
                    cov = cover(D - w, r);
                }
                else if (D >= 0 && D <= w)
                {
                    cov = 1 - cover(w - D, r);
                }
            }
            else
            {
                if (D >= 0 && D <= w)
                {
                    cov = 1 - cover(w - D, r) - cover(w + D, r);
                }
                else if (D >= w && D <= r - w)
                {
                    cov = cover(D - w, r) - cover(D + w, r);
                }
                else if (D >= r - w && D <= r + w)
                {
                    cov = cover(D - w, r);
                }
            }

            return cov;
        }

        public bool IntensifyPixel(int x, int y, float thickness, float distance)
        {
            float cov = coverage(thickness, distance);
            if (cov > 0)
            {
                pixel.SetPixel(0, 0, lerp(Color.White, Color.Blue, cov));
                graphics.DrawImageUnscaled(pixel, x, y);
                bmp.SetPixel(x, y, lerp(Color.White, Color.Blue, cov));
                return true;
            }
            return false;
        }

        public Color lerp(Color a, Color b, float t)
        {
            int red = (int)(a.R + (b.R - a.R) * t);
            if (red > 255) red = 255;
            if (red < 0) red = 0;
            int green = (int)(a.G + (b.G - a.G) * t);
            if (green > 255) green = 255;
            if (green < 0) green = 0;
            int blue = (int)(a.B + (b.B - a.B) * t);
            if (blue > 255) blue = 255;
            if (blue < 0) blue = 0;
            return Color.FromArgb(red, green, blue);
        }

        public void ThickAntialiasedLine(int x1, int y1, int x2, int y2, float thickness)
        {
            int dx = x2 - x1, dy = y2 - y1;
            float steep = Math.Abs(dy / dx);
            int delayY = 1;
            if (steep > 1)
            {
                int temp = x1;
                x1 = y1;
                y1 = temp;
                int temp2 = x2;
                x2 = y2;
                y2 = temp2;
            }
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
                int temp2 = y1;
                y1 = y2;
                y2 = temp2;
            }
            if (y1 > y2)
            {
                delayY = -1;
            }
            dx = x2 - x1;
            dy = y2 - y1;
            int dE = 2 * dy, dNE = 2 * (dy - dx);
            int d = 2 * dy - dx;
            int two_v_dx = 0; //numerator, v=0 for the first pixel
            float invDenom = Convert.ToSingle(1 / (2 * Math.Sqrt(dx * dx + dy * dy))); //inverted denominator
            float two_dx_invDenom = 2 * dx * invDenom; //precomputed constant
            int x = x1, y = y1;
            int i;
            if (steep > 1)
            {
                IntensifyPixel(x, y, thickness, 0);
                for (i = 1; IntensifyPixel(y + i * delayY, x, thickness, i * delayY * two_dx_invDenom); ++i) ;
                for (i = 1; IntensifyPixel(y - i * delayY, x, thickness, i * delayY * two_dx_invDenom); ++i) ;
            }
            else
            {
                IntensifyPixel(x, y, thickness, 0);
                for (i = 1; IntensifyPixel(x, y + i, thickness, i * two_dx_invDenom); ++i) ;
                for (i = 1; IntensifyPixel(x, y - i, thickness, i * two_dx_invDenom); ++i) ;
            }
            while (x < x2)
            {
                ++x;
                if (d < 0) // move to E
                {
                    two_v_dx = d + dx;
                    d += dE;
                }
                else // move to NE
                {
                    two_v_dx = d - dx;
                    d += dNE;
                    //++y; ////deltay
                    y = y + delayY;
                }
                // Now set the chosen pixel and its neighbors
                if (steep > 1)
                {
                    IntensifyPixel(y, x, thickness, two_v_dx * invDenom);
                    for (i = 1; IntensifyPixel(y + i * delayY, x, thickness, i * delayY * two_dx_invDenom - two_v_dx * invDenom); ++i) ;
                    for (i = 1; IntensifyPixel(y - i * delayY, x, thickness, i * delayY * two_dx_invDenom + two_v_dx * invDenom); ++i) ;
                }
                else
                {
                    IntensifyPixel(x, y, thickness, two_v_dx * invDenom);
                    for (i = 1; IntensifyPixel(x, y + i, thickness, i * two_dx_invDenom - two_v_dx * invDenom); ++i) ;
                    for (i = 1; IntensifyPixel(x, y - i, thickness, i * two_dx_invDenom + two_v_dx * invDenom); ++i) ;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MidpointCircle(radius, circle.X, circle.Y);
        }

        private void radiusTextBox_Leave(object sender, EventArgs e)
        {
            radius = Int32.Parse(radiusTextBox.Text.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThickAntialiasedLine(v1.X, v1.Y, v2.X, v2.Y, thickness);
        }

        private void thicknessComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            thickness = (int)thicknessComboBox.SelectedIndex * 2 + 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            drawWithPen(v1.X, v1.Y, v2.X, v2.Y, thickness);
        }

        public void drawWithPen(int x1, int y1, int x2, int y2, int t)
        {
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
                int temp2 = y1;
                y1 = y2;
                y2 = temp2;
            }
            float dy = y2 - y1;
            float dx = x2 - x1;
            float m = dy / dx;
            float y = y1;
            int radius = t;
            for (int x = x1; x <= x2; ++x)
            {
                int Left = x - radius;
                int Right = x + radius;
                int Top = (int)y - radius;
                int Bottom = (int)y + radius;
                for (int j = Top; j <= Bottom; ++j)
                {
                    for (int k = Left; k <= Right; ++k)
                    {
                        double c1 = x - k;
                        int c2 = (int)y - j;
                        double dist = Math.Pow(c1, 2.0) + Math.Pow(c2, 2.0);
                        if (dist <= Math.Pow(radius, 2))
                        {
                            pixel.SetPixel(0, 0, Color.Blue);
                            graphics.DrawImageUnscaled(pixel, k, j);
                            bmp.SetPixel(k, j, Color.Blue);
                        }
                    }
                }
                y += m;
            }
        }

    }
}
