using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Field
    {   public int n { get; set; }
        public  int[,]A { get; set; }
        public System.Drawing.Bitmap bitmap {get; set;}
        public void Flood()
        {
            Random r = new Random();
            A = new int[n, n];
            bitmap = new System.Drawing.Bitmap(n,n);
            for (int i=0;i<n;i++)
            {
                for (int j = 0; j <n; j++)
                {
                    A[i, j] =  100+j /(10 * (r.Next(2)+1));
                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb(255, A[i, j], A[i, j], A[i, j]));
                }
            }
        }
        public bool f { get; set; }
        public Field(int n) { this.n = n; this.Flood(); }
    }
}
