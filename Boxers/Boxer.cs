﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class Boxer
    {
        public BoxerStats boxerStats;
        public EffectsPool EffectsPool;
        public int points;

        Rectangle icon;
        Rectangle hpPos;
        Vector2 pointsTextPos;

        public Texture2D hpTex;

        public ActionHistory ah;
        SpriteFont textBlock;
        public BoxerState bs = new BoxerState();
        AI ai;

        Boxer enemy;
        
        public Boxer SetEnemy { set { enemy = value; ai.SelectEnemy(value); } }

        public AI GetAi { get { return ai; } }

        public Boxer(Rectangle _icon, SpriteFont _textBlock, BoxerStats _boxerStats)
        {
            icon = _icon;
            pointsTextPos = new Vector2(icon.X + 120, icon.Y);
            boxerStats = _boxerStats;
            points = 0;
            ai = new AI(this);
            hpPos = new Rectangle(icon.X, icon.Y + 120, boxerStats.HP, 30);
            bs.BS = BoxerStates.Block;
            textBlock = _textBlock;
            ah = new ActionHistory(textBlock, hpPos);
            EffectsPool = new EffectsPool();
        }


        public Boxer(Rectangle _icon, SpriteFont _textBlock, AI _ai, BoxerStats _boxerStats)
        {
            icon = _icon;
            pointsTextPos = new Vector2(icon.X + 120, icon.Y);
            boxerStats = _boxerStats;
            points = 0;
            ai = _ai;
            hpPos = new Rectangle(icon.X, icon.Y + 120, boxerStats.HP, 30);
            bs.BS = BoxerStates.Block;
            textBlock = _textBlock;
            ah = new ActionHistory(textBlock, hpPos);
            EffectsPool = new EffectsPool();
        }


        public void Hit()
        {
            ah.AddRecord("I hit ");
            bs.BS = BoxerStates.Hit;
            EffectsPool.AddEffect(new OwnerHitEffect(enemy, boxerStats, 50 - boxerStats.Speed / 2, 100 - boxerStats.Speed));
            
            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth += 0;
                    points += 1;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth -= 1;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth += 2;
                    points += 1;
                    break;
                default:
                    break;
            }
        }

        public void Block()
        {
            ah.AddRecord("I block ");
            bs.BS = BoxerStates.Block;
            EffectsPool.AddEffect(new OwnerBlockEffect(boxerStats, 80 - boxerStats.Speed));

            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth += 1;
                    points += 0;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth += 0;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth -= 1;
                    points += 0;
                    break;
                default:
                    break;
            }
        }

        public void Wait()
        {
            ah.AddRecord("I wait ");
            bs.BS = BoxerStates.Wait;
            EffectsPool.AddEffect(new OwnerWaitEffect(boxerStats, 80 - boxerStats.Speed, 1, this));

            switch (enemy.bs.BS)
            {
                case BoxerStates.Hit:
                    ai.controlValue.weigth -= 2;
                    points += 0;
                    break;
                case BoxerStates.Block:
                    ai.controlValue.weigth += 2;
                    points += 0;
                    break;
                case BoxerStates.Wait:
                    ai.controlValue.weigth += 0;
                    points += 0;
                    break;
                default:
                    break;
            }
        }
        

        public void Update()
        {
            if (boxerStats.Stunning <= 0)
            {
                ah.NewAct();
                ai.DoAction();
                if (ah.History.Count > 0 && ai.controlValue != null)
                {
                    //ah.AddRecord("my tactic is: if he " + ai.controlValue.GetStringCouse() + " then I " + ai.controlValue.GetStringResult() + " it like " + ai.controlValue.weigth + ". I got " + points + " points.");
                    ah.AddRecord(". I got " + points + " points.");
                }
            }
            EffectsPool.Update();
            hpPos.Width = boxerStats.HP;

        }

        private void DrawConditionsInfo(SpriteBatch spriteBatch)
        {
            int k = 0;
            foreach (var cond in ai.GetConditions)
            {
                string str = "if HE " + cond.GetStringCouse() + " then I " + cond.GetStringResult() + " is " + cond.weigth;
                spriteBatch.DrawString(textBlock, str, new Vector2(pointsTextPos.X + 25, pointsTextPos.Y + k * 20), Color.Black);
                k++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bs.texture, icon, Color.White);
            spriteBatch.Draw(hpTex, hpPos, Color.White);
            DrawConditionsInfo(spriteBatch);
            spriteBatch.DrawString(textBlock, Convert.ToString(points), pointsTextPos, Color.Black);
            ah.Draw(spriteBatch);
        }
    }
}
