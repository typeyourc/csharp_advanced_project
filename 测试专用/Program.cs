namespace 测试专用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试专用");
            //已经实现形状1下滑

            //bug列表
            //1.没有擦除原来的方块
            //2.为什么Shape里面的MoveDown里的不能加锁，需要弄明白线程加锁的原则，只给辅线程加就可以了吗
        }
    }
}