using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public abstract class Animal: Registry
    {
        public Guid Id { get; private set; }
        public string Type { get; set; }//вид животного
        public int Satiety { get; set; }//сытость
        public string Status { get; set; }//голоден или сыт
        public string Place { get; set; }
        public Animal(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
            Satiety = 100;
            Status = "Full";
            Place = "open";
        }
        public void DecreaseSatiety()
        {
            Satiety -= 1;
        }
        public abstract void MakeSound();
        public abstract void CheckStatus();
        public abstract bool CanEatFeed<IFeed>() where IFeed : Feed;
    }
}
