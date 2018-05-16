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
        public Pen pen;
        public List<Point> polygon;
        public List<Point> line;
        bool getLine = false;
        bool getPolygon = false;

        Point v;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = null;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp2 = new Bitmap(pictureBox1.Width * 2, pictureBox1.Height * 2);
            pixel = new Bitmap(1, 1);
            pictureBox1.Image = bmp;
            graphics = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black, 2);
            polygon = new List<Point> { new Point(220, 50), new Point(200, 180), new Point(40, 200), new Point(50, 50)};
            line = new List<Point>();
        }

        private void selectPointPolygon_Click(object sender, EventArgs e)
        {
            getPolygon = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void selectPointLine_Click(object sender, EventArgs e)
        {
            getLine = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void drawLineButton_Click(object sender, EventArgs e)
        {
            graphics.DrawLine(pen, line.ElementAt(line.Count - 2), line.ElementAt(line.Count - 1));
        }

        private void drawPolygon_Click(object sender, EventArgs e)
        {
            Point v1 = polygon.First();
            Point temp = v1;
            foreach (var v in polygon)
            {
                graphics.DrawLine(pen, temp, v);
                temp = v;
            }
            graphics.DrawLine(pen, temp, v1);
            //polygon.Clear();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (getLine)
            {
                v = new Point(e.X, e.Y);
                ver2.Text = "x : " + e.X + " y : " + e.Y;
                if (line.Count() == 2)
                    line.Clear();
                line.Add(v);
                getLine = false;
            }
            else if(getPolygon)
            {
                v = new Point(e.X, e.Y);
                ver1.Text = "x : " + e.X + " y : " + e.Y;
                if (polygon.Count() == 4)
                    polygon.Clear();
                polygon.Add(v);
                getPolygon = false;
            }

            pictureBox1.Cursor = Cursors.Default;
        }

        double dotProduct(Point p1, Point p2)
        {
            return p1.X * p2.X + p1.Y * p2.Y;
        }

        /*Point[] getOutsidenormal(Point vertex1, Point vertex2)
        {
            Point[] normal = new Point[2];
            Point midpoint = new Point();
            Point p3 = new Point();
            Point p4 = new Point();

            // Calculate the slope of the original line. (y2 - y1) / (x2 - x1) = slope
            double slope = ((double)(vertex2.Y - vertex1.Y) / (double)(vertex2.X - vertex1.X));

            // Perpendicular lines have a slope of (-1 / originalSlope) -- the negative reciprocal.
            slope = -1 / slope;

            midpoint.X = (vertex1.X + vertex2.X) / 2;
            midpoint.Y = (vertex1.Y + vertex2.Y) / 2;

            p3.X = midpoint.X;
            p3.Y = midpoint.Y;

            // Find the y-intercept of this equation. y=mx + b
            double b = -slope * midpoint.X + midpoint.Y;

            // Finally start calculating the final point. Add the length of the line to X.
            p4.X = midpoint.X + 8;

            // Now plug our slope, intercept, and new X into y=mx + b
            p4.Y = (int)(slope * (midpoint.X + 8) + b);

            normal[0] = p3;
            normal[1] = p4;

            return normal;
        }*/

        
        Point getInsideNormal( Point p1, Point p2/*, Point z*/)
        {
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            Point n = new Point( -delY, delX );
            /*Point v = new Point( z.X - p1.X, z.Y - p1.Y );
            double dot = dotProduct(v, n);
            if (dot < 0) //outside normal
            {
                n.X *= -1;
                n.Y *= -1;
            }*/
            return n;
        }

        /*void cyrusBeck(List<Point> polygon, Point p1, Point p2)
        {
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            Point D = new Point(delX, delY);
            Point temp = polygon.ElementAt(polygon.Count() - 1);
            double tE = 0, tL = 1;
            foreach (var p in polygon)
            {
                Point normal = getInsideNormal(temp, p);
                Point PEi = new Point((temp.X + p.X) / 2, (temp.Y + p.Y) / 2);
                Point x = new Point(p1.X - PEi.X, p1.Y - PEi.Y);
                double nominator = dotProduct(normal, x);
                double denominator = dotProduct(normal, D);
                double t = - nominator / denominator;
                if (denominator == 0) //line and edge are parallel
                {
                    if (nominator < 0)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (denominator < 0)
                    tE = Math.Max(tE, t);
                else
                    tL = Math.Min(tL, t);
                temp = p;
            }
            if (tE > tL)
            {
                return;
            }
            double x1 = p1.X + delX * tE;
            double y1 = p1.Y + delY * tE;
            double x2 = p1.X + delX * tL;
            double y2 = p1.Y + delY * tL;
            graphics.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
            //graphics.DrawLine(pen, (int)(p1.X + tE * delX), (int)(p1.Y + tE * delY), (int)(p1.X + tL * delX), (int)(p1.Y + tL * delY));
        }*/

        void cyrusBeck(List<Point> polygon, Point p1, Point p2)
        {
            if (p1.X > p2.X)
            {
                Point temp = p1;
                p1 = p2;
                p2 = temp;
            }
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            //vector D = Direction vector
            Point D = new Point(delX, delY);

            Point temp1 = polygon.ElementAt(polygon.Count() - 1);
            //Point temp2 = polygon.ElementAt(polygon.Count() - 1);
            double tEnter = 0;
            double tLeave = 1;
            foreach(var p in polygon)
            {
                Point n = getInsideNormal(temp1, p);
                temp1 = p;
                Point w = new Point(p1.X - p.X, p1.Y - p.Y);
                double num = dotProduct(w, n);
                double den = dotProduct(D, n);
                if (den == 0) //line and edge are parallel
                {
                    if (num < 0) //w.n<0  -> point/line outside coz P(t) outside polygon
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                double t = -num / den;
                if (den > 0)
                {
                    tEnter = Math.Max(tEnter, t);
                }
                else
                {
                    tLeave = Math.Min(tLeave, t);
                }
            }
            if (tEnter > tLeave)
            {
                return;
            }
            double x1 = p1.X + delX * tEnter;
            double y1 = p1.Y + delY * tEnter;
            double x2 = p1.X + delX * tLeave;
            double y2 = p1.Y + delY * tLeave;
            graphics.DrawLine( pen, (int)x1, (int)y1 , (int)x2, (int)y2 );
        }

        private void clipButton_Click(object sender, EventArgs e)
        {
            cyrusBeck(polygon, line.ElementAt(0), line.ElementAt(1));
        }

        public void fillPolygon(List<Point> polygon)
        {

        }

        private void fillButton_Click(object sender, EventArgs e)
        {

        }

        /*void cyrusBeck(List<Point> polygon, Point p1, Point p2)
        {
            if (p1.X > p2.X)
            {
                Point temp = p1;
                p1 = p2;
                p2 = temp;
            }
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            //vector D = Direction vector
            Point D = new Point(delX, delY);

            Point temp1 = polygon.ElementAt(polygon.Count() - 2);
            Point temp2 = polygon.ElementAt(polygon.Count() - 1);
            double tEnter = 0;
            double tLeave = 1;
            foreach(var p in polygon)
            {
                Point ptemp = p;
                if (temp2.X > p.X)
                {
                    Point temp = temp2;
                    temp2 = p;
                    ptemp = temp;
                }
                Point n = getInsideNormal(temp2, ptemp, temp1);
                temp1 = temp2;
                temp2 = ptemp;
                Point w = new Point(p1.X - ptemp.X, p1.Y - ptemp.Y);
                double num = dotProduct(w, n);
                double den = dotProduct(D, n);
                if (den == 0) //line and edge are parallel
                {
                    if (num < 0) //w.n<0  -> point/line outside coz P(t) outside polygon
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                double t = -num / den;
                if (den > 0)
                {
                    tEnter = Math.Max(tEnter, t);
                }
                else
                {
                    tLeave = Math.Min(tLeave, t);
                }
            }
            if (tEnter > tLeave)
            {
                return;
            }
            double x1 = p1.X + delX * tEnter;
            double y1 = p1.Y + delY * tEnter;
            double x2 = p1.X + delX * tLeave;
            double y2 = p1.Y + delY * tLeave;
            graphics.DrawLine( pen, (int)x1, (int)y1 , (int)x2, (int)y2 );
        }*/
    }
}
