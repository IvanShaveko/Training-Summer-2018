using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightState
{
    /// <summary>
    /// Traffic light with State pattern
    /// </summary>
    public class TrafficLight
    {
        /// <summary>
        /// Colour
        /// </summary>
        public State Colour => State.Colour;

        /// <summary>
        /// Property of interface ILightTraffic
        /// </summary>
        public ILightTraffic State { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="light">
        /// Light
        /// </param>
        public TrafficLight(ILightTraffic light)
        {
            State = light;
        }

        /// <summary>
        /// Change state of <see cref="State"/>
        /// </summary>
        public void Change()
        {
            State.ChangeColour(this);
        }
    }
}
