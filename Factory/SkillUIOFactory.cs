using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;
using W40KRogueTrader_BuildPlanner.Repository;
using W40KRogueTrader_BuildPlanner.ViewModel.RogueTraderViewModel;

namespace W40KRogueTrader_BuildPlanner.Factory
{
    public sealed class SkillUIOFactory
    {
        private readonly SkillRepository skillRepository;
        private readonly CharacteristicsRepository characteristicsRepository;

        public SkillUIOFactory(SkillRepository skillRepo, CharacteristicsRepository characteristicsRepository)
        {
            this.skillRepository = skillRepo;
            this.characteristicsRepository = characteristicsRepository;
        }

        public SkillUIO fromSkill(Skill.SkillId skillId, List<SkillModifier> skillModifiers)
        {
            Skill? skill = skillRepository.Skills.Find(x => x.Id == skillId);

            if (skill == null)
            {
                throw new Exception("Skill with id '" + skillId.ToString() + "' not found in repository");
            }

            Characteristic? charateristic = characteristicsRepository.Characteristics.Find(x => x.Id == skill.BaseCharacteristic);

            if (charateristic == null)
            {
                throw new Exception("Characteristic with id '" + skill.BaseCharacteristic.ToString() + "' not found in repository");
            }

            int totalModifier = 0;
            foreach (SkillModifier mod in skillModifiers)
            {
                if (mod.Id == skillId)
                {
                    totalModifier += mod.Value;
                }
            }

            return new SkillUIO(skill.Id, skill.Description, charateristic.StartingValue, totalModifier);
        }
    }
}
