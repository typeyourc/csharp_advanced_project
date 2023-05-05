﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// 场景类型枚举
    /// </summary>
    enum E_SceneType
    {
        /// <summary>
        /// 开始场景
        /// </summary>
        Begin,
        /// <summary>
        /// 游戏场景
        /// </summary>
        Game,
        /// <summary>
        /// 结束场景
        /// </summary>
        End,
    }

    class Game
    {
        //游戏窗口宽高
        public const int w = 50;
        public const int h = 36;
        //当前选中的场景
        public static ISceneUpdate nowScene;

        //public Shape shape;
        //public UnChangingWalls unChangingWalls;
        //public ChangingWalls changingWalls;

        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);

            //游戏一开始，进入开始场景
            ChangeScene(E_SceneType.Begin);
        }

        //游戏开始的方法
        public void Start()
        {
            //游戏主循环 主要负责 游戏场景逻辑的更新
            while (true)
            {
                //判断当前游戏场景不为空 就更新
                if (nowScene != null)
                {
                    nowScene.Update();

                    //测试用
                    //int i = 1;
                    //i++;  
                }
            }
        }

        public static void ChangeScene(E_SceneType type)
        {
            //切场景之前 应该把上一个场景的绘制内容擦掉
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }
        }
    }
    //internal class Game
    //{
    //}
}
