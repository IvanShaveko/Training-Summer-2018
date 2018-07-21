using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Console
{
    class Cinema
    {
        public Cinema(string title)
        {
            Title = title;
        }


        public string Title { get; }

        public void Register(Clock timer) => timer.TimeOut += OnTimeOut;
        public void Unregicster(Clock timer) => timer.TimeOut -= OnTimeOut;

        public void OnTimeOut(object sender, TimeOutEventArgs eventArgs)
        {
            System.Console.WriteLine("{0} ended", Title);
            System.Console.WriteLine("Time of cinema {0} seconds", eventArgs.Time);
        }
    }
}
