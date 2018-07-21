using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock timer = new Clock(10);
            Lecture lecture = new Lecture("Programming");
            Cinema cinema = new Cinema("Spawn");

            cinema.Register(timer);
            lecture.Register(timer);

            timer.StartCountDown();

            cinema.Unregicster(timer);

            timer.StartCountDown();

            System.Console.ReadKey();
        }
    }
}
