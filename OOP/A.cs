using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class A
    {
        public A() //constructor       
        {
            Console.WriteLine("Constructor A");
        }
        private int x; //Class variable      
        public void SetA(int i)  //class method
        {
            this.x = i;
        }
        public void GetA()  //class method
        {
            Console.WriteLine("get a: "+ x + 1);
        }
    }
}
