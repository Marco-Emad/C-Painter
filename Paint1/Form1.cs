using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint1
{
	public partial class Form1 : Form
	{
		Graphics g;
		int x = -1, y = -1;
		bool moving = false;
		Pen pen;
		
		public Form1()
		{
			InitializeComponent();
			g = panel1.CreateGraphics();
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			pen = new Pen(Color.Black, 5);
			pictureBox9.BackColor = pen.Color;
			pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
			for (int i = 5; i <= 100; i+=5)
			{
				comboBox1.Items.Add(i);
			}
			comboBox1.Text = "5";
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			PictureBox p = (PictureBox)sender;
			pen.Color = p.BackColor;
			pictureBox9.BackColor = p.BackColor;
		}
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			moving = true;
			x = e.X;
			y = e.Y;
			panel1.Cursor = Cursors.Cross;
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if(moving && x != -1 && y != -1)
			{
				g.DrawLine(pen, new Point(x, y), e.Location);
				x = e.X;
				y = e.Y;
			}
		}

		private void Clearbtn_Click(object sender, EventArgs e)
		{
			g.Clear(Color.White);
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			try
			{
				pen.Width = Convert.ToInt32(comboBox1.Text);
				if (pen.Width < 0)
				{
					pen.Width = 5;
					comboBox1.Text = "5";
				}
			}
			catch (Exception)
			{
				pen.Width = 5;
				comboBox1.Text = "5";
			}
		}

		private void pictureBox10_Click(object sender, EventArgs e)
		{
			pen.Color = Color.White;
			pictureBox9.BackColor = Color.White;
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			moving = false;
			x = -1;
			y = -1;
			panel1.Cursor = Cursors.Arrow;
		}
	}
}
