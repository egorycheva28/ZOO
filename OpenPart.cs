using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public interface OpenPart
    {
        void FeedAnimal<IFeed>(Visitor visitor) where IFeed : Feed;
        void MoveNewPart();
    }
}
