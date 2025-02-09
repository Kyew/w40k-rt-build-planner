using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Characteristic : ADescribable
    {
        public enum CharacteristicId
        {
            Ballistic_Skill,
            Weapon_Skill,
            Strength,
            Thoughness,
            Agility,
            Intelligence,
            Perception,
            Willpower,
            Fellowship
        }

        public CharacteristicId Id { get; }

        public int StartingValue { get; set; }

        public Characteristic(CharacteristicId id, String description = "", int startingValue = 0) : base(Enum.GetName(id).Replace('_', ' '), description)
        {
            Id = id;
            StartingValue = startingValue;
        }
    }
}
