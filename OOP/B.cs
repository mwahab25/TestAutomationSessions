using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class B : A, IA
    {
        public B() //constructor       
        {
            Console.WriteLine("Constructor B");
        }
        public void GetiA()
        {
            Console.WriteLine("IA");
        }
        public int SetiA(int b)
        {
            return b + 1;
        }
        public void GetB()
        {
            Console.WriteLine("get b");
        }
        public void SetB(int b)
        {
            Console.WriteLine("set b");
        }
    }

}
