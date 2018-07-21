using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    /// <summary>
    /// Timer class
    /// </summary>
    public class Clock
    {
        private readonly int _time;

        #region Constructor

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="time">
        /// Time
        /// </param>
        public Clock(int time)
        {
            _time = time;
        }

        #endregion

        /// <summary>
        /// Event to time out
        /// </summary>
        public event EventHandler<TimeOutEventArgs> TimeOut = delegate { };

        #region Public API

        /// <summary>
        /// Start timer
        /// </summary>
        public void StartCountDown()
        {
            Thread.Sleep(_time * 1000);
            OnTimeOut(new TimeOutEventArgs(_time));
        }

        #endregion

        #region Virtual methods

        /// <summary>
        /// Virtual method which invoke method
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void OnTimeOut(TimeOutEventArgs eventArgs)
        {
            EventHandler<TimeOutEventArgs> tmp = TimeOut;
            tmp?.Invoke(this, eventArgs);
        }

        #endregion
    }
}
