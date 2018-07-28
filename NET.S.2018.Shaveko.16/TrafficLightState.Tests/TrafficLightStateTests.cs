using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TrafficLightState.Tests
{
    [TestFixture]
    public class TrafficLightStateTests
    {
        [Test]
        public void TrafficLight_ChangeToYellowToGreen()
        {
            TrafficLight light = new TrafficLight(new RedColour());

            light.Change();
            Assert.AreEqual(light.Colour, new YellowToGreen().Colour);
        }

        [Test]
        public void TrafficLight_ChangeToGreen()
        {
            TrafficLight light = new TrafficLight(new YellowToGreen());

            light.Change();
            Assert.AreEqual(light.Colour, new GreenColour().Colour);
        }

        [Test]
        public void TrafficLight_ChangeToYellowToYellowToRed()
        {
            TrafficLight light = new TrafficLight(new GreenColour());

            light.Change();
            Assert.AreEqual(light.Colour, new YellowToRed().Colour);
        }

        [Test]
        public void TrafficLight_ChangeToYellowToRed()
        {
            TrafficLight light = new TrafficLight(new YellowToRed());

            light.Change();
            Assert.AreEqual(light.Colour, new RedColour().Colour);
        }

        [Test]
        public void TrafficLight()
        {
            TrafficLight light = new TrafficLight(new RedColour());

            light.Change();
            Assert.AreEqual(light.Colour, new YellowToGreen().Colour);
            light.Change();
            Assert.AreEqual(light.Colour, new GreenColour().Colour);
            light.Change();
            Assert.AreEqual(light.Colour, new YellowToRed().Colour);
            light.Change();
            Assert.AreEqual(light.Colour, new RedColour().Colour);
        }
    }
}
