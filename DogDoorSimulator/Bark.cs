using System;

namespace DogDoorSimulator
{
    public class Bark
    {
        private readonly string _sound;

        public Bark(string sound)
        {
            _sound = sound;
        }

        public string GetSound()
        {
            return _sound;
        }

        public bool Equals(Bark otherBark)
        {
            return _sound.Equals(otherBark.GetSound(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
