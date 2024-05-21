using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    internal class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }
        public string Picture { get; set; }

        public Pet(string line)
        {
            string[] data = line.Split(";");
            Name = data[0];
            Age = int.Parse(data[1]);
            Color = data[2];
            Picture = data[3];
        }
    }
}
