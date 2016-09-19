using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace DogDoorSimulator
{
    class DogDoor
    {
        private Boolean _open;
        private readonly List<Bark> _allowedBarks;

        public DogDoor(List<Bark> allowedBarks)
        {
            this._allowedBarks = allowedBarks;
            this._open = false;
        }

        public DogDoor(Boolean open, List<Bark> allowedBarks)
        {
            this._open = open;
            this._allowedBarks = allowedBarks;
        }

        public DogDoor()
        {
            this._open=false;
            this._allowedBarks = new List<Bark>();
        }


        public List<Bark> GetAllowedBarks()
        {
            return _allowedBarks;
        }
        
        public void Open()
        {
            Console.WriteLine("The dog door opens..");
            this._open = true;
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
            this._open=false;
        }

        public void AddAllowedBark(Bark bark)
        {

            try
            {
                    this._allowedBarks.Add(bark);
            }
            catch (NullReferenceException exception)
            {
                
                throw new Exception(exception.ToString());
            }
        }
    }
}
