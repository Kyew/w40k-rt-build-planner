using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Characteristic : IDescribable
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
        public Description Description { get; }
        public int StartingValue { get; }

        public Characteristic(CharacteristicId id, String description = "", int startingValue = 0)
        {
            Id = id;
            Description = new Description(Enum.GetName(Id).Replace('_', ' '), description);
            StartingValue = startingValue;
        }
    }
}
