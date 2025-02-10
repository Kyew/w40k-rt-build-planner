using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Model
{
    public class Skill : IDescribable
    {
        public enum SkillId
        {
            Athletics,
            Awareness,
            Carouse,
            Coercicion,
            Commerce,
            Demolition,
            Logic,
            Lore_Imperium,
            Lore_Warp,
            Lore_Xenos,
            Medicae,
            Persuasion,
            Tech_Use
        }

        public SkillId Id { get; }
        public Description Description { get; }
        public Characteristic.CharacteristicId BaseCharacteristic { get; }

        public Skill(SkillId id, String description, Characteristic.CharacteristicId baseCharacteristic)
        {
            Id = id;
            Description = new Description(Enum.GetName(Id).Replace('_', ' '), description);
            BaseCharacteristic = baseCharacteristic;
        }
    }
}
