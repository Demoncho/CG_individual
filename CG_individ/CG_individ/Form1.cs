using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_individ
{
    public partial class Form1 : Form
    {
        bool drawing = true;
        Bitmap bmp;
        Graphics g;
        Point from, to;
        Pen pen = new Pen(Color.Black);
        List<Point> polygon_points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);           
            g = Graphics.FromImage(canvas.Image);
            g.Clear(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            polygon_points.Clear();
            drawing = true;
            label_help.Visible = false;
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(canvas.Image);
            g.Clear(Color.White);
            canvas.Refresh();
        }

        private void button_algoritm_Click(object sender, EventArgs e)
        {
            if (polygon_points.Count <= 2)
            { 
                label_help.Visible = true;
            }
            else
            {
                label_help.Visible = false;               
                drawing = false;
                Point left = polygon_points[0];
                Point right = polygon_points[0];
                for (int i = 0; i < polygon_points.Count; ++i)
                {
                    if (polygon_points[i].X < left.X)
                        left = polygon_points[i];
                    if (polygon_points[i].X > right.X)
                        right = polygon_points[i];
                }
                List<Point> new_polygon_points = polygon_points;
                new_polygon_points.Remove(left);
                new_polygon_points.Remove(right);
                List<Point> above = above_points(left, right, new_polygon_points);
                List<Point> below = below_points(left, right, new_polygon_points);
                up_border(left, right, above);
                down_border(left, right, below);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawing)
            { 
                from = e.Location;
                to = e.Location;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                to = e.Location;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(to.X, to.Y, 3, 3));
                polygon_points.Add(new Point(to.X, to.Y));
            }
        }

        private void label_help_Click(object sender, EventArgs e)
        {

        }

        private List<Point> above_points(Point left, Point right, List<Point> src)
        {
            List<Point> result = new List<Point>();
            for (int i = 0; i<src.Count; ++i)
            {
                if (what_side(left, right, src[i]) > 0)
                    result.Add(src[i]);
            }
            return result;
        }

        private List<Point> below_points(Point left, Point right, List<Point> src)
        {
            List<Point> result = new List<Point>();
            for (int i = 0; i < src.Count; ++i)
            {
                if (what_side(left, right, src[i]) < 0)
                    result.Add(src[i]);
            }
            return result;
        }

        private void up_border(Point left, Point right, List<Point> arr)
        {
            if (arr.Count == 0)
            {
                //canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                //g = Graphics.FromImage(canvas.Image);
                g.DrawLine(pen, left, right);
                canvas.Invalidate();
                //canvas.Refresh();
            }
            else
            {
                Point far = far_point(left, right, arr);
                List<Point> new_arr = arr;
                new_arr.Remove(far);
                List<Point> above_left = above_points(left, far, new_arr);
                List<Point> above_right = above_points(far, right, new_arr);
                up_border(left, far, above_left);
                up_border(far, right, above_right);
            }
        }
        
        private void down_border(Point left, Point right, List<Point> arr)
        {
            if (arr.Count == 0)
            {
                //canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                //g = Graphics.FromImage(canvas.Image);
                g.DrawLine(pen, left, right);
                canvas.Invalidate();
                //canvas.Refresh();
            }
            else
            {
                Point far = far_point(left, right, arr);
                List<Point> new_arr = arr;
                new_arr.Remove(far);
                List<Point> below_left = below_points(left, far, new_arr);
                List<Point> below_right = below_points(far, right, new_arr);
                down_border(left, far, below_left);
                down_border(far, right, below_right);
            }
        }

        private int what_side(Point from, Point to, Point where)
        {
            Point new_line = new Point(to.X - from.X, to.Y - from.Y);
            Point new_point = new Point(where.X - from.X, where.Y - from.Y);


            if ((new_point.Y * new_line.X - new_point.X * new_line.Y) < 0)
                return 1;
            else if ((new_point.Y * new_line.X - new_point.X * new_line.Y) > 0)
                return -1;
            else return 0;
        }

        private Point far_point(Point left, Point right, List<Point> arr)
        {
            double distance = 0;
            Point far = new Point();
            for (int i = 0; i < arr.Count; ++i)
            {
                double temp_dist = Math.Abs((arr[i].X - left.X) * (right.Y - left.Y) - (arr[i].Y - left.Y) * (right.X - left.X));
                if (temp_dist > distance)
                {
                    distance = temp_dist;
                    far = arr[i];
                }
            }
            return far;
        }
    }
}
