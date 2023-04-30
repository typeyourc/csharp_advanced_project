using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// 地图的单个元素类(一块砖)
    /// </summary>
    class Wall : GameObject
    {
        public Wall(int x, int y)
        {
            pos = new Position(x, y);
        }

        public override void Delete()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine("  ");
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■");
        }
    }
    //internal class Wall
    //{
    //}
}
