using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoorSimulator
{
    public class Bark
    {
        private readonly string _sound;

        public Bark(string sound)
        {
            this._sound = sound;
        }

        public string GetSound()
        {
            return this._sound;
        }

        public Boolean Equals(Bark otherBark)
        {
            return this._sound.Equals(otherBark.GetSound(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
