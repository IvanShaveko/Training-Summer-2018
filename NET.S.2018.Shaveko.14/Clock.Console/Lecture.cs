using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clock.Console
{
    class Lecture
    {
        public Lecture(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public void Register(Clock timer) => timer.TimeOut += OnTimeOut;
        public void Unregister(Clock timer) => timer.TimeOut += OnTimeOut;
        
        public void OnTimeOut(object sender, TimeOutEventArgs eventArgs)
        {
            System.Console.WriteLine("Lecture of {0} ended", Title);
            System.Console.WriteLine("Time of lecture {0} seconds", eventArgs.Time);
        }
    }
}
