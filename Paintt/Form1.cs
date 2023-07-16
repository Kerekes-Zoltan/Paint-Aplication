using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paintt
{
    public partial class Form1 : Form
    {
        Color cc=Color.Black;
        int f=5;
        Graphics G;
        int xv, yv;
        int g=20;
        int raza=7;
        int lpatrat=7;
        int ldreptunghi=2;
        int Ldreptunghi=4;
        bool actiunemaus;
        Graphics kp;
        int zs = 1;
        Font h;
        Image File;
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value; // red
            int v = trackBar2.Value; // green
            int a = trackBar3.Value; // blue
            Color c = Color.FromArgb(r, v, a); // culoarea
            pictureBox2.BackColor = c; // setez background
            cc = c;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value; // red
            int v = trackBar2.Value; // green
            int a = trackBar3.Value; // blue
            Color c = Color.FromArgb(r, v, a); // culoarea
            pictureBox2.BackColor = c; // setez background
            cc = c;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int r = trackBar1.Value; // red
            int v = trackBar2.Value; // green
            int a = trackBar3.Value; // blue
            Color c = Color.FromArgb(r, v, a); // culoarea
            pictureBox2.BackColor = c; // setez background
            cc = c;
        }

        private void cercToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 1;
        }

        private void patratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 2;
        }

        private void dreptunghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 3;
        }

        private void poligonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 4;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            G = pictureBox1.CreateGraphics();
            kp= pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(cc, g);
            int x = MousePosition.X - this.Left - pictureBox1.Left - 8;
            int y = MousePosition.Y - this.Top - pictureBox1.Top - 31;
            if (f==1)
            {// cerc
                
                xv = yv = 0;
                G.DrawEllipse(p, x - 20, y - 20, raza, raza);
            }
            else if (f==2)
            {// patrat
                xv = yv = 0;
                G.DrawRectangle(p, x, y, lpatrat, lpatrat);
            }
            else if (f==4)
            {// poligon
                if (xv != 0 && yv != 0)
                {
                    G.DrawLine(p, xv, yv, x, y);
                }
                xv = x;
                yv = y;
            }
            else if(f==3)
            {//dreptunghi
                xv = yv = 0;
                G.DrawRectangle(p, x, y, ldreptunghi, Ldreptunghi);
            }
            else if(f==8)
            {
                if(zs==1) h = new Font("Elephant", g);
                if (toolStripTextBox1.Text == "") MessageBox.Show("Scrieti textul dorit in casuta de sub Adauga text!");
                SolidBrush zz = new SolidBrush(cc);
                G.DrawString(toolStripTextBox1.Text, h, zz, new PointF(x, y));
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            g = int.Parse(numericUpDown1.Value.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            raza = int.Parse(toolStripComboBox2.Text);
            f = 1;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lpatrat= int.Parse(toolStripComboBox1.Text);
            f = 2;
        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ldreptunghi = int.Parse(toolStripComboBox3.Text);
            f = 3;
        }

        private void toolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ldreptunghi = int.Parse(toolStripComboBox4.Text);
            f = 3;
        }

        private void radieraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 6;
        }

        private void stergeTotToolStripMenuItem_Click(object sender, EventArgs e)
        {
              //  pictureBox1.BackColor = Color.White;
            pictureBox1.Refresh();
            pictureBox1.Image = null;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            actiunemaus = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            actiunemaus = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(f==5&&actiunemaus==true)
            {
                int x = MousePosition.X - this.Left - pictureBox1.Left - 8;
                int y = MousePosition.Y - this.Top - pictureBox1.Top - 31;
                SolidBrush zz = new SolidBrush(cc);
                kp = pictureBox1.CreateGraphics();
                kp.FillEllipse(zz, x, y, g, g);
                kp.Dispose();
            }
            else if(f==6&&actiunemaus==true)
            {
                int x = MousePosition.X - this.Left - pictureBox1.Left - 8;
                int y = MousePosition.Y - this.Top - pictureBox1.Top - 31;
                SolidBrush zz = new SolidBrush(Color.White);
                kp = pictureBox1.CreateGraphics();
                kp.FillEllipse(zz, x, y, g, g);
                kp.Dispose();
            }
        }

        private void fisierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adaugareTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 8;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void alegeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zs = 0;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
              
                h= fontDialog1.Font;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deschideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";
            if(f.ShowDialog()==DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                pictureBox1.Image = File;
            }
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
               
                File = pictureBox1.Image;
                  File.Save(f.FileName);
          
               // Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
               // pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
               // bmp.Save(f.FileName);
            }
        }

        private void creionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f = 5;
        }
    }
}
