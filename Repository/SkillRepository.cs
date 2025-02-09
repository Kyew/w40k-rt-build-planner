using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class SkillRepository
    {
        private static SkillRepository? instance = null;

        public static SkillRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SkillRepository();
                }
                return instance;
            }
        }

        public List<Skill> Skills { get; }

        private SkillRepository()
        {
            Skills = new List<Skill> { new Skill(Skill.SkillId.Athletics, "", Characteristic.CharacteristicId.Strength),
                                       new Skill(Skill.SkillId.Awareness, "", Characteristic.CharacteristicId.Perception),
                                       new Skill(Skill.SkillId.Carouse, "", Characteristic.CharacteristicId.Thoughness),
                                       new Skill(Skill.SkillId.Coercicion, "", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Commerce, "", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Demolition, "", Characteristic.CharacteristicId.Agility),
                                       new Skill(Skill.SkillId.Logic, "", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Imperium, "", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Warp, "", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Xenos, "", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Medicae, "", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Persuasion, "", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Tech_Use, "", Characteristic.CharacteristicId.Intelligence) };
        }
    }
}
