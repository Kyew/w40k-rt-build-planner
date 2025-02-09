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
            Skills = new List<Skill> { new Skill(Skill.SkillId.Athletics, "STR", Characteristic.CharacteristicId.Strength),
                                       new Skill(Skill.SkillId.Awareness, "PER", Characteristic.CharacteristicId.Perception),
                                       new Skill(Skill.SkillId.Carouse, "TGH", Characteristic.CharacteristicId.Thoughness),
                                       new Skill(Skill.SkillId.Coercicion, "FEL", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Commerce, "FEL", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Logic, "INT", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Imperium, "INT", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Warp, "INT", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Lore_Xenos, "INT", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Medicae, "INT", Characteristic.CharacteristicId.Intelligence),
                                       new Skill(Skill.SkillId.Persuasion, "FEL", Characteristic.CharacteristicId.Fellowship),
                                       new Skill(Skill.SkillId.Tech_Use, "INT", Characteristic.CharacteristicId.Intelligence) };
        }
    }
}
