using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightState
{
    /// <summary>
    /// Interface of light traffic
    /// </summary>
    public interface ILightTraffic
    {
        State Colour { get; }
        void ChangeColour(TrafficLight state);
    }
}
