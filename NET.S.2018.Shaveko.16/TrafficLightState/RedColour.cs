using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightState
{
    /// <summary>
    /// Red colour
    /// </summary>
    public class RedColour : ILightTraffic
    {
        /// <summary>
        /// Property of colour
        /// </summary>
        public State Colour => State.Red;

        /// <summary>
        /// Change colour 
        /// </summary>
        /// <param name="state">
        /// State of traffic light
        /// </param>
        public void ChangeColour(TrafficLight state)
        {
            state.State = new YellowToGreen();
        }
    }
}
