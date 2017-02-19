using System.Collections.Generic;

namespace CountingKs.Models
{
    public class FoodModel
    {
        public string url { get; set; }
        public string Description { get; set; }
        public IEnumerable<MeasureModel> Measures { get; set; }
    }
}