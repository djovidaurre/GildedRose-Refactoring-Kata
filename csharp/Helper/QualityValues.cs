using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public static class QualityValues
    {
        public static int HighestValuePossible(Item item)
        {
            if (item.Name.Equals(UpdateStrategyFactory.SULFURA))
            {
                return 80;
            }
            return 50;
        }
    }
}
