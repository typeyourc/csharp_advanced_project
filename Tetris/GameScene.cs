using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameScene : ISceneUpdate
    {
        Shape shape = new Shape();
        UnChangingMap unChangingMap = new UnChangingMap();

        public GameScene()
        {
            unChangingMap.Draw();
        }

        public void Update()
        {
            //以下两行为测试专用
            //Console.SetCursorPosition(0, 0);
            //Console.Write("游戏场景");

            //Thread thread = new Thread(unChangingMap.Draw);
            //thread.Start();
            //thread.Join();
            //thread = null;
            //new UnChangingMap().Draw();
            //Shape shape = new Shape();



            Thread thread1 = new Thread(shape.MoveDown);
            thread1.Start();
            ////thread1.IsBackground = true;

            //启动左右移动线程
            Thread thread2 = new Thread(shape.MoveLeftOrRight);
            thread2.Start();
            //thread2.IsBackground = true;


            //启动下落线程
            //shape.MoveDown();

        }
    }
    //internal class GameScene
    //{
    //}
}
