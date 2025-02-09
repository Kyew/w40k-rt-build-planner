using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class OriginRepository
    {
        private static OriginRepository? instance = null;

        public static OriginRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OriginRepository();
                }
                return instance;
            }
        }

        public List<Origin> Origins { get; }

        private OriginRepository()
        { 
            Origins = new List<Origin>();

            
            Origins.Add(new Origin(Origin.OriginId.Astra_Militarum_Commander, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Lore_Imperium, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Athletics, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Persuasion, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Awareness, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Coercicion, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Medicae, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Comissar, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Logic, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Coercicion, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Demolition, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Awareness, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Persuasion, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Athletics, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Crime_Lord, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Logic, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Lore_Imperium, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Logic, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Persuasion, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Carouse, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Commerce, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Ministorum_Priest, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Lore_Warp, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Lore_Imperium, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Athletics, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Awareness, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Persuasion, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Medicae, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Navy_Officer, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Tech_Use, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Commerce, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Awareness, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Logic, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Commerce, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Persuasion, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Noble, "",
                                   null,
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Persuasion, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Commerce, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Coercicion, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Lore_Warp, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Lore_Imperium, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Carouse, -5)) }
                                   ));
            Origins.Add(new Origin(Origin.OriginId.Sanctionned_Psyker, "",
                                   new List<OriginArg> { new OriginArg("Biomancer", ""),
                                                         new OriginArg("Diviner", ""),
                                                         new OriginArg("Pyromancer", ""),
                                                         new OriginArg("Sanctic", ""),
                                                         new OriginArg("Telepath", "") },
                                   new List<Triumph> { new Triumph(Triumph.TriumphId.Apex_Of_Brilliance, "", new SkillModifier(Skill.SkillId.Lore_Xenos, 5)),
                                                       new Triumph(Triumph.TriumphId.Illustrious_Glory, "", new SkillModifier(Skill.SkillId.Persuasion, 5)),
                                                       new Triumph(Triumph.TriumphId.Feat_of_Greatness, "", new SkillModifier(Skill.SkillId.Coercicion, 5)) },
                                   new List<DarkestHour> { new DarkestHour(DarkestHour.DarkestHourId.Grim_Portents, "", new SkillModifier(Skill.SkillId.Logic, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Brand_of_Shame, "", new SkillModifier(Skill.SkillId.Awareness, -5)),
                                                           new DarkestHour(DarkestHour.DarkestHourId.Shadow_of_Torments, "", new SkillModifier(Skill.SkillId.Lore_Warp, -5)) }
                                   ));
        }
    }
}
