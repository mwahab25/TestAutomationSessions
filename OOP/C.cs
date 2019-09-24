using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class C   //public class
    {
        private int x;
        internal void SetC(int i)  //internal method
        {
            this.x = i;
        }
        protected void GetC()  //protected method
        {
            Console.WriteLine("get c" + x + 1);
        }
    }

}
