using System.Collections.Generic;
namespace ArtemisAPI.Models
{
    public enum EnergyType
    {
        StressUnits,
        Electricity,
        None
    }

    public class ProductRecipe
    {
        //public List<FactoryComponent>   Components  { get; set; }
        public Dictionary<EnergyType, uint>     UsedEnergies    { get; set; }
        public Dictionary<string, uint>         Materials       { get; set; }
        public Dictionary<string, uint>         Products        { get; set; }
    }
}