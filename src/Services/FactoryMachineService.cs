using System;
using System.Linq;
using System.Collections.Generic;
using ArtemisAPI.Models;

namespace ArtemisAPI.Services
{
    public static class FactoryMachineService
    {
        private static List<ProductionLine> s_factories { get; }

        static FactoryMachineService()
        {
            s_factories = new List<ProductionLine>()
            {
                new ProductionLine()
                {
                    Name = "KelpFarm",
                    Position = new Coordinates(134, 21, -343),
                    Recipe = new ProductRecipe()
                    {
                        UsedEnergies = new Dictionary<EnergyType, uint>() 
                        {
                            { EnergyType.StressUnits, 86 }
                        },
                        Materials = new Dictionary<string, uint>(),
                        Products = new Dictionary<string, uint>()
                        {
                            { "minecraft:kelp", 1 }
                        }
                    },
                    StoredItems = new Dictionary<string, uint>()
                    {
                        { "minecraft:kelp", 256 }
                    }
                },

                new ProductionLine()
                {
                    Name = "ClayGenerator",
                    Position = new Coordinates(160, 30, -429),
                    Recipe = new ProductRecipe()
                    {
                        UsedEnergies = new Dictionary<EnergyType, uint>()
                        {
                            { EnergyType.StressUnits, 82 }
                        },
                        Materials = new Dictionary<string, uint>()
                        {
                            { "minecraft:sand", 1 },
                            { "create:white_sand", 1 },
                            { "create:orange_sand", 1 }
                        },
                        Products = new Dictionary<string, uint>()
                        {
                            { "minecraft:clay", 1 }
                        }
                    },
                    StoredItems = new Dictionary<string, uint>()
                    {
                        { "minecraft:clay", 352 }
                    }
                },
                new ProductionLine()
                {
                    Name = "AndesiteAlloyGenerator",
                    Position = new Coordinates(154, 24, -460),
                    Recipe = new ProductRecipe()
                    {
                        UsedEnergies = new Dictionary<EnergyType, uint>()
                        {
                            { EnergyType.StressUnits, 124 }
                        },
                        Materials = new Dictionary<string, uint>()
                        {
                            { "kubejs:the_slimy_brick_thing", 2 },
                            { "create:andesite_cobblestone", 2 }
                        },
                        Products = new Dictionary<string, uint>()
                        {
                            { "create:andesite_alloy", 1 }
                        }
                    },
                    StoredItems = new Dictionary<string, uint>()
                    {
                        { "create:andesite_alloy", 522 }
                    }
                },
                                new ProductionLine()
                {
                    Name = "SlimyBrickThingBlockGenerator",
                    Position = new Coordinates(154, 24, -495),
                    Recipe = new ProductRecipe()
                    {
                        UsedEnergies = new Dictionary<EnergyType, uint>()
                        {
                            { EnergyType.StressUnits, 75 }
                        },
                        Materials = new Dictionary<string, uint>()
                        {
                            { "kubejs:the_slimy_brick_thing", 4 }
                        },
                        Products = new Dictionary<string, uint>()
                        {
                            { "kubejs:the_slimy_brick_thing_block", 1 }
                        }
                    },
                    StoredItems = new Dictionary<string, uint>()
                    {
                        { "kubejs:the_slimy_brick_thing_block", 4 }
                    }
                }
            };
        }


        public static IEnumerable<ProductionLine> FactoriesFromMaterials(params string[] materials)
        {
            return s_factories.Where(factory => factory.Recipe.Materials.All(item => materials.Contains(item.Key)));

            // var ret = new List<ProductionLine>();
            // foreach (ProductionLine factory in _factories)
            // {
            //     foreach (Item item in factory.Recipe.Materials)
            //     {
            //         if (materials.Contains(item.ID))
            //         {
            //             ret.Add(factory);
            //         }
            //     }
            // }
            // return ret;
        }

        public static IEnumerable<ProductionLine> FactoriesFromProducts(params string[] products) => s_factories.Where(factory => factory.Recipe.Products.All(item => products.Contains(item.Key)));

        public static ProductionLine FactoryAtPosition(Coordinates position) => s_factories.FirstOrDefault(factory => factory.Position == position);

        public static ProductionLine Select(string name) => s_factories.FirstOrDefault(factory => factory.Name == name);
        public static void Add(ProductionLine factory) => s_factories.Add(factory);
        public static void Delete(string name)
        {
            ProductionLine factory = Select(name);
            if (factory is null)
                throw new NullReferenceException($"Could not get factory with name {name}!");
            s_factories.Remove(factory);
        }
        public static void Update(ProductionLine updatedFactory)
        {
            int index = s_factories.FindIndex(factory => factory.Name == updatedFactory.Name);
            if (index == -1) return;
            s_factories[index] = updatedFactory;
        } 

        public static IEnumerable<ProductionLine> AllFactories => s_factories;
    }
}