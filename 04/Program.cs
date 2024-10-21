using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04
{
    internal class Program
    {
        static void Method()
        {
            Console.WriteLine("thread: {0}", Thread.CurrentThread.GetHashCode());

            Thread thread = new Thread(Method);
            thread.Start();
        }

        static void Main(string[] args)
        {
            Method();
        }
    }
}
