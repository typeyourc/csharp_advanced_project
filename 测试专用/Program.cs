﻿namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试专用");
            //已经实现形状1下滑

            //bug列表
            //(done)1.形状移动的时候没有擦除原来的方块
            //(done)2.为什么Shape里面的MoveDown里的不能加锁，需要弄明白线程加锁的原则，只给辅线程加就可以了吗
            //(done)3.左右移动的时候好像卡了一下：测了一下，是因为启动了形状变状态线程引起的
            //(done)4.切换状态的时候，左箭头第一下变了状态，第二下形状左移了一下却没有改变状态(应该是继续改变状态)
            //(暂时先搁置，时而有，时而不见)5.左右移动不能连续移动，每次都是点了左移，下移一行，才能第二次左移。或者说感觉整体平移不太丝滑。

            //待实现功能
            //(done，已经实现，但是加速有点不丝滑，后续可以优化)1.加速下移
            //(done)2.判断是否碰到底部，并且到达底部停止下落(done)，改变形状颜色(done)，启动下一个形状下落(done)
            //(done，不知为啥修改了几次就修改好了，应该是GameScene类中，把委托放到构造函数中编号好的)2.1.当下有个问题，第一个形状落到底部后，第二个形状一下就会在draw处报错说坐标-1的问题，
            //测试发现程序在执行了Init后，会直接跳到委托去执行，而没有按照预想的再次重新往下滑动
            //分析原因，可能是程序再次满足了委托触发的条件？？？
            //测试发现初始化之后，shape坐标没有改变，即离开初始化函数坐标（测试发现到委托函数退出，值才生效，也就是说没有这个错误，应该是测试软件vs延时显示造成的）

            //(done)3.判断是否碰到左右边界
            //(done)4.判断是否碰到其他方块(即是否碰到变化地图)
            //(核心部分done)4.1有个bug，左移的时候，下落的方块如果左移之后某个元素的位置跟活动的地图某个元素重叠，会图形叠加（初步分析，左移动前需要判断下一个位置是否跟活动城墙的任意元素重叠，如果重叠，不能左移
            //;变状态的时候可能有类似bug（搁置，不易触发，解决思路，在变形之前先判断变形之后是否有元素跟活动城墙冲突或者跟固定城墙冲突即可解决类似问题））
            //(done)5.判断是否有满的某行（思路：walls的高度，验证各个高度下是否有满行）
            //(done)6.消除满的某行
            //7.撞到顶部游戏结束
            //8.补充除了形状1以外的其他形状
            //9.程序优化
            //10.有点疑问，感觉shape类中的MoveDown()方法的Thread.Sleep(2000);没有起作用
        }
    }
}