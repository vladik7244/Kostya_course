using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Demo
    {
        public Field fl { get; set; }
        public  System.Drawing.Point XY { get; set; }
        List<Pnt> ch {get;set;}
        public  float an { get; set; }
        public bool f { get; set; }
        public Demo(System.Drawing.Point XY, Field fl) { this.XY = XY; this.an = 0; f = true; ch = new List<Pnt>(); this.fl = fl; }
        public void Add(Pnt p) {  ch.Add(p); }
        public bool Check(System.Drawing.Point pch)
        { if (pch.X < fl.n && pch.Y < fl.n && pch.X >= 0 && pch.Y >= 0) { return true; } else return false; }
        public void Move()
        {
            Pnt t_prev=ch.First();
            int new_x, new_y;
            foreach (Pnt t in ch) 
            {   
                t.val = fl.A[t.XY.X, t.XY.Y]; 
                {if (t_prev.val >= t.val)
                {
                    new_x=t.XY.X + ((t_prev.XY.X - t.XY.X) / 2);
                    new_y=t.XY.Y + ((t_prev.XY.Y - t.XY.Y) / 2);
                    if (this.Check(new System.Drawing.Point(new_x,new_y)))
                    { t.XY = new System.Drawing.Point(new_x, new_y); this.XY = t.XY; }
                    
                    
                }
                else
                {
                    new_x = t_prev.XY.X + ((t.XY.X - t_prev.XY.X) / 2);
                    new_y = t_prev.XY.Y + ((t.XY.Y - t_prev.XY.Y) / 2);
                    if (this.Check(new System.Drawing.Point(new_x, new_y)))
                    { t_prev.XY = new System.Drawing.Point(new_x, new_y); this.XY = t_prev.XY; }                    
                    

                }
                }
                t_prev = t;
            }
        }
    }
}
