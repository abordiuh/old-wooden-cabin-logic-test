using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldWoodenCabin.Objects;

namespace OldWoodenCabin.Items
{
    public class Item
    {
        public string Name { get; set; } = "";

        public float PsFoodModifier = 0;
        public float PsHeatModifier = 0;
        public float PsMoodModifier = 0;

        public bool CanConsume = false;

        public bool ShouldDelete = false;
    }

    public class ItWood : Item
    {
        public ItWood()
        {
            Name = "Wood";
        }
    }
    public class ItFirewood : Item
    {
        public ItFirewood()
        {
            Name = "Firewood";
        }
    }
    public class ItAxe : Item
    {
        public ItAxe()
        {
            Name = "Axe";
        }
    }
    public class ItApple : Item
    {
        public ItApple()
        {
            Name = "Apple";
            CanConsume = true;
            PsFoodModifier = 0.5f;
            PsMoodModifier = 0.1f;
        }
    }
    public class ItVodka : Item
    {
        public ItVodka()
        {
            Name = "Vodka";
            CanConsume = true;
            PsFoodModifier = 0.1f;
            PsHeatModifier = 0.1f;
            PsMoodModifier = 1.5f;
        }
    }

}
