using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint02.AntonLilja
{
    class Room
    {
        public string Name { get; private set; }
        public int Size { get; private set; }
        public bool LightIsOn { get; set; }

        public Room(string name, int size, bool lightIsOn)
        {
            Name = name;
            Size = size;
            LightIsOn = lightIsOn;
        }

        public override string ToString()
        {
            var lightsOn = (LightIsOn) ? "ja" : "nej";
            return $"Rum: {Name}  Yta: {Size}m2  Ljus på: {lightsOn}";
        }
    }
}
