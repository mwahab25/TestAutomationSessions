using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Printdata
    {
        public void print(int i)
        {
            Console.WriteLine("Printing int: {0}", i);
        }
        public void print(double f)
        {
            Console.WriteLine("Printing float: {0}", f);
        }
        public void print(string s)
        {
            Console.WriteLine("Printing string: {0}", s);
        }
    }

}
