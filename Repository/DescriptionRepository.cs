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

        private ADescribable? describable;
        public ADescribable? Describable
        {
            get => describable;
            set
            {
                if (describable != value)
                {
                    describable = value;
                    DescribableChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler? DescribableChanged;

        private DescriptionRepository()
        {
            Describable = null;
        }
    }
}
