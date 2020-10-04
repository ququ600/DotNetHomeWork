using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayLay
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public double th1 { get; set; }
        public double th2 { get; set; }
        public double per1 { get; set; }
        public double per2 { get; set; }
        public double Length { get; set; }
        public double n { get; set; }
        public Pen drawPen { get; set; }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
           
                if (n == 0)
                {
                    return;
                }
                double x1 = x0 + leng * Math.Cos(th);
                double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            th1 = 30 * Math.PI / 180;
            th2 = 20 * Math.PI / 180;
            per1 = 0.6;
            per2 = 0.7;
            Length = 100;
            n = 10;
            txtbLength.DataBindings.Add("Text", this, "Length");
            textBox1.DataBindings.Add("Text", this, "n");
            txtbRLength.DataBindings.Add("Text", this, "per1");
            txtbLLength.DataBindings.Add("Text", this, "per2");
            txtbLRect.DataBindings.Add("Text", this, "th1");
            txtbRRect.DataBindings.Add("Text", this, "th2");
            Pen[] pens = { Pens.Red, Pens.Green, Pens.Yellow };
            comboBox1.DataSource = pens;
            comboBox1.DisplayMember = "Color";
            comboBox1.DataBindings.Add("SelectedItem", this, "DrawPen");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = Convert.ToDouble(textBox1.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
