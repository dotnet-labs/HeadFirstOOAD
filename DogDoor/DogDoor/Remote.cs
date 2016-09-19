using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogDoorSimulator
{
    class Remote
    {
        private readonly DogDoor _door;

        public Remote(DogDoor door)
        {
            this._door = door;
        }

        public void PressButton()
        {
            Console.WriteLine("Pressing the remote control button...");

            if (_door.IsOpen())
            {
                _door.Close();
            }
            else _door.Open();
        }
    }
}
