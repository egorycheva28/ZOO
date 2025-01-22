using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП
{
    public class Feed: Registry
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int Weight { get; set; }
        
        public Feed(string brand, int weight)
        {
            Id = Guid.NewGuid();
            Brand = brand;
            Weight = weight;
        }
    }

    public class Feed1 : Feed
    {
        public int MaxCapacity { get; set; }
        public Feed1(string brand, int weight)
            : base(brand, weight)
        {
            MaxCapacity = 9;
        }
    }

    public class Feed2 : Feed
    {
        public int MaxCapacity { get; set; }
        public Feed2(string brand, int weight)
            : base(brand, weight)
        {
            MaxCapacity = 10;
        }
    }

    public class Feed3 : Feed
    {
        public int MaxCapacity { get; set; }
        public Feed3(string brand, int weight)
            : base(brand, weight)
        {
            MaxCapacity = 8;
        }
    }
}
