using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Dto
{
    public class ConjuredItem : StandardItem
    {
        public ConjuredItem(Item item) : base(item)
        {

        }

        //public override  int DecreasingValueOverZeroDaysToSell()
        //{
        //    return 2;
        //}
    }
}
