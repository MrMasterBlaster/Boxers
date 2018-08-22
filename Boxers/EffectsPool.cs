using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class EffectsPool
    {
        public List<Effect> Effects;

        public EffectsPool()
        {
            Effects = new List<Effect>();
        }

        public void AddEffect(Effect effect)
        {
            Effects.Add(effect);
        }

        

        public void Update()
        {
            foreach (var eff in Effects)
            {
                eff.Update();
            }
            for (int i = 0; i < Effects.Count; i++)
            {
                if (Effects[i].IsDone())
                {
                    Effects.Remove(Effects[i]);
                }
            }
        }
    }
}
