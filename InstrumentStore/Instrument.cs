namespace InstrumentStore
{
    internal class Instrument
    {
        public string SerialNumber { get; }
        public double Price { get; set; }
        public InstrumentSpec Spec { get; }

        public Instrument(string serialNumber, double price, InstrumentSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            Spec = spec;
        }
    }
}
