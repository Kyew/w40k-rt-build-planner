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
            HomeWorlds = new List<HomeWorld> { new HomeWorld(HomeWorld.HomeWorldId.Death_World, "You came from a death world.\nThere are a lot of deaths on death worlds. Like... a lot. So you're kind of use to it...\n\n\n\nSo you're kinda dark and cool I guess.", null, new List<CharacteristicModifier>{ new CharacteristicModifier(Characteristic.CharacteristicId.Strength, 5),
                                                                                                                                            new CharacteristicModifier(Characteristic.CharacteristicId.Thoughness, 5),
                                                                                                                                            new CharacteristicModifier(Characteristic.CharacteristicId.Agility, 5),
                                                                                                                                            new CharacteristicModifier(Characteristic.CharacteristicId.Intelligence, -5),
                                                                                                                                            new CharacteristicModifier(Characteristic.CharacteristicId.Fellowship, -5)}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Voidborn, "", null, new List<CharacteristicModifier>{ new CharacteristicModifier(Characteristic.CharacteristicId.Willpower, 5),
                                                                                                                                         new CharacteristicModifier(Characteristic.CharacteristicId.Intelligence, 5),
                                                                                                                                         new CharacteristicModifier(Characteristic.CharacteristicId.Strength, -5)}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Hive_World, "", null, new List<CharacteristicModifier>{ new CharacteristicModifier(Characteristic.CharacteristicId.Fellowship, 5),
                                                                                                                                           new CharacteristicModifier(Characteristic.CharacteristicId.Agility, 5),
                                                                                                                                           new CharacteristicModifier(Characteristic.CharacteristicId.Willpower, -5)}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Forge_World, "", new List<HomeWorldArg> { new HomeWorldArg("Analytic System"),
                                                                                                                             new HomeWorldArg("Locomotion System"),
                                                                                                                             new HomeWorldArg("Subskin Armour") }
                                                                                                  , new List<CharacteristicModifier>{ new CharacteristicModifier(Characteristic.CharacteristicId.Intelligence, 5),
                                                                                                                                      new CharacteristicModifier(Characteristic.CharacteristicId.Thoughness, 5),
                                                                                                                                      new CharacteristicModifier(Characteristic.CharacteristicId.Fellowship, -5)}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Imperial_World, "", new List<HomeWorldArg> { new HomeWorldArg("Humanity's Finest - Strength", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Strength, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Toughness", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Thoughness, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Agility", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Agility, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Intelligence", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Intelligence, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Perception", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Perception, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Willpower", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Willpower, 10) }),
                                                                                                                                new HomeWorldArg("Humanity's Finest - Fellowship", "", new List<CharacteristicModifier> { new CharacteristicModifier(Characteristic.CharacteristicId.Fellowship, 10) }),}),
                                               new HomeWorld(HomeWorld.HomeWorldId.Fortress_World, "", null, new List<CharacteristicModifier>{ new CharacteristicModifier(Characteristic.CharacteristicId.Perception, 5),
                                                                                                                                               new CharacteristicModifier(Characteristic.CharacteristicId.Willpower, 5),
                                                                                                                                               new CharacteristicModifier(Characteristic.CharacteristicId.Fellowship, -5)})};
        }
    }
}
