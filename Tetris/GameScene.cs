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
        }
    }
    //internal class GameScene
    //{
    //}
}
