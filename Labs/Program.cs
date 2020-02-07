using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labs
{
    class Program
    {
        private static volatile bool stepHello = true, stepWorld = false;
        static void Main(string[] args)
        {
            // создаем новый поток
            Thread myThreadHello = Thread.CurrentThread;
            Thread myThreadWorld = new Thread(new ThreadStart(World));

            myThreadHello.Name = "Hello";
            myThreadWorld.Name = "World";

            myThreadWorld.Start();

            Hello();
            Console.ReadLine();
        }
        public static void Hello() {
            while (true) {
                try {
                    if (stepHello) {
                        stepHello = false;
                        Console.Write("Hello ");
                        stepWorld = true;
                    }
                } catch (Exception) { throw; }
            }
        }
        public static void World() {
            while (true) {
                try {
                    if (stepWorld) {
                        stepWorld = false;
                        Console.WriteLine("World !!");
                        stepHello = true;
                    }
                } catch (Exception) { throw; }
            }
        }
    }
}
