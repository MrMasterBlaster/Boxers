using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boxers.Game1;

namespace Boxers
{
    class Condition
    {
        public int weigth = 0;
        public BoxerStates bs;
        public boxerAction ba;

        public Condition(BoxerStates _bs, boxerAction _ba)
        {
            bs = _bs;
            ba = _ba;
        }
        public Condition()
        {

        }

        public bool GetAnswer(BoxerStates _bs)
        {
            if (bs == _bs)
            {
                return true;
            }
            return false;
        }

        public boxerAction GetAction(BoxerStates _bs)
        {
            if (GetAnswer(_bs))
            {
                return ba;
            }
            return null;
        }

        public string GetStringCouse()
        {
            switch (bs)
            {
                case BoxerStates.Hit:
                    return "hit";
                case BoxerStates.Block:
                    return "block";
                case BoxerStates.Wait:
                    return "wait";
                default:
                    return "";
            }
        }
        public string GetStringResult()
        {
            switch (ba.Method.Name)
            {
                case "Hit":
                    return "hit";
                case "Block":
                    return "block";
                case "Wait":
                    return "wait";
                default:
                    return "";
            }
        }
    }
}
