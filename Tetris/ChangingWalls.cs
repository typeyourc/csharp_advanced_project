using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ChangingWalls
    {
        //public Dictionary<int,Wall[]> dictionaryWalls = new Dictionary<int, Wall[]>();
        
        public Wall[] walls;
        //私有静态实例
        public static ChangingWalls instanceOfChangingWalls = new ChangingWalls();
        //变化数组长度
        public static int changingWallsLength;
        //临时长度
        public int tempLength;

        //构造函数私有化
        private ChangingWalls() 
        {
            changingWallsLength = 0;
            walls = new Wall[changingWallsLength];

            //把每一行的坐标存到字典里
            //dictionaryWalls.Add(0, walls);
            //x是2-46
            //y是1-28
            //for (int j = 1; j <= 28; j++)
            //{
            //    Wall[] dicWalls = new Wall[Game.w / 2 - 2];
            //    for (int i = 0; i < Game.w / 2 - 2; i++)
            //    {
            //        dicWalls[i] = new Wall(2 + i * 2, j);
            //    }
            //    dictionaryWalls.Add(1, dicWalls);
            //}
        }

        //公共静态属性
        public static ChangingWalls InstanceOfChangingWalls
        {
            get
            {
                return instanceOfChangingWalls;
            }
        }

        /// <summary>
        /// 更新数组长度和叠加前的数组元素复制
        /// </summary>
        /// <param name="w">被更新数组</param>
        /// <param name="length">添加的长度</param>
        public Wall[] ChangingWallsSet(Wall[] w, int length)
        {
            Wall[] tempWalls = new Wall[w.Length + length];

            for (int i = 0; i < w.Length; i++)
            {
                tempWalls[i] = w[i];
            }
            //注意这个地方不能直接写w=tempWalls，因为这样的话，w和tempWalls指向的是同一个数组，实际上当函数结束
            //的时候不能更新walls的长度，具体原因待分析
            return tempWalls;
        }

        /// <summary>
        /// 增加变化地图
        /// </summary>
        public void AddShape()
        {
            tempLength = changingWallsLength;
            changingWallsLength += Shape.InstanceOfShape.cubes.Length;
            //这里需要加一句walls数组的更新，因为下面要用到walls，虽然changingWallsLength增加了，
            //但是并没有通过构造函数更新数组长度，因为构造函数只在实例化的时候执行一次。所以，我们
            //需要专门写一个更新的方法(增加长度)
            walls = ChangingWallsSet(walls, Shape.InstanceOfShape.cubes.Length);

            //下面只是增加新的形状的数据
            for (int i = tempLength,j = 0; i < changingWallsLength && j < Shape.InstanceOfShape.cubes.Length; i++, j++)
            {
                walls[i] = new Wall(Shape.InstanceOfShape.cubes[j].pos.x, Shape.InstanceOfShape.cubes[j].pos.y);

                //如果写成下面这样会有no instance报错，因为walls里面的元素需要实例化
                //walls[i].pos.x = Shape.InstanceOfShape.cubes[i].pos.x;
                //walls[i].pos.y = Shape.InstanceOfShape.cubes[i].pos.y;
            }
            Draw();
            Shape.InstanceOfShape.ShapeInit();
        }

        /// <summary>
        /// 判断是否满行
        /// </summary>
        public void isFullLine() 
        {
            //计算变化城墙有多少行
            int lineNum = 0;
            for (int i = 1; i <= 28; i++)
            {
                for (int j = 0; j < walls.Length; j++)
                {
                    if (walls[j].pos.y == i)
                    {
                        lineNum++;
                        break;
                    }
                }
            }
            //验证每行是否有满行（验证是否 满行的方法比我想的对比字典的那种方法好）
            for (int i = 1; i <= Game.h - 6 - 2; i++)
            {
                int count = 0;
                for (int j = 0; j < walls.Length; j++)
                {
                    if (walls[j].pos.y == i)
                    {
                        count++;
                    }
                }
                if (count == Game.w / 2 - 2)
                {
                    //满行消除
                    //DeleteLine(i);
                    //满行消除后，上面的方块下移
                    //MoveDown(i);
                    Delete();
                    walls = DeleteShape(i);
                    //Delete();
                    Draw();
                }
            }
        }

        /// <summary>
        /// 满行消除
        /// </summary>
        public Wall[] DeleteShape(int lineNum)
        {
            //把满的那行全部绘制成空格
            for (int i = 2; i < Game.w - 3; i++)
            {
                Console.SetCursorPosition(i, lineNum);
                Console.Write("  ");
            }

            //把上面的方块下移(重置数组，元素减少一行的数量，新元素主要
            //包含两类，第一类是小于linenum的所有元素，第二类是大于linenum的所有元素y坐标-1，重新绘制ChangingWalls即可)
            //1.重置数组
            Wall[] tempWalls = new Wall[walls.Length - (Game.w / 2 - 2)];
            //2.存入元素
            int tempIndexOfTempWalls = 0;
            for (int i = 0; i < walls.Length; i++)
            {
                if (walls[i].pos.y > lineNum)
                {
                    tempWalls[tempIndexOfTempWalls] = new Wall(walls[i].pos.x, walls[i].pos.y);
                    tempIndexOfTempWalls++;
                }
                else if (walls[i].pos.y < lineNum)
                {
                    tempWalls[tempIndexOfTempWalls] = new Wall(walls[i].pos.x, walls[i].pos.y + 1);
                    tempIndexOfTempWalls++;
                }
            }

            //下面这段存入是有问题的，因为只是验证了walls总数减去一行的数量的元素，没有验证所有元素
            //for (int i = 0; i < tempWalls.Length; i++)
            //{
            //    if (walls[i].pos.y > lineNum)
            //    {
            //        tempWalls[i] = new Wall(walls[i].pos.x, walls[i].pos.y);
            //    }
            //    else if(walls[i].pos.y < lineNum)
            //    {
            //        tempWalls[i] = new Wall(walls[i].pos.x, walls[i].pos.y + 1);
            //    }
            //}
            return tempWalls;
        }
       
        /// <summary>
        /// 绘制变化地图
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }

        public void Delete()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Delete();
            }
        }
    }
}
