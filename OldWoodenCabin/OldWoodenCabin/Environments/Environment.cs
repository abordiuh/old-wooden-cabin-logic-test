using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldWoodenCabin.Items;
using OldWoodenCabin.Objects;

namespace OldWoodenCabin.Environments
{
    public class GameEnvironment
    {
        public string Name { get; set; } = "";

        public float PsFoodModifier = 0;
        public float MinFoodModifier = 0;
        public float MaxFoodModifier = 6;

        public float PsHeatModifier = 0;
        public float MinHeatModifier = 0;
        public float MaxHeatModifier = 6;

        public float PsMoodModifier = 0;
        public float MinMoodModifier = 0;
        public float MaxMoodModifier = 6;

        public List<Item> Items = new List<Item>();
        public List<StaticObject> Objects = new List<StaticObject>();

    }
}
