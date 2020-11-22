using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using OldWoodenCabin.Items;
using OldWoodenCabin.Objects;

namespace OldWoodenCabin.Objects
{
    public class StaticObject
    {
        public string Name { get; set; } = "";

        public float PsFoodModifier = 0;
        public float PsHeatModifier = 0;
        public float PsMoodModifier = 0;

        public string State = "";

        public List<string> ApplicableItemNames = new List<string>();

        public delegate (bool, Item) ApplyItems(Item[] items);
        public delegate bool OnActivate();

        public ApplyItems OnApplyItems;
    }

    public class SoFurnace : StaticObject
    {
        public SoFurnace()
        {
            Name = "Furnace";
            ApplicableItemNames = new List<string>(){ "Firewood" };

            OnApplyItems = items =>
            {
                if (State != "on" && items[0].Name == "Firewood")
                {
                    State = "on";
                    PsHeatModifier = 0.1f;
                    return (true, null);
                }
                return (false, null);
            };
        }
    }

    public class SoChoppingBlock : StaticObject
    {
        public SoChoppingBlock()
        {
            Name = "Chopping Block";
            ApplicableItemNames = new List<string>() { "Axe", "Wood" };

            OnApplyItems = items =>
            {
                if (items.Length == 2 && items.Any(i => i.Name == "Wood") && items.Any(i => i.Name == "Axe"))
                {
                    items.First(i => i.Name == "Wood").ShouldDelete = true;
                    return (true, new ItFirewood());
                }
                return (false, null);
            };
        }
    }
}
