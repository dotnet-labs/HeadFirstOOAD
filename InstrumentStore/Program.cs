using System;
using System.Collections.Generic;
using System.Linq;

namespace InstrumentStore
{
    internal class Program
    {
        private static void Main()
        {
            var inventory = new Inventory();
            InitializeInventory(inventory);

            var properties = new Dictionary<string, object> { { "Builder", Builder.Gibson }, { "BackWood", Wood.Maple } };
            var whatBryanLikes = new InstrumentSpec(properties);

            var matchingInstruments = inventory.SearchInstruments(whatBryanLikes);
            if (matchingInstruments.Any())
            {
                Console.WriteLine("Bryan, you might like these instruments:");
                foreach (var matchingInstrument in matchingInstruments)
                {
                    var spec = matchingInstrument.Spec;
                    Console.WriteLine("We have a {0} with the following properties:", spec.GetProperty("InstrumentType"));
                    foreach (var property in spec.GetProperties())
                    {
                        if (property.Key == "InstrumentType") continue;
                        Console.WriteLine("{0}: {1}", property.Key, property.Value);
                    }
                    Console.WriteLine("You can have this {0} for ${1} \n------", spec.GetProperty("InstrumentType"), matchingInstrument.Price);
                }

            }
            else Console.WriteLine("Sorry Bryan, we have nothing for you.");

            Console.ReadKey();
        }


        private static void InitializeInventory(Inventory inventory)
        {

            var properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Guitar},
                {"Builder", Builder.Gibson},
                {"Model", "CJ"},
                {"Type", Type.Acoustic},
                {"numStrings", "6"},
                {"TopWood", Wood.IndianRosewood},
                {"BackWood", Wood.Sitka}
            };

            inventory.AddInstrument("11277", 3999.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Guitar},
                {"Builder", Builder.Martin},
                {"Model", "D-18"},
                {"TopWood", Wood.Mahogany},
                {"BackWood", Wood.Adirondack}
            };
            inventory.AddInstrument("122784", 5495.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Guitar},
                {"Builder", Builder.Fender},
                {"Model", "Stratocastor"},
                {"Type", Type.Electric},
                {"TopWood", Wood.Alder},
                {"BackWood", Wood.Alder}
            };
            inventory.AddInstrument("V95693", 1499.95, new InstrumentSpec(properties));
            inventory.AddInstrument("V9512", 1549.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Guitar},
                {"Builder", Builder.Gibson},
                {"Model", "Les Paul"},
                {"TopWood", Wood.Maple},
                {"BackWood", Wood.Maple}
            };
            inventory.AddInstrument("70108276", 2295.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Guitar},
                {"Model", "SG '61 Reissue"},
                {"TopWood", Wood.Mahogany},
                {"BackWood", Wood.Mahogany}
            };
            inventory.AddInstrument("8276551", 1890.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Mandolin},
                {"Type", Type.Acoustic},
                {"Model", "F-5G"},
                {"TopWood", Wood.Maple},
                {"BackWood", Wood.Maple}
            };
            inventory.AddInstrument("9019920", 5495.95, new InstrumentSpec(properties));

            properties = new Dictionary<string, object>
            {
                {"InstrumentType", InstrumentType.Banjo},
                {"Type", Type.Acoustic},
                {"Model", "RB-3 Wreath"},
                {"TopWood", Wood.Maple},
                {"NumStrings", 5},
                {"BackWood", Wood.Maple}
            };
            inventory.AddInstrument("8900231", 2495.95, new InstrumentSpec(properties));

            //            foreach (var instrument in inventory.GetInventory())
            //            {
            //                var spec = instrument.Spec;
            //                Console.WriteLine("We have a {0} with the following properties:", spec.GetProperty("InstrumentType"));
            //                foreach (var property in spec.GetProperties())
            //                {
            //                    if (property.Key == "InstrumentType") continue;
            //                    Console.WriteLine("{0}: {1}", property.Key, property.Value);
            //                }
            //                Console.WriteLine("You can have this {0} for ${1} \n------", spec.GetProperty("InstrumentType"), instrument.Price);
            //            }
        }
    }
}
