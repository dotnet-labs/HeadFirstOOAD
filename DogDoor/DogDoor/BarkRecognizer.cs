using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoorSimulator
{
    class BarkRecognizer
    {
        private readonly DogDoor _door;

        public BarkRecognizer(DogDoor door)
        {
            this._door = door;
        }

        public void Recognize(Bark bark)
        {
            Console.WriteLine("    BarkRecognizer: Heard a \' {0} \'", bark.GetSound());

            List<Bark> allowedBarks = _door.GetAllowedBarks();

            if (allowedBarks.Any(allowedBark => allowedBark.Equals(bark)))
            {
                _door.Open();
            }
            
            else Console.WriteLine("This dog is not allowed.");
        }

    }
}
