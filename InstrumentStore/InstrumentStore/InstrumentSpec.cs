using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
    };

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
    };

    public enum Style
    {
        A,
        F
    };

    public enum Type
    {
        Acoustic,
        Electric
    };

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
    };

    
    class InstrumentSpec
    {
        private readonly Dictionary<string, Object> _properties;

        
        public InstrumentSpec(IDictionary<string, Object> properties)
        {

            if (properties == null)
            {
                this._properties=new Dictionary<string, Object>();
            }
            else { this._properties= new Dictionary<string, Object>(properties);}
        }

        public Object GetProperty(string propertyName)
        {

            Object value = _properties.TryGetValue(propertyName, out value) ? value : "No key!";
            return value;
        }

        public Dictionary<string, Object> GetProperties()
        {
            return _properties;
        }

        public bool Matches(InstrumentSpec otherSpec)
        {

            return otherSpec.GetProperties().Keys.All(propertyName => GetProperty(propertyName).ToString() == otherSpec.GetProperty(propertyName).ToString());

        }

    }
    
}
