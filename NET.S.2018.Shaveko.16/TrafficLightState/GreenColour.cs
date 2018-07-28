using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightState
{
    /// <summary>
    /// Green colour
    /// </summary>
    public class GreenColour : ILightTraffic
    {
        /// <summary>
        /// Property of colour
        /// </summary>
        public State Colour => State.Green;

        /// <summary>
        /// Change colour 
        /// </summary>
        /// <param name="state">
        /// State of traffic light
        /// </param>
        public void ChangeColour(TrafficLight state)
        {
            state.State = new YellowToRed();
        }
    }
}
