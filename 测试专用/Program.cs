namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试专用");
            //已经实现形状1下滑

            //bug列表
            //(done)1.形状移动的时候没有擦除原来的方块
            //2.为什么Shape里面的MoveDown里的不能加锁，需要弄明白线程加锁的原则，只给辅线程加就可以了吗
            //3.左右移动的时候好像卡了一下：测了一下，是因为启动了形状变状态线程引起的
            //4.切换状态的时候，左箭头第一下变了状态，第二下形状左移了一下却没有改变状态(应该是继续改变状态)
        }
    }
}