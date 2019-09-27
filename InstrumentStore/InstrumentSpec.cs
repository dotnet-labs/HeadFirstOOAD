using System.Collections.Generic;
using System.Linq;

namespace InstrumentStore
{
    
    public enum InstrumentType
    {
        Guitar,
        Banjo,
        Dobro,
        Fiddle,
        Bass,
        Mandolin
    }

    public enum Builder
    {
        Fender,
        Martin,
        Gibson,
        Collings,
        Olson,
        Ryan,
        Prs,
        Any
    }

    public enum Style
    {
        A,
        F
    }

    public enum Type
    {
        Acoustic,
        Electric
    }

    public enum Wood
    {
        IndianRosewood,
        BrazilianRosewood,
        Mahogany,
        Maple,
        Cocobolo,
        Cedar,
        Adirondack,
        Alder,
        Sitka
    }


    internal class InstrumentSpec
    {
        private readonly Dictionary<string, object> _properties;

        
        public InstrumentSpec(IDictionary<string, object> properties)
        {
            _properties = properties == null ? new Dictionary<string, object>() : new Dictionary<string, object>(properties);
        }

        public object GetProperty(string propertyName)
        {

            object value = _properties.TryGetValue(propertyName, out value) ? value : "No key!";
            return value;
        }

        public Dictionary<string, object> GetProperties()
        {
            return _properties;
        }

        public bool Matches(InstrumentSpec otherSpec)
        {
            return otherSpec.GetProperties().Keys.All(propertyName => GetProperty(propertyName).ToString() == otherSpec.GetProperty(propertyName).ToString());
        }
    }
}
