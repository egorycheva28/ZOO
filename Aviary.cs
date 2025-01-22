using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public interface Aviary: OpenPart, ClosePart
    {
        void AddAnimalToAviary(Animal animal);
        void RemoveAnimalFromAviary(Animal animal);
        void CheckStatusAviary();
        bool CanAddAnimal(Animal animal);
        bool CanAddFeed<IFeed>() where IFeed : Feed;
        void AddFeedToAviary<IFeed>() where IFeed : Feed;
        void EatFood<IFeed>() where IFeed : Feed;
    }
}
