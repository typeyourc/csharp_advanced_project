using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ChangingWalls
    {
        public Wall[] walls;
        //私有静态实例
        public static ChangingWalls instanceOfChangingWalls = new ChangingWalls();
        //构造函数私有化
        private ChangingWalls() 
        {
            walls = new Wall[Shape.InstanceOfShape.cubes.Length];
        }
        //公共静态属性
        public static ChangingWalls InstanceOfChangingWalls
        {
            get
            {
                return instanceOfChangingWalls;
            }
        }

        public void AddShape()
        {
            for (int i = 0; i < Shape.InstanceOfShape.cubes.Length; i++)
            {
                walls[i] = new Wall(Shape.InstanceOfShape.cubes[i].pos.x, Shape.InstanceOfShape.cubes[i].pos.y);

                //如果写成下面这样会有no instance报错，因为walls里面的元素需要实例化
                //walls[i].pos.x = Shape.InstanceOfShape.cubes[i].pos.x;
                //walls[i].pos.y = Shape.InstanceOfShape.cubes[i].pos.y;
            }
            Draw();
            Shape.InstanceOfShape.ShapeInit();
        }
        public void DeleteShape()
        {

        }
        public void Draw()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }   
    }
}
