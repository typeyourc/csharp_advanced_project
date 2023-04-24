using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameScene : ISceneUpdate
    {
        public void Update()
        {
            //以下两行为测试专用
            //Console.SetCursorPosition(0, 0);
            //Console.Write("游戏场景");
            new UnChangingMap().Draw();
            Shape shape = new Shape();
            //启动左右移动线程
            Thread thread = new Thread(shape.MoveLeftOrRight);
            thread.Start();
            thread.IsBackground = true;
            //启动下落线程
            shape.MoveDown();
           
        }
    }
    //internal class GameScene
    //{
    //}
}
