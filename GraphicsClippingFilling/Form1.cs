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
        bool clockwise = false;

        Point v;

        public class ETentry
        {
            public int ymin { get; set; }
            public int ymax { get; set; }
            public float xmin { get; set; }
            public float oneoverm { get; set; }
            //public float b { get; set; }
            //public ETentry next { get; set; }

            /*ETentry getYminEntry(List<ETentry> list)
            {
                ETentry et = new ETentry();

            }*/
        }

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
            polygon = new List<Point> { new Point(220, 50), new Point(200, 180), new Point(40, 200), new Point(50, 90)};
            line = new List<Point>();
        }

        public bool verifyClockwise(List<Point> polygon)
        {
            bool clockwise = false;
            Point p1 = polygon[0];
            Point p2 = polygon[1];
            Point p3 = polygon[2];
            int delX1 = p2.X - p1.X;
            int delX2 = p3.X - p2.X;
            int delY1 = p2.Y - p1.Y;
            int delY2 = p3.Y - p2.Y;

            if ((delY1 > 0 && delX2 < 0) || (delX1 < 0 && delY2 < 0) || (delY1 < 0 && delX2 > 0) || (delX1 > 0 && delY2 > 0))
                clockwise = true;

            return clockwise;

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
        
        Point getInsideNormal( Point p1, Point p2/*, Point z*/, bool clockwise)
        {
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            Point n = new Point();
            if(clockwise)
                n = new Point( -delY, delX );
            else
                n = new Point(delY,-delX);
            /*Point v = new Point( z.X - p1.X, z.Y - p1.Y );
            double dot = dotProduct(v, n);
            if (dot < 0) //outside normal
            {
                n.X *= -1;
                n.Y *= -1;
            }*/
            return n;
        }

        void cyrusBeck(List<Point> polygon, Point p1, Point p2)
        {
            /*if (p1.X > p2.X)
            {
                Point temp = p1;
                p1 = p2;
                p2 = temp;
            }*/
            int delX = p2.X - p1.X;
            int delY = p2.Y - p1.Y;
            //vector D = Direction vector
            Point D = new Point(delX, delY);

            Point temp1 = polygon.ElementAt(polygon.Count() - 1);
            //Point temp2 = polygon.ElementAt(polygon.Count() - 1);
            double tEnter = 0;
            double tLeave = 1;

            bool clockwise = verifyClockwise(polygon);

            foreach(var p in polygon)
            {
                Point n = getInsideNormal(temp1, p, clockwise);
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

        public List<ETentry> getEgdeTable(List<Point> polygon)
        {
            List<ETentry> edgeTable = new List<ETentry>();
            Point temp = polygon.Last();

            foreach( var v in polygon)
            {
                ETentry et = new ETentry();
                et.ymin = Math.Min(v.Y, temp.Y);
                et.ymax = Math.Max(v.Y, temp.Y);
                //et.xmin = Math.Min(v.X, temp.X); //wspolrzedna x od ymin
                if (v.Y < temp.Y)
                    et.xmin = v.X;
                else
                    et.xmin = temp.X;
                int dy = (v.Y - temp.Y);
                int dx = (v.X - temp.X);
                //if (dy == 0) et.oneoverm = 1;
                //if (dx == 0) et.oneoverm = 0;
                if (dy == 0) et.oneoverm = 0;
                //if( dx != 0 && dy != 0) et.oneoverm = (float) dy / (float) dx;
                if (dy != 0) et.oneoverm = (float)dx / (float)dy;
                //et.b = v.Y - et.oneoverm * v.X;
                //et.next = null;
                edgeTable.Add(et);
               
                temp = v;
            }

            edgeTable.Sort((p, q) => p.ymin.CompareTo(q.ymin));

            return edgeTable;
        }

        public void fillPolygon(List<Point> polygon, Color color)
        {
            List<ETentry> edgeTable = getEgdeTable(polygon);
            ETentry ETmin = edgeTable[0];
            int y = ETmin.ymin;
            List<ETentry> activeEdgeTable = new List<ETentry>();
            SolidBrush br = new SolidBrush(color);
            while( edgeTable.Count != 0 || activeEdgeTable.Count != 0 )
            {
                List<ETentry> toRemove = new List<ETentry>();
                foreach (var et in edgeTable)
                {
                    if (et.ymin == y)
                    {
                        activeEdgeTable.Add(et);
                        toRemove.Add(et);
                    }
                    else
                    {
                        break;
                    }
                }
                foreach(var et in toRemove)
                {
                    edgeTable.Remove(et);
                }
                toRemove.Clear();
                activeEdgeTable.Sort((p, q) => p.xmin.CompareTo(q.xmin));

                for(int n = 0; n < activeEdgeTable.Count; n+=2)
                {
                    //int border1 = (int)((y - activeEdgeTable[n].b) / (activeEdgeTable[n].oneoverm / 1));
                    //int border2 = (int)((y - activeEdgeTable[n + 1].b) / (activeEdgeTable[n + 1].oneoverm / 1));
                    //if(border1 > border2)
                    //{
                    //    int temp = border1;
                    //    border1 = border2;
                    //    border2 = temp;
                    //}
                    //for (int a = border1; a <= border2; a++)
                    for(int a = (int)activeEdgeTable[n].xmin; (int)a <= activeEdgeTable[n+1].xmin; a++)
                    {
                        graphics.FillRectangle(br, a, y, 1, 1);
                    }
                }

                ++y;

                foreach (var e in activeEdgeTable.ToList())
                {
                    if (e.ymax == y)
                        activeEdgeTable.Remove(e);
                }

                foreach (var e in activeEdgeTable.ToList())
                {
                    e.xmin += e.oneoverm;
                }                        
            }
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            fillPolygon(polygon, Color.Maroon);
        }

        private void drawShapeButton_Click(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            SolidBrush br = new SolidBrush(Color.Green);
            graphics.FillRectangle(br, rec);
            SolidBrush br1 = new SolidBrush(Color.Maroon);
            graphics.FillEllipse(br1, 100, 100, 100, 100);
            SolidBrush br2 = new SolidBrush(Color.Yellow);
            graphics.FillEllipse(br2, 120, 120, 20, 20);
            graphics.FillEllipse(br2, 160, 160, 20, 20);
        }

        public void boundaryFill4(int x, int y, Color boundary, Color newColor)
        {
            
        }

        private void boundaryButton_Click(object sender, EventArgs e)
        {
            Color boundary = bmp.GetPixel(line.ElementAt(0).X, line.ElementAt(0).Y);
            Color newColor = bmp.GetPixel(line.ElementAt(1).X, line.ElementAt(1).Y);
            for(int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    boundaryFill4(x, y, boundary, newColor);
                }
            }
        }


        /*public List<ETentry> getEgdeTable(List<Point> polygon)
        {
            List<ETentry> edgeTable = new List<ETentry>();
            Point temp = polygon.Last();

            foreach( var v in polygon)
            {
                ETentry et = new ETentry();
                et.ymin = Math.Min(v.Y, temp.Y);
                et.ymax = Math.Max(v.Y, temp.Y);
                et.xmin = Math.Min(v.X, temp.X);
                int dy = (v.Y - temp.Y);
                int dx = (v.X - temp.X);
                if (dy == 0) et.oneoverm = 1;
                if (dx == 0) et.oneoverm = 0;
                if( dx != 0 && dy != 0) et.oneoverm = (float) dy / (float) dx;
                et.b = v.Y - et.oneoverm * v.X;
                //et.next = null;
                edgeTable.Add(et);
               
                temp = v;
            }

            edgeTable.Sort((p, q) => p.ymin.CompareTo(q.ymin));

            /*for (int n = 0; n < polygon.Count - 1; n++)
            {
                for (int m = 0; m < polygon.Count - n - 1; m++)
                {
                    if((edgeTable[m].ymin > edgeTable[m+1].ymin || edgeTable[m].ymax > edgeTable[m + 1].ymax)
                        || (edgeTable[m].ymin == edgeTable[m + 1].ymin && edgeTable[m].xmin > edgeTable[m + 1].xmin))
                    {
                        ETentry swap = edgeTable[m];
                        edgeTable[m] = edgeTable[m + 1];
                        edgeTable[m + 1] = swap;
                    }
                }
            }*/

        /*List<ETentry> edgeTable2 = new List<ETentry>();
        edgeTable2[edgeTable.Count - 1] = edgeTable[edgeTable.Count - 1];
        int i = edgeTable.Count - 1; 

        for( int k = edgeTable.Count - 2; k >= 0; k--)
        {
            if(edgeTable[k].ymin == edgeTable2[i].ymin)
            {
                edgeTable2[i].next = edgeTable[k];
            }
            else
            {
                i--;
                edgeTable2[i] = edgeTable[k];
            }
        }

        foreach(var et in edgeTable2)
        {
            if (et == null)
                edgeTable2.Remove(et);
        }

        return edgeTable;
    }*/

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
