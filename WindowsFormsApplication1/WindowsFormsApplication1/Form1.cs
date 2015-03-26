using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Field field;
        Graphics gr;
        List <Demo> pn = new List<Demo>();
        List<Pnt> pnts = new List<Pnt>();       
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            field = new Field(pictureBox1.Width);
            b = field.bitmap;            
            timer1.Start();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            pn.Clear();
            pnts.Clear();
            b = field.bitmap;// b.Palette
            pictureBox1.Image = field.bitmap;
            pictureBox1.Refresh();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Demo temp = new Demo(pictureBox1.PointToClient(MousePosition),field);
            pn.Add(temp);
            label1.Text = temp.XY.X.ToString() + "," + temp.XY.Y.ToString();
            b.SetPixel(temp.XY.X, temp.XY.Y, Color.Red);
            pictureBox1.Image = field.bitmap;
            //b = field.bitmap;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b = field.bitmap;
            pictureBox1.Image = field.bitmap;
            pictureBox1.Update();
            foreach (Demo d in pn) 
            { try 
                {
                    if (d.f == true)
                    {  if (d.Check(new System.Drawing.Point(d.XY.X + (int)(d.an * (Math.Cos(d.an))),d.XY.Y + (int)(d.an * (Math.Sin(d.an))))))
                    { 
                       Pnt temp_p = new Pnt(d,d.XY.X + (int)(d.an * (Math.Cos(d.an))), d.XY.Y + (int)(d.an * (Math.Sin(d.an))));
                       temp_p.par.Add(temp_p);
                       pnts.Add(temp_p);
                       d.Move();
                    }
                    
                /*{ b.SetPixel(d.XY.X + (int)(d.an * (Math.Cos(d.an ))), d.XY.Y + (int)(d.an * (Math.Sin(d.an))), Color.Black); }*/
                    d.an = d.an + 1f;
                    foreach (Pnt p in pnts)
                    {
                        try { 
                            b.SetPixel(p.XY.X, p.XY.Y, Color.Red); 
                        }
                        catch (System.ArgumentOutOfRangeException er) { p.par.f = false; }
                    }
                    }
                }
            catch (System.ArgumentOutOfRangeException er) { d.f = false; }
            };
            
            label2.Text = pnts.Count.ToString();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
