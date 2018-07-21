using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{   
    /// <summary>
    /// Event argumments
    /// </summary>
    public sealed class TimeOutEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor of field
        /// </summary>
        /// <param name="time">
        /// Time
        /// </param>
        public TimeOutEventArgs(int time)
        {
            Time = time;
        }

        /// <summary>
        /// Property for time
        /// </summary>
        public int Time { get; }
    }
}
