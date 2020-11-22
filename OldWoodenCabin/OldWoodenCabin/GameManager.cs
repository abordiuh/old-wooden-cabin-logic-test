using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using OldWoodenCabin.Environments;
using OldWoodenCabin.Items;
using OldWoodenCabin.Objects;

namespace OldWoodenCabin
{
    class GameManager
    {
        public float CurrentFood = 3;
        public float CurrentHeat = 3;
        public float CurrentMood = 3;

        public float CurrentFoodModifier = 0;
        public float CurrentHeatModifier = 0;
        public float CurrentMoodModifier = 0;

        public GameEnvironment CurrentEnvironment;

        public List<GameEnvironment> Environments;
        public List<Item> Inventory;

        public void CreateNewGame()
        {
            Inventory = new List<Item>();
            Environments = new List<GameEnvironment>();
            Environments.Add(
                new GameEnvironment()
                {
                    Name = "Cabin",
                    PsHeatModifier = 0.01f,
                    //MaxHeatModifier = 3.5f,
                    //MinHeatModifier = 3f
                    Objects =
                    {
                        new SoFurnace()
                    },
                    Items =
                    {
                        new ItApple(),
                        new ItAxe(),
                        new ItVodka()
                    }
                });

            Environments.Add(
                new GameEnvironment()
                {
                    Name = "Cabin Outside",
                    PsHeatModifier = -0.1f,
                    //MaxHeatModifier = 3.5f,
                    //MinHeatModifier = 3f
                    Objects = {
                        new SoChoppingBlock()
                    },
                    Items =
                    {
                        new ItWood()
                    }
                });

            CurrentEnvironment = Environments[0];
        }


        public bool TryAddToInventory(Item item, bool force = false)
        {
            if (Inventory.Count >= 10)
                return false;

            Inventory.Add(item);
            return true;
        }

        public bool MoveItemFromEnvToInv(string itemName)
        {
            var item = CurrentEnvironment.Items.FirstOrDefault(i => i.Name == itemName);
            if (TryAddToInventory(item))
            {
                CurrentEnvironment.Items.Remove(item);
                return true;
            }

            return false;
        }

        public bool MoveItemFromInvToEnv(string itemName)
        {
            var item = Inventory.FirstOrDefault(i => i.Name == itemName);
            CurrentEnvironment.Items.Add(item);
            Inventory.Remove(item);
            return true;
        }

        public void UseItem(string itemName)
        {
            var item = Inventory.FirstOrDefault(i => i.Name == itemName);
            if (item.CanConsume)
            {
                CurrentFood += item.PsFoodModifier;
                CurrentHeat += item.PsHeatModifier;
                CurrentMood += item.PsMoodModifier;

                Inventory.Remove(item);
            }
        }

        public void ApplyItems(IEnumerable<Item> items, StaticObject applyObject)
        {
            if (applyObject == null)
                return;

            var (ok, returnItem) = applyObject.OnApplyItems(items.ToArray());
            foreach (var item in items)
            {
                if (item.ShouldDelete)
                    Inventory.Remove(item);
            }
            if(ok)
                Inventory.Add(returnItem);
        }
    }


}
