using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// 形状的形态
    /// </summary>
    enum E_ShapStatus
    {
        Status1,
        Status2,
        Status3,
        Status4,
    }
    class Shape : IDraw
    {
        public Cube[] cubes;
        public E_ShapStatus status;
        public E_CubeType shapType;
        private static readonly object objLock = new object();

        public Shape()
        {
            cubes = new Cube[4];
            //cubes[0] = new Cube(0,0);
            //cubes[1] = new Cube(0, 0);
            //cubes[2] = new Cube(0, 0);
            //cubes[3] = new Cube(0, 0);
            //暂且先按照1个形状来测试一下，如果OK的话，补上所有形状数据
            shapType = (E_CubeType)new Random().Next(0, 1);
            status = (E_ShapStatus)new Random().Next(0, 1);
            #region 形状1
            if (shapType == E_CubeType.Type1)
            {
                if (status == E_ShapStatus.Status1)
                {
                    //cubes[0].pos.x = (Game.w) / 2 - 1;
                    //cubes[0].pos.y = 0;
                    cubes[0] = new Cube((Game.w) / 2 - 1, 0);

                    //cubes[1].pos.x = cubes[0].pos.x + 2;
                    //cubes[1].pos.y = cubes[0].pos.y;
                    cubes[1] = new Cube(cubes[0].pos.x + 2, cubes[0].pos.y);
                    //cubes[2].pos.x = cubes[0].pos.x + 4;
                    //cubes[2].pos.y = cubes[0].pos.y;
                    cubes[2] = new Cube(cubes[0].pos.x + 4, cubes[0].pos.y);
                    //cubes[3].pos.x = cubes[0].pos.x + 2;
                    //cubes[3].pos.y = cubes[0].pos.y - 1;
                    cubes[3] = new Cube(cubes[0].pos.x + 2, cubes[0].pos.y - 1);
                }
                else if (status == E_ShapStatus.Status2)
                {
                    cubes[0].pos.x = (Game.w) / 2 - 1;
                    cubes[0].pos.y = 0;

                    cubes[1].pos.x = cubes[0].pos.x;
                    cubes[1].pos.y = cubes[0].pos.y - 1;
                    cubes[2].pos.x = cubes[0].pos.x;
                    cubes[2].pos.y = cubes[0].pos.y - 2;
                    cubes[3].pos.x = cubes[0].pos.x - 2;
                    cubes[3].pos.y = cubes[0].pos.y - 1;
                }
                else if (status == E_ShapStatus.Status3)
                {
                    cubes[0].pos.x = (Game.w) / 2 - 1;
                    cubes[0].pos.y = -1;

                    cubes[1].pos.x = cubes[0].pos.x - 2;
                    cubes[1].pos.y = cubes[0].pos.y;
                    cubes[2].pos.x = cubes[0].pos.x - 4;
                    cubes[2].pos.y = cubes[0].pos.y;
                    cubes[3].pos.x = cubes[0].pos.x - 2;
                    cubes[3].pos.y = cubes[0].pos.y + 1;
                }
                else if (status == E_ShapStatus.Status4)
                {
                    cubes[0].pos.x = (Game.w) / 2 - 1;
                    cubes[0].pos.y = -2;

                    cubes[1].pos.x = cubes[0].pos.x;
                    cubes[1].pos.y = cubes[0].pos.y + 1;
                    cubes[2].pos.x = cubes[0].pos.x;
                    cubes[2].pos.y = cubes[0].pos.y + 2;
                    cubes[3].pos.x = cubes[0].pos.x + 2;
                    cubes[3].pos.y = cubes[0].pos.y + 1;
                }
            }
            #endregion
            #region 形状2
            //else if (shapType == E_CubeType.Type2)
            //{
            //    if (status == E_ShapStatus.Status1)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x + 2;
            //        cubes[1].pos.y = cubes[0].pos.y;
            //        cubes[2].pos.x = cubes[0].pos.x + 2;
            //        cubes[2].pos.y = cubes[0].pos.y + 1;
            //        cubes[3].pos.x = cubes[0].pos.x + 4;
            //        cubes[3].pos.y = cubes[0].pos.y + 1;
            //    }
            //    else if (status == E_ShapStatus.Status2)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x;
            //        cubes[1].pos.y = cubes[0].pos.y - 1;
            //        cubes[2].pos.x = cubes[0].pos.x + 2;
            //        cubes[2].pos.y = cubes[0].pos.y - 1;
            //        cubes[3].pos.x = cubes[0].pos.x + 2;
            //        cubes[3].pos.y = cubes[0].pos.y - 2;
            //    }
            //    else if (status == E_ShapStatus.Status3)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x + 2;
            //        cubes[1].pos.y = cubes[0].pos.y;
            //        cubes[2].pos.x = cubes[0].pos.x + 2;
            //        cubes[2].pos.y = cubes[0].pos.y + 1;
            //        cubes[3].pos.x = cubes[0].pos.x + 4;
            //        cubes[3].pos.y = cubes[0].pos.y + 1;
            //    }
            //    else if (status == E_ShapStatus.Status4)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x;
            //        cubes[1].pos.y = cubes[0].pos.y - 1;
            //        cubes[2].pos.x = cubes[0].pos.x + 2;
            //        cubes[2].pos.y = cubes[0].pos.y - 1;
            //        cubes[3].pos.x = cubes[0].pos.x + 2;
            //        cubes[3].pos.y = cubes[0].pos.y - 2;
            //    }
            //}
            #endregion
            #region 形状3
            //else if (shapType == E_CubeType.Type3)
            //{
            //    if (status == E_ShapStatus.Status1)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x;
            //        cubes[1].pos.y = cubes[0].pos.y + 1;
            //        cubes[2].pos.x = cubes[0].pos.x;
            //        cubes[2].pos.y = cubes[0].pos.y + 2;
            //        cubes[3].pos.x = cubes[0].pos.x;
            //        cubes[3].pos.y = cubes[0].pos.y + 3;
            //    }
            //    else if (status == E_ShapStatus.Status2)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x + 2;
            //        cubes[1].pos.y = cubes[0].pos.y;
            //        cubes[2].pos.x = cubes[0].pos.x + 4;
            //        cubes[2].pos.y = cubes[0].pos.y;
            //        cubes[3].pos.x = cubes[0].pos.x + 6;
            //        cubes[3].pos.y = cubes[0].pos.y;
            //    }
            //    else if (status == E_ShapStatus.Status3)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x;
            //        cubes[1].pos.y = cubes[0].pos.y + 1;
            //        cubes[2].pos.x = cubes[0].pos.x;
            //        cubes[2].pos.y = cubes[0].pos.y + 2;
            //        cubes[3].pos.x = cubes[0].pos.x;
            //        cubes[3].pos.y = cubes[0].pos.y + 3;
            //    }
            //    else if (status == E_ShapStatus.Status4)
            //    {
            //        cubes[1].pos.x = cubes[0].pos.x + 2;
            //        cubes[1].pos.y = cubes[0].pos.y;
            //        cubes[2].pos.x = cubes[0].pos.x + 4;
            //        cubes[2].pos.y = cubes[0].pos.y;
            //        cubes[3].pos.x = cubes[0].pos.x + 6;
            //        cubes[3].pos.y = cubes[0].pos.y;
            //    }
            //}
            #endregion
        }
        public void Draw()
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                if (cubes[i].pos.y >=0 )
                    cubes[i].Draw();
            }
        }
        public void Delete()
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                if (cubes[i].pos.y >= 0)
                    cubes[i].Delete();
            }
        }
        public void MoveDown()
        {
            while (true)
            {
                //为什么这里不用加锁，线程加锁的规则是什么
                lock (objLock)
                {
                    Draw();
                    //if (Console.KeyAvailable)
                    //{
                    //    switch (Console.ReadKey(true).Key)
                    //    {
                    //        case ConsoleKey.S:
                    //            //过200ms擦除
                    //            Thread.Sleep(300);
                    //            Delete();
                    //            break;
                    //    }
                    //}
                    //else
                    //{
                        //过700ms擦除
                        Thread.Sleep(700);
                        Delete();
                    //}
 
                    for (int i = 0; i < cubes.Length; i++)
                        cubes[i].pos.y += 1;
                }
                Thread.Sleep(2000);
            }
        }
        public void FastMoveDown()
        {
            Draw();
            Thread.Sleep(100);
            Delete();
            for (int i = 0; i < cubes.Length; i++)
                cubes[i].pos.y += 1;
        }
        public void MoveLeftOrRight()
        {
            //检测输入
            while (true)
            {
                lock (objLock)
                {
                    E_ShapStatus cstatus = status;

                if (Console.KeyAvailable)
                {
                    //lock (objLock)
                    //{
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.S:
                                Delete();
                                FastMoveDown();
                                break;
                            case ConsoleKey.A:
                                Delete();
                                for (int i = 0; i < cubes.Length; i++)
                                    cubes[i].pos.x -= 2;
                                Draw();
                                break;
                            case ConsoleKey.D:
                                Delete();
                                for (int i = 0; i < cubes.Length; i++)
                                    cubes[i].pos.x += 2;
                                Draw();
                                break;
                            case ConsoleKey.LeftArrow:
                                Delete();
                                if (status == E_ShapStatus.Status1)
                                {
                                    cstatus = E_ShapStatus.Status4;
                                }
                                else if (status == E_ShapStatus.Status2)
                                {
                                    cstatus = E_ShapStatus.Status1;
                                }
                                else if (status == E_ShapStatus.Status3)
                                {
                                    cstatus = E_ShapStatus.Status2;
                                }
                                else if (status == E_ShapStatus.Status4)
                                {
                                    cstatus = E_ShapStatus.Status3;
                                }
                                ChangeShapePositon(cstatus);
                                Draw();
                                break;
                            case ConsoleKey.RightArrow:
                                Delete();
                                if (status == E_ShapStatus.Status1)
                                {
                                    cstatus = E_ShapStatus.Status2;
                                }
                                else if (status == E_ShapStatus.Status2)
                                {
                                    cstatus = E_ShapStatus.Status3;
                                }
                                else if (status == E_ShapStatus.Status3)
                                {
                                    cstatus = E_ShapStatus.Status4;
                                }
                                else if (status == E_ShapStatus.Status4)
                                {
                                    cstatus = E_ShapStatus.Status1;
                                }
                                ChangeShapePositon(cstatus);
                                Draw();
                                break;
                        }
                        //Draw();
                    //}
                    //Thread.Sleep(500);
                }
            }
                Thread.Sleep(500);
            }
        }
        //public void ChangeShapeStatus()
        //{
        //    //检测输入
        //    while (true)
        //    {
        //        lock (this)
        //        {
        //            switch (Console.ReadKey(true).Key)
        //            {
        //                case ConsoleKey.LeftArrow:
        //                    Delete();
        //                    if (status == E_ShapStatus.Status1)
        //                    {
        //                        status = E_ShapStatus.Status4;
        //                    }
        //                    else if (status == E_ShapStatus.Status2)
        //                    {
        //                        status = E_ShapStatus.Status1;
        //                    }
        //                    else if (status == E_ShapStatus.Status3)
        //                    {
        //                        status = E_ShapStatus.Status2;
        //                    }
        //                    else if (status == E_ShapStatus.Status4)
        //                    {
        //                        status = E_ShapStatus.Status3;
        //                    }
        //                    break;
        //                case ConsoleKey.RightArrow:
        //                    Delete();
        //                    if (status == E_ShapStatus.Status1)
        //                    {
        //                        status = E_ShapStatus.Status2;
        //                    }
        //                    else if (status == E_ShapStatus.Status2)
        //                    {
        //                        status = E_ShapStatus.Status3;
        //                    }
        //                    else if (status == E_ShapStatus.Status3)
        //                    {
        //                        status = E_ShapStatus.Status4;
        //                    }
        //                    else if (status == E_ShapStatus.Status4)
        //                    {
        //                        status = E_ShapStatus.Status1;
        //                    }
        //                    break;
        //            }
        //            Draw();
        //        }
        //    }
        //}

        //补充一个，形状的坐标调整方法，传入的参数是形状(形状类型，形状状态，以及形状)
        //在其方法内部完成坐标的调整，由于形状是个引用类型，无需返回值
        public void ChangeShapePositon(E_ShapStatus cstatus)
        {
            //测试一下，去掉这个lock
            //lock (objLock)
            //{
                #region 形状1
                if (shapType == E_CubeType.Type1)
                {
                    #region 原先是状态1，转成状态4或者状态2
                    if (status == E_ShapStatus.Status1 && cstatus == E_ShapStatus.Status4)
                    {
                        cubes[0].pos.x = cubes[0].pos.x;
                        cubes[0].pos.y = cubes[0].pos.y - 2;

                        cubes[1].pos.x = cubes[0].pos.x;
                        cubes[1].pos.y = cubes[0].pos.y + 1;
                        cubes[2].pos.x = cubes[0].pos.x;
                        cubes[2].pos.y = cubes[0].pos.y + 2;
                        cubes[3].pos.x = cubes[0].pos.x + 2;
                        cubes[3].pos.y = cubes[0].pos.y + 1;

                        status = E_ShapStatus.Status4;
                    }
                    else if (status == E_ShapStatus.Status1 && cstatus == E_ShapStatus.Status2)
                    {
                        cubes[0].pos.x = cubes[0].pos.x + 4;
                        cubes[0].pos.y = cubes[0].pos.y;

                        cubes[1].pos.x = cubes[0].pos.x;
                        cubes[1].pos.y = cubes[0].pos.y - 1;
                        cubes[2].pos.x = cubes[0].pos.x;
                        cubes[2].pos.y = cubes[0].pos.y - 2;
                        cubes[3].pos.x = cubes[0].pos.x - 2;
                        cubes[3].pos.y = cubes[0].pos.y - 1;

                        status = E_ShapStatus.Status2;
                    }
                    #endregion
                    #region 原先是状态2，转成状态1或者状态3
                    else if (status == E_ShapStatus.Status2 && cstatus == E_ShapStatus.Status1)
                    {
                        cubes[0].pos.x = cubes[0].pos.x - 4;
                        cubes[0].pos.y = cubes[0].pos.y;

                        cubes[1].pos.x = cubes[0].pos.x + 2;
                        cubes[1].pos.y = cubes[0].pos.y;
                        cubes[2].pos.x = cubes[0].pos.x + 4;
                        cubes[2].pos.y = cubes[0].pos.y;
                        cubes[3].pos.x = cubes[0].pos.x + 2;
                        cubes[3].pos.y = cubes[0].pos.y - 1;

                        status = E_ShapStatus.Status1;
                    }
                    else if (status == E_ShapStatus.Status2 && cstatus == E_ShapStatus.Status3)
                    {
                        cubes[0].pos.x = cubes[0].pos.x;
                        cubes[0].pos.y = cubes[0].pos.y - 2;

                        cubes[1].pos.x = cubes[0].pos.x - 2;
                        cubes[1].pos.y = cubes[0].pos.y;
                        cubes[2].pos.x = cubes[0].pos.x - 4;
                        cubes[2].pos.y = cubes[0].pos.y;
                        cubes[3].pos.x = cubes[0].pos.x - 2;
                        cubes[3].pos.y = cubes[0].pos.y + 1;

                        status = E_ShapStatus.Status3;
                    }
                    #endregion
                    #region 原先是状态3，转成状态2或者状态4
                    else if (status == E_ShapStatus.Status3 && cstatus == E_ShapStatus.Status2)
                    {
                        cubes[0].pos.x = cubes[0].pos.x;
                        cubes[0].pos.y = cubes[0].pos.y + 2;

                        cubes[1].pos.x = cubes[0].pos.x;
                        cubes[1].pos.y = cubes[0].pos.y - 1;
                        cubes[2].pos.x = cubes[0].pos.x;
                        cubes[2].pos.y = cubes[0].pos.y - 2;
                        cubes[3].pos.x = cubes[0].pos.x - 2;
                        cubes[3].pos.y = cubes[0].pos.y - 1;

                        status = E_ShapStatus.Status2;
                    }
                    else if (status == E_ShapStatus.Status3 && cstatus == E_ShapStatus.Status4)
                    {
                        cubes[0].pos.x = cubes[0].pos.x - 4;
                        cubes[0].pos.y = cubes[0].pos.y;

                        cubes[1].pos.x = cubes[0].pos.x;
                        cubes[1].pos.y = cubes[0].pos.y + 1;
                        cubes[2].pos.x = cubes[0].pos.x;
                        cubes[2].pos.y = cubes[0].pos.y + 2;
                        cubes[3].pos.x = cubes[0].pos.x + 2;
                        cubes[3].pos.y = cubes[0].pos.y + 1;

                        status = E_ShapStatus.Status4;
                    }
                    #endregion
                    #region 原先是状态4，转成状态3或者状态1
                    else if (status == E_ShapStatus.Status4 && cstatus == E_ShapStatus.Status3)
                    {
                        cubes[0].pos.x = cubes[0].pos.x + 4;
                        cubes[0].pos.y = cubes[0].pos.y;

                        cubes[1].pos.x = cubes[0].pos.x - 2;
                        cubes[1].pos.y = cubes[0].pos.y;
                        cubes[2].pos.x = cubes[0].pos.x -4;
                        cubes[2].pos.y = cubes[0].pos.y;
                        cubes[3].pos.x = cubes[0].pos.x - 2;
                        cubes[3].pos.y = cubes[0].pos.y + 1;

                        status = E_ShapStatus.Status3;
                    }
                    else if (status == E_ShapStatus.Status4 && cstatus == E_ShapStatus.Status1)
                    {
                        cubes[0].pos.x = cubes[0].pos.x;
                        cubes[0].pos.y = cubes[0].pos.y + 2;

                        cubes[1].pos.x = cubes[0].pos.x + 2;
                        cubes[1].pos.y = cubes[0].pos.y;
                        cubes[2].pos.x = cubes[0].pos.x + 4;
                        cubes[2].pos.y = cubes[0].pos.y;
                        cubes[3].pos.x = cubes[0].pos.x + 2;
                        cubes[3].pos.y = cubes[0].pos.y - 1;

                        status = E_ShapStatus.Status1;
                    }
                    #endregion
                }
                #endregion
            //}
        }
    }
}
