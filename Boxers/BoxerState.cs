using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxers
{
    class BoxerState
    {
        public Texture2D texture;

        public Texture2D hitTexture;
        public Texture2D blockTexture;
        public Texture2D waitTexture;


        BoxerStates bs = new BoxerStates();
        int idleTime = 0;
        public int blockSize = 0;

        public BoxerStates BS { get { return bs; }
            set
            {
                blockSize = 0;
                switch (value)
                {
                    case BoxerStates.Hit:
                        idleTime = 50;
                        texture = hitTexture;
                        break;
                    case BoxerStates.Block:
                        idleTime = 30;
                        blockSize = 5;
                        texture = blockTexture;
                        break;
                    case BoxerStates.Wait:
                        idleTime = 40;
                        texture = waitTexture;
                        break;
                    default:
                        break;
                }
            }
        }

        public int GetIdleTime()
        {
            return idleTime;
        }

        public void Update()
        {
            idleTime--;
        }
    }
}
