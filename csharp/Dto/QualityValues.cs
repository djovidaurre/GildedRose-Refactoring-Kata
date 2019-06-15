using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Dto
{
    public static class QualityValues
    {
        public static int HighestValuePossible(Item item)
        {
            if (item.Name.Equals(CustomisedItemFactory.SULFURAS))
            {
                return 80;
            }
            return 50;
        }
    }
}
