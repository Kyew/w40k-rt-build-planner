using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class OriginArg : IDescribable
    {
        public Description Description { get; }

        public OriginArg(String name = "", String description = "")
        {
            Description = new Description(name, description);
        }
    }
}
