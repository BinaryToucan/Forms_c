using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_form
{
    public partial class Form1 : Form
    {
        //int point_size_p = 5;
        enum Figure
        {
            Point = 1,
            Poligon,
            Curve,
            Bez,
            Fill
        }

        Figure fig = Figure.Point;

        List<Point> _points = new List<Point>();
        List<myPoint> _movepoint = new List<myPoint>();

        Bitmap myBitmap;

        // объявляем "средства" рисования - графику, перо и заливку
        Graphics gr;
        SolidBrush redBrush = new SolidBrush(Color.Red);

        int wit_pen = 3;
        Pen myPen = new Pen(Color.Black, 3);
        //Timer timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();

            this.Text = "Лабораторная 4";
            this.BackColor = Color.White;
            //this.Width = 500;              // новая ширина формы
            //this.Height = 500;
            timer2.Enabled = false;
            timer2.Interval = 10;
            //this.Paint += Form1_Paint;
            //this.MouseMove += Form1_MouseMove;
            //this.MouseClick += Form1_Click;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);

            button1.PreviewKeyDown += new PreviewKeyDownEventHandler(button1_PreviewKeyDown);
            button2.PreviewKeyDown += new PreviewKeyDownEventHandler(button2_PreviewKeyDown);
            button3.PreviewKeyDown += new PreviewKeyDownEventHandler(button3_PreviewKeyDown);
            button4.PreviewKeyDown += new PreviewKeyDownEventHandler(button4_PreviewKeyDown);
            button5.PreviewKeyDown += new PreviewKeyDownEventHandler(button5_PreviewKeyDown);
            button6.PreviewKeyDown += new PreviewKeyDownEventHandler(button6_PreviewKeyDown);
            button7.PreviewKeyDown += new PreviewKeyDownEventHandler(button7_PreviewKeyDown);
            button8.PreviewKeyDown += new PreviewKeyDownEventHandler(button8_PreviewKeyDown);

            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //привязываем графику к нашему Bitmap
            gr = Graphics.FromImage(myBitmap);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer2.Enabled)
            {
                if (e.KeyCode == Keys.Down)
                {
                    MoveFigDown();
                    ClearForm();
                }
                if (e.KeyCode == Keys.Up)
                {
                    MoveFigUp();
                    ClearForm();
                }
                if (e.KeyCode == Keys.Right)
                {
                    MoveFigRig();
                    ClearForm();
                }
                if (e.KeyCode == Keys.Left)
                {
                    MoveFigLeft();
                    ClearForm();
                }

                if (fig == Figure.Poligon)
                {
                    PaintPoligon();
                }
                if (fig == Figure.Curve)
                {
                    PaintCurve();
                }
                if (fig == Figure.Bez)
                {
                    PaintBeziers();
                }
                if (fig == Figure.Fill)
                {
                    FillPaintCurve();
                }
                PaintAllPoint();
                pictureBox1.Image = myBitmap;
            }
        }
        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void button8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        void PaintPoint(int x, int y, int size)
        {
            gr.DrawEllipse(Pens.Black, x - size, y - size, size * 2, size * 2);
            gr.FillEllipse(redBrush, x - size, y - size, size * 2, size * 2);
            pictureBox1.Image = myBitmap;
        }
        void PaintAllPoint()
        {
            for(int i = 0; i < _points.Count; i++)
            {
                PaintPoint(_points[i].X, _points[i].Y, _movepoint[i].sizePo);
            }
            
        }
        void NewPosPoint()
        {
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X + _movepoint[i].x_move + _movepoint[i].sizePo > this.pictureBox1.Width || _points[i].X + _movepoint[i].x_move  - _movepoint[i].sizePo < 0)
                {
                    _movepoint[i].x_move *= -1;
                }
                if (_points[i].Y + _movepoint[i].y_move + _movepoint[i].sizePo > this.pictureBox1.Height || _points[i].Y + _movepoint[i].y_move - _movepoint[i].sizePo < 0)
                {
                    _movepoint[i].y_move *= -1;
                }
                Point t = new Point(_points[i].X + _movepoint[i].x_move, _points[i].Y + _movepoint[i].y_move);
                _points[i] = t;
            }
        }
        void PaintPoligon()
        {
            gr.DrawPolygon(myPen, _points.ToArray());
            PaintAllPoint();
        }
        void PaintCurve()
        {
            gr.DrawClosedCurve(myPen, _points.ToArray());
            PaintAllPoint();
        }
        void FillPaintCurve()
        {
            fig = Figure.Fill;
            gr.FillClosedCurve(redBrush, _points.ToArray());
            gr.DrawClosedCurve(myPen, _points.ToArray());
            PaintAllPoint();
        }
        void PaintBeziers()
        {
            gr.DrawBeziers(myPen, _points.ToArray());
            PaintAllPoint();
        }
        void ClearForm()
        {
            gr.Clear(Color.White);
        }
        
        void NavPoint()
        {
            Random rnd = new Random();
            int nex_x = rnd.Next(0, 2);
            int nex_y = rnd.Next(0, 2);

            for (int i = 0; i < _movepoint.Count; i++)
            {
                _movepoint[i].x_move = myPoint.speed_x;
                _movepoint[i].y_move = myPoint.speed_y;

                if (nex_x == 0) _movepoint[i].x_move *= -1;
                if (nex_y == 0) _movepoint[i].y_move *= -1;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            MovePoint();
        }

        private bool but1 = true;
        private void button1_Click(object sender, EventArgs e)
        {
            but1 = true;
        }

        //Параметры
        Form f2 = new Form();
        TrackBar trackBar1 = new TrackBar();
        TextBox textBox1 = new TextBox();

        TrackBar trackBar2 = new TrackBar();
        TextBox textBox2 = new TextBox();

        Label lab1 = new Label();
        Label lab2 = new Label();
        Button btn = new Button();
        private void button2_Click_1(object sender, EventArgs e)
        {
            but1 = false;

            f2.Width = 300;
            f2.Height = 240;

            f2.Text = "Параметры";

            btn.Location = new System.Drawing.Point(200, 170);
            btn.Text = "Ok";
            btn.Click += new EventHandler(this.btn_Click);

            lab1.Text = "Размер точек";
            lab1.Location = new System.Drawing.Point(8, 10);

            lab2.Text = "Размер линий";
            lab2.Location = new System.Drawing.Point(8, 90);

            textBox1.Location = new System.Drawing.Point(240, 40);
            textBox1.Size = new System.Drawing.Size(40, 20);
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Text = myPoint.size_point.ToString();

            textBox2.Location = new System.Drawing.Point(240, 120);
            textBox2.Size = new System.Drawing.Size(40, 20);
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.Text = wit_pen.ToString();

            trackBar1.Location = new System.Drawing.Point(8, 40);
            trackBar1.Size = new System.Drawing.Size(224, 45);
            trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);

            trackBar1.Minimum = 1;
            trackBar1.Maximum = 20;

            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            trackBar1.TickFrequency = 5;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            trackBar1.LargeChange = 3;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            trackBar1.SmallChange = 2;

            trackBar1.Value = myPoint.size_point;

            trackBar2.Location = new System.Drawing.Point(8, 120);
            trackBar2.Size = new System.Drawing.Size(224, 45);
            trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);

            trackBar2.Minimum = 1;
            trackBar2.Maximum = 20;

            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            trackBar2.TickFrequency = 5;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            trackBar2.LargeChange = 3;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            trackBar2.SmallChange = 2;

            trackBar2.Value = wit_pen;

            f2.Controls.Add(btn);
            f2.Controls.Add(lab1);
            f2.Controls.Add(lab2);

            f2.Controls.Add(trackBar2);
            f2.Controls.Add(textBox2);

            f2.Controls.Add(trackBar1);
            f2.Controls.Add(textBox1);

            f2.ShowDialog();
        }
        void btn_Click(Object sender,
                           EventArgs e)
        {
            f2.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int t = trackBar1.Value;
            Int32.TryParse(textBox1.Text, out t);
            if (t > trackBar1.Maximum) trackBar1.Value = trackBar1.Maximum;
            else if (t < trackBar1.Minimum) trackBar1.Value = trackBar1.Minimum;
            else trackBar1.Value = t;

            myPoint.size_point = trackBar1.Value;
        }
        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            // Display the trackbar value in the text box.
            textBox1.Text = "" + trackBar1.Value;
            myPoint.size_point = trackBar1.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int t = trackBar2.Value;
            Int32.TryParse(textBox2.Text, out t);
            if (t > trackBar2.Maximum) trackBar2.Value = trackBar2.Maximum;
            else if (t < trackBar2.Minimum) trackBar2.Value = trackBar2.Minimum;
            else trackBar2.Value = t;

            wit_pen = trackBar2.Value;

            myPen = new Pen(Color.Black, wit_pen);
        }
        private void trackBar2_Scroll(object sender, System.EventArgs e)
        {
            // Display the trackbar value in the text box.
            textBox2.Text = "" + trackBar2.Value;
            wit_pen = trackBar2.Value;

            myPen = new Pen(Color.Black, wit_pen);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            NavPoint();
            timer2.Enabled = !timer2.Enabled;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            ClearForm();
            _points.Clear();
            _movepoint.Clear();
            pictureBox1.Image = myBitmap;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            fig = Figure.Curve;
            ClearForm();
            PaintAllPoint();
            try
            {
                PaintCurve();
            }
            catch
            {
                MessageBox.Show("Количество точек слишком маленькое (" + _points.Count + ")", "Important Message");
                fig = Figure.Point;
            }
            pictureBox1.Image = myBitmap;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            fig = Figure.Poligon;
            ClearForm();
            PaintAllPoint();
            try
            {
                PaintPoligon();
            }
            catch
            {
                MessageBox.Show("Количество точек слишком маленькое (" + _points.Count + ")", "Important Message");
                fig = Figure.Point;
            }
            pictureBox1.Image = myBitmap;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            fig = Figure.Bez;
            ClearForm();
            PaintAllPoint();
            try
            {
                PaintBeziers();
            }
            catch
            {
                MessageBox.Show("Количество точек не позволяет построить кривую Безье (" + _points.Count + ")\nКоличество точек должно быть кратно трем плюс 1, например 4, 7 или 10", "Important Message");
                fig = Figure.Point;
            }
            pictureBox1.Image = myBitmap;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            but1 = false;
            ClearForm();
            FillPaintCurve();
            pictureBox1.Image = myBitmap;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (but1)
            {
                var pt = e as MouseEventArgs;

                _points.Add(new Point(pt.X, pt.Y));
                _movepoint.Add(new myPoint());

                PaintPoint(pt.X, pt.Y, _movepoint.Last().sizePo);
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics rg = e.Graphics;
            PaintAllPoint();
        }
        void MovePoint()
        {
            NewPosPoint();
            ClearForm();
            if (fig == Figure.Poligon)
            {
                PaintPoligon();
            }
            if (fig == Figure.Curve)
            {
                PaintCurve();
            }
            if (fig == Figure.Bez)
            {
                PaintBeziers();
            }
            if (fig == Figure.Fill)
            {
                FillPaintCurve();
            }
            PaintAllPoint();
            pictureBox1.Image = myBitmap;
        }

        void MoveFigRig()
        {
            bool prov = true;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X + myPoint.hor_speed + _movepoint[i].sizePo > this.pictureBox1.Width)
                {
                    prov = false;
                }
                
            }
            if (prov)
            {
                for (int i = 0; i < _points.Count; i++)
                {
                    Point t = new Point(_points[i].X + myPoint.hor_speed, _points[i].Y);
                    _points[i] = t;
                }
            }
        }
        void MoveFigLeft()
        {
            bool prov = true;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].X - myPoint.hor_speed - _movepoint[i].sizePo < 0)
                {
                    prov = false;
                }

            }
            if (prov)
            {
                for (int i = 0; i < _points.Count; i++)
                {
                    Point t = new Point(_points[i].X - myPoint.hor_speed, _points[i].Y);
                    _points[i] = t;
                }
            }
        }
        void MoveFigDown()
        {
            bool prov = true;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].Y + myPoint.ver_speed + _movepoint[i].sizePo > this.pictureBox1.Height)
                {
                    prov = false;
                }

            }
            if (prov)
            {
                for (int i = 0; i < _points.Count; i++)
                {
                    Point t = new Point(_points[i].X, _points[i].Y + myPoint.ver_speed);
                    _points[i] = t;
                }
            }
        }
        void MoveFigUp()
        {
            bool prov = true;
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].Y - myPoint.ver_speed - _movepoint[i].sizePo < 0)
                {
                    prov = false;
                }

            }
            if (prov)
            {
                for (int i = 0; i < _points.Count; i++)
                {
                    Point t = new Point(_points[i].X, _points[i].Y - myPoint.ver_speed);
                    _points[i] = t;
                }
            }
        }
    }
    public class myPoint
    {
        static public int size_point = 5;
        static public int speed = 10;
        static public int speed_x = 1;
        static public int speed_y = 2;
        static public int hor_speed = 1;
        static public int ver_speed = 1;
        public int x_move { get; set; }
        public int y_move { get; set; }
        public int sizePo { get; set; }

        public myPoint()
        {
            this.sizePo = size_point;
            this.x_move = speed_x;
            this.y_move = speed_y;
        }
    }
}
