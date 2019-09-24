using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Object and Classes-----");
            A a = new A();
            a.SetA(4);
            a.GetA();

            Console.WriteLine("-----Inheritance-----");
            B b = new B();
            b.SetA(5);
            b.GetA();

            b.SetiA(6);
            b.GetiA();

            b.SetB(10);
            b.GetB();

            Console.WriteLine("-----protected method-----");
            C c = new C();
            c.SetC(7);
            //c.GetC(); // this method protected so this error statement 

            A ab = new B();
            ab.SetA(44);
            ab.GetA();

            Console.WriteLine("-----Polymorphism Overloading-----");
            Printdata p = new Printdata();
            // Call print to print integer
            p.print(5);
            // Call print to print float
            p.print(500.263);
            // Call print to print string
            p.print("Hello OOP");
            Console.ReadKey();

        }
    }
}
