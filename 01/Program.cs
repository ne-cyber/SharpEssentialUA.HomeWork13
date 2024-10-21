using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01
{

    public class Lancuzhok
    {
        char[] body;
        public int Y
        {
            get;
            set;
        }

        public int StartX
        {
            get;
        }



        public Lancuzhok()
        {
            StartX = rnd.Next(120);
            int lenght = rnd.Next(3, 11);
            char[] body = new char[lenght];

            for (int i = 0; i < lenght; i++)
            {
                body[i] = (char)rnd.Next('!', '~');
            }

            this.body = body;

            Y = 0;
            Y = rnd.Next(0, 30);
        }


        public void Show()
        {
            int x = StartX;

            for (int y = Y, i = 0; y < 30 && i < body.Length; y++, i++)
            {
                Console.SetCursorPosition(x, y);

                if (i == body.Length - 1)
                    Console.ForegroundColor = ConsoleColor.White;
                else if (i == body.Length - 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGreen;


                Console.Write(body[i]);
            }
        }

        public void ClearTopMost()
        {
            Console.SetCursorPosition(this.StartX, this.Y);
            Console.Write(' ');
        }

        static Random rnd = new Random();
    }


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

            //Thread t = new Thread(MyThread);
            //t.Start();

            const int c = 50;
            Thread[] t = new Thread[c];
            for (int i = 0; i < c; ++i)
                t[i] = new Thread(MyThread);
            for (int i = 0; i < c; ++i)
                t[i].Start();



            //Console.ReadKey();
        }
    }
}
