using System;
using System.Collections.Generic;

namespace DogDoorSimulator
{
    internal class DogDoor
    {
        private bool _open;
        private readonly List<Bark> _allowedBarks;

        public DogDoor(List<Bark> allowedBarks)
        {
            _allowedBarks = allowedBarks;
            _open = false;
        }

        public DogDoor(bool open, List<Bark> allowedBarks)
        {
            _open = open;
            _allowedBarks = allowedBarks;
        }

        public DogDoor()
        {
            _open = false;
            _allowedBarks = new List<Bark>();
        }


        public List<Bark> GetAllowedBarks()
        {
            return _allowedBarks;
        }

        public void Open()
        {
            Console.WriteLine("The dog door opens..");
            _open = true;
            System.Threading.Thread.Sleep(3000);

            Close();
        }


        public bool IsOpen()
        {
            return _open;
        }

        public void Close()
        {
            Console.WriteLine("The dog door closes..");
            _open = false;
        }

        public void AddAllowedBark(Bark bark)
        {
            try
            {
                _allowedBarks.Add(bark);
            }
            catch (NullReferenceException exception)
            {

                throw new Exception(exception.ToString());
            }
        }
    }
}
