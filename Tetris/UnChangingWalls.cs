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
            //左城墙
            for (int i = 0; i < Game.h - 6; i++)
            {
                unChangeWalls[index] = new Wall(0, i);
                ++index;
            }
            //右城墙
            for (int i = 0; i < Game.h - 6; i++)
            {
                unChangeWalls[index] = new Wall(Game.w - 2, i);
                ++index;
            }
            //下城墙
            for (int i = 2; i < Game.w - 2; i += 2)
            {
                unChangeWalls[index] = new Wall(i, Game.h - 6 - 1);
                ++index;
            }
        }

        //固定地图消除(待完善，可不写)
        public void Delete()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 绘制固定地图
        /// </summary>
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
