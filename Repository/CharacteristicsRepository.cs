using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class CharacteristicsRepository
    {
        private static CharacteristicsRepository? instance = null;

        public static CharacteristicsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacteristicsRepository();
                }
                return instance;
            }
        }

        public List<Characteristic> Characteristics { get; }

        public CharacteristicsRepository()
        {
            Characteristics = new List<Characteristic> { new Characteristic(Characteristic.CharacteristicId.Ballistic_Skill, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Weapon_Skill, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Strength, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Thoughness, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Agility, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Intelligence, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Perception, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Willpower, "", 30),
                                                         new Characteristic(Characteristic.CharacteristicId.Fellowship, "", 30)};
        }
    }
}
