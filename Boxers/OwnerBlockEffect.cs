using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class OwnerBlockEffect : Effect, IEffect
    {

        public OwnerBlockEffect(BoxerStats _bstats, int _time)
        {
            bstats = _bstats;
            time = _time;
        }
        public override void ChangeBlock()
        {
            bstats.Deffence = bstats.Block;
        }

        public override void ChangeHP()
        {
        }

        public override void ChangeMaxHP()
        {
        }

        public override void ChangePower()
        {
        }

        public override void ChangeSpeed()
        {
        }

        public override void ChangeStats()
        {
            ChangeBlock();
            ChangeStunning();
        }

        public override void ChangeStunning()
        {
            bstats.Stunning = time;
        }

        public override bool IsDone()
        {
            if (time == 0)
            {
                bstats.Deffence = 0;
                bstats.Stunning = 0;
                return true;
            }
            return false;
        }

        public override void Update()
        {
            ChangeStats();
            time--;
        }
    }
}
