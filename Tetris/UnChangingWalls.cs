using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class UnChangingMap : IDraw , IDelete
    {
        private Wall[] unChangeWalls;

        public UnChangingMap()
        {
            unChangeWalls = new Wall[(Game.h - 6) * 2 + Game.w / 2 - 2];
            int index = 0;
            for (int i = 0; i < Game.h - 6; i++)
            {
                unChangeWalls[index] = new Wall(0, i);
                ++index;
            }
            for (int i = 0; i < Game.h - 6; i++)
            {
                unChangeWalls[index] = new Wall(Game.w - 2, i);
                ++index;
            }
            for (int i = 2; i < Game.w - 2; i += 2)
            {
                unChangeWalls[index] = new Wall(i, Game.h - 6 - 1);
                ++index;
            }
        }

        //待补充
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            for (int i = 0; i < unChangeWalls.Length; i++)
            {
                unChangeWalls[i].Draw();
             }
        }
    }
    //internal class UnChangingWalls
    //{
    //}
}
