using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lab2
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            
            double x = 0, y = 0;
            
            Pen axesPen = new Pen(Color.Red, 1);
            
            Pen graphicsPen = new Pen(Color.FromArgb(0, 255, 0), 1);
            
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            
            g.PageUnit = GraphicsUnit.Pixel;
            
            g.DrawRectangle(axesPen, 0, 0,pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            g.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2,pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);
            g.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0,(pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);
            
            x = -Math.PI/2;
            for (ex = 0; ex <= 900; ex++)
            {
                y = 2*Math.Pow(x,3)+2*x;
                ey = (pictureBox1.Size.Height - 1) - (Convert.ToInt32(y * 450) + 225);
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + Math.PI  / (pictureBox1.Size.Width - 1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int ex = 0, ey = 0, old_ex = 0, old_ey = 0;
            double x = 0, y = 0;
            
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen axesPen = new Pen(Color.Cyan, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 0, 255), 0.1f);
            
            pictureBox1.BackColor =Color.FromKnownColor(KnownColor.ControlLightLight);

            pictureBox1.Refresh();
            
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) /
            g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) /
            g.DpiY * 25.4);

            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            
            x = -Math.PI/2;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                y = 2 * Math.Pow(x, 3) + 2 * x;
                ey = HeightInMM - (Convert.ToInt32(y *Convert.ToInt32(450 / g.DpiX * 25.4)) +Convert.ToInt32(225 / g.DpiX * 25.4));
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                x = x + Math.PI / WidthInMM;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float ex = 0, old_ex = 0, ey = 0, old_ey = 0;
            float x = 0, y = 0;
            long shag = 0;
            
            g.PageUnit = GraphicsUnit.Inch;
            Pen axesPen = new Pen(Color.Orange, 0.01f);
            Pen graphicsPen = new Pen(Color.FromArgb(255, 0, 0), 0.01f);
            
            pictureBox1.BackColor = Color.FromName("LightCyan");
            pictureBox1.Refresh();
            
            float WidthInInches = (pictureBox1.Size.Width - 1) / g.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / g.DpiY;
            
            g.DrawRectangle(axesPen, 0, 0, WidthInInches, HeightInInches);
            
            g.DrawLine(axesPen, 0, HeightInInches / 2, WidthInInches, HeightInInches / 2);

            g.DrawLine(axesPen, WidthInInches / 2, 0, WidthInInches / 2, HeightInInches);

            x = -Convert.ToSingle(Math.PI/2);
            ex = 0;
            shag = Convert.ToSingle(WidthInInches / 25.4);
            while (ex <= WidthInInches + shag)
            {
                y = Convert.ToSingle(2 * Math.Pow(x, 3) + 2 * x);
                ey = Convert.ToSingle(-y) + HeightInInches / 2;
                if (ex != 0) { g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); }
                old_ex = ex; old_ey = ey;
                ex = ex + shag;
                x = x + Convert.ToSingle(Math.PI + shag);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(224, 224, 224));
        }
    }
}

