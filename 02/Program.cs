using _01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {

        static Random rnd = new Random();

        static object block = new object();

        static void MyThread()
        {


            while (true)
            {


                double timeScale = rnd.NextDouble();


                Lancuzhok lan = new Lancuzhok();

                do
                {
                    lock (block)
                    {
                        lan.Show();
                    }
                    Thread.Sleep((int)(150d * timeScale));

                    lock (block)
                    {
                        lan.ClearTopMost();
                    }
                }
                while (++lan.Y < 30);




            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            const int c = 50;
            Thread[] t = new Thread[c];
            for (int i = 0; i < c; ++i)
                t[i] = new Thread(MyThread);
            for (int i = 0; i < c; ++i)
                t[i].Start();
        }
    }
}
