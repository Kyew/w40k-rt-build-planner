using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class HomeWorldArg : IDescribable
    {
        public Description Description { get; }

        public List<CharacteristicModifier>? CharacteristicModifiers => Description.CharacteristicModifiers;

        public HomeWorldArg(String name = "", String description = "", List<CharacteristicModifier>? modifiers = null)
        {
            Description = new Description(name, description, null, modifiers);
        }
    }
}
