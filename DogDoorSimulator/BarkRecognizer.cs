using System;
using System.Linq;

namespace DogDoorSimulator
{
    internal class BarkRecognizer
    {
        private readonly DogDoor _door;

        public BarkRecognizer(DogDoor door)
        {
            _door = door;
        }

        public void Recognize(Bark bark)
        {
            Console.WriteLine("    BarkRecognizer: Heard a \' {0} \'", bark.GetSound());

            var allowedBarks = _door.GetAllowedBarks();

            if (allowedBarks.Any(allowedBark => allowedBark.Equals(bark)))
            {
                _door.Open();
            }

            else Console.WriteLine("This dog is not allowed.");
        }
    }
}
