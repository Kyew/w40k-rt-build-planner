using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class HomeWorld : IDescribable
    {
        public enum HomeWorldId
        {
            Death_World,
            Voidborn,
            Hive_World,
            Forge_World,
            Imperial_World,
            Fortress_World
        }

        public HomeWorldId Id { get; }
        public Description Description { get; }
        public List<HomeWorldArg>? PossibleArgs { get; }
        public List<CharacteristicModifier>? CharacteristicModifiers => Description.CharacteristicModifiers;

        public HomeWorld(HomeWorldId id, String description = "", List<HomeWorldArg>? args = null, List<CharacteristicModifier>? characteristicModifiers = null)
        {
            Id = id;
            Description = new Description(Enum.GetName(Id).Replace('_', ' '), description, null, characteristicModifiers);
            PossibleArgs = args;
        }

    }
}
