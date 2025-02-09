using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class HomeWorldRepository
    {
        private static HomeWorldRepository? instance = null;

        public static HomeWorldRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomeWorldRepository();
                }
                return instance;
            }
        }

        public List<HomeWorld> HomeWorlds { get; set; }

        private HomeWorldRepository()
        {
            HomeWorlds = new List<HomeWorld> { new HomeWorld(HomeWorld.HomeWorldId.Death_World),
                                               new HomeWorld(HomeWorld.HomeWorldId.Voidborn),
                                               new HomeWorld(HomeWorld.HomeWorldId.Hive_World),
                                               new HomeWorld(HomeWorld.HomeWorldId.Forge_World, "", new List<HomeWorldArg> { new HomeWorldArg("Analytic System"),
                                                                                                                             new HomeWorldArg("Locomotion System"),
                                                                                                                             new HomeWorldArg("Subskin Armour") }),
                                               new HomeWorld(HomeWorld.HomeWorldId.Imperial_World, "", new List<HomeWorldArg> { new HomeWorldArg("Humanity's Finest - Strength"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Toughness"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Agility"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Intelligence"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Perception"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Willpower"),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Fellowship"),}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Fortress_World) };
        }
    }
}
