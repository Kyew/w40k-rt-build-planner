using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W40KRogueTrader_BuildPlanner.Model;

namespace W40KRogueTrader_BuildPlanner.Repository
{
    public sealed class DescriptionRepository
    {
        private static DescriptionRepository? instance = null;

        public static DescriptionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DescriptionRepository();
                }
                return instance;
            }
        }

        private Description? description;
        public Description? Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    DescribableChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler? DescribableChanged;

        private DescriptionRepository()
        {
            Description = null;
        }
    }
}
