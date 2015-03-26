using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Pnt
    {
        public  System.Drawing.Point XY { get; set; }
        public  float an { get; set; }
        public int val { get; set; }
        public bool f { get; set; }
        public Demo par { get; set; }
        public Pnt(Demo parent, System.Drawing.Point XY) { par = parent; this.XY = XY; this.an = 0; f = true; }
        public Pnt(Demo parent, int X, int Y) { par = parent; this.XY = new System.Drawing.Point(X,Y); this.an = 0; f = true; }
    }
}
