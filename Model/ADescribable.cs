using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public abstract class ADescribable
    {
        public String Name { get; }
        public String Description { get; }

        public ADescribable(String name = "", String description = "")
        {
            Name = name;
            Description = description;
        }
    }
}
