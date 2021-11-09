using System.Collections.Generic;

namespace ArtemisAPI.Models
{
    public class ProductionLine
    {
        public string                   Name            { get; set; }
        public Coordinates              Position        { get; set; }
        public Dictionary<string, uint> StoredItems     { get; set; }
        public ProductRecipe            Recipe          { get; set; }   
    }
}