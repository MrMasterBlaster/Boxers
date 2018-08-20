using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boxers.Game1;

namespace Boxers
{
    class AI
    {
        List<Condition> conditions;
        Boxer owner;
        Boxer enemy;
        Array states;
        List<boxerAction> actions;
        public Condition controlValue;
        Random r;

        public List<Condition> GetConditions { get { return conditions; } }

        public AI(Boxer _owner)
        {
            owner = _owner;

            conditions = new List<Condition>();
            states = Enum.GetValues(typeof(BoxerStates));
            actions = new List<boxerAction>();

            actions.Add(new boxerAction(owner.Hit));
            actions.Add(new boxerAction(owner.Block));
            actions.Add(new boxerAction(owner.Wait));
            r = new Random();
        }

        public void SelectEnemy(Boxer _enemy)
        {
            enemy = _enemy;
        }

        public void DoAction()
        {
            controlValue = new Condition();
            boxerAction ba = null;
            if (r.Next(100) < 90)
            {
                foreach (var cond in conditions)
                {
                    ba = cond.GetAction(enemy.bs.BS);
                    controlValue = cond;
                }
                if (ba == null)
                {
                    CreateNewCondition();
                    ba = conditions[conditions.Count - 1].GetAction(enemy.bs.BS);
                    controlValue = conditions[conditions.Count - 1];
                }
                ba.Invoke();
            }
            else
            {
                CreateNewCondition();
                ba = conditions[conditions.Count - 1].GetAction(enemy.bs.BS);
                ba.Invoke();
                controlValue = conditions[conditions.Count - 1];
                SortConditions();
            }
        }


        
        public void SortConditions()
        {
            List<Condition> newConditions = new List<Condition>();
            Condition minWeidthCond;
            for (int i = 0; i < conditions.Count; i++)
            {
                for (int j = 0; j < conditions.Count - 1; j++)
                {
                    if (conditions[j].weigth > conditions[j + 1].weigth)
                    {
                        minWeidthCond = conditions[j + 1];
                        conditions[j] = conditions[j + 1];
                        conditions[j + 1] = minWeidthCond;
                    }
                }
            }
        }

        public void CreateNewCondition()
        {
            Random random = new Random();
            //Random random1 = new Random(random.Next());
            //Condition cond = new Condition((BoxerStates)states.GetValue(random.Next(states.Length)), actions.ElementAt(random1.Next(actions.Count)));
            Condition cond = new Condition(enemy.bs.BS, actions.ElementAt(random.Next(actions.Count)));
            
            int k = 0;

            if (conditions.Count == 0)
            {
                conditions.Add(cond);
            }
            else
            //while (conditions.IndexOf(cond) != -1)
            while (IsExistCondition(cond) && k < 100)
            {
                k++;
                //random = new Random(random1.Next());
                //random1 = new Random(random.Next());
                //cond = new Condition((BoxerStates)states.GetValue(random.Next(states.Length)), actions.ElementAt(random1.Next(actions.Count)));
                cond = new Condition(enemy.bs.BS, actions.ElementAt(random.Next(actions.Count)));
            }
            if (!IsExistCondition(cond))
            {
                conditions.Add(cond);
            }
        }
        
        bool IsExistCondition(Condition cond)
        {
            foreach (var c in conditions)
            {
                if (cond.GetStringCouse() == c.GetStringCouse() && cond.GetStringResult() == c.GetStringResult())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
