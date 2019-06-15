using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IUpdateStrategyFactory
    {
        IUpdateStrategy Create(Item item);
    }
}
