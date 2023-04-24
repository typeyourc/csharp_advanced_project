using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// 形状的单个元素类型
    /// </summary>
    enum E_CubeType
    {
        Type1,
        Type2,
        Type3,
        Type4,
        Type5,
        Type6,
    }
    class Cube : GameObject
    {
        public E_CubeType cubeType;
        public Cube(int x, int y)
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
            switch (cubeType)
            {
                case E_CubeType.Type1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case E_CubeType.Type2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case E_CubeType.Type3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_CubeType.Type4:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case E_CubeType.Type5:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case E_CubeType.Type6:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine("■");
        }
    }
}
