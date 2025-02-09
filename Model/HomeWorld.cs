using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class HomeWorld : ADescribable
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

        public List<HomeWorldArg>? PossibleArgs { get; }

        public HomeWorld(HomeWorldId id, String description = "", List<HomeWorldArg>? args = null) : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
            PossibleArgs = args;
        }

    }
}
