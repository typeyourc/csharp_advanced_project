using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameScene : ISceneUpdate
    {
        Shape shape = Shape.instanceOfShape;
        UnChangingMap unChangingMap = new UnChangingMap();
        ChangingWalls changingWalls = ChangingWalls.InstanceOfChangingWalls;
        static public bool isGameOver = false;

        public GameScene()
        {
            shape = Shape.instanceOfShape;
            unChangingMap = new UnChangingMap();
            changingWalls = ChangingWalls.InstanceOfChangingWalls;
            isGameOver = false;

            changingWalls.ReseChangingtWalls();
            shape.ResetShape();

            unChangingMap.Draw();
            shape.afterTouchDoSomethig += changingWalls.AddShape;
            shape.afterTouchDoSomethig += changingWalls.isFullLine;
        }

        public void Update()
        {
            //shape.touchBottomDoSomethig += changingWalls.AddShape;
            //shape.touchBottomDoSomethig += changingWalls.DeleteShape;
            //shape.touchBottomDoSomethig += shape.ShapeInit;
            //shape.touchBottomDoSomethig += shape.MoveDown;
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

            //测试发现这两句不能加
            //thread1.Join();
            //thread2.Join();

            if (isGameOver == true)
            {
                thread1 = null;
                thread2 = null;
                //isGameOver = false;
                //changingWalls.walls = null;
                Game.nowScene = null;
                Game.ChangeScene(E_SceneType.End);
            }

            //启动下落线程
            //shape.MoveDown();
        }
    }
    //internal class GameScene
    //{
    //}
}
