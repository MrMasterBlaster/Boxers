using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    interface IEffect
    {
        void ChangeStats();

        void ChangeMaxHP();

        void ChangeHP();

        void ChangePower();

        void ChangeSpeed();

        void ChangeBlock();

        void ChangeStunning();

        bool IsDone();

        void Update();
    }
}
