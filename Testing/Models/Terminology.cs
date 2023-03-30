using System.Collections.Generic;

namespace Testing.Models
{
    public class Terminology
    {
        public int ID { get; set; }
        public string Category  { get; set; }
        public int CategoryID { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
