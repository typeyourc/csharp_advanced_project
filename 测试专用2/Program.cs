namespace 测试专用2
{
    internal class Program
    {
        static int a = 0;
        static int b = 0;
        private static object o = new object();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            Thread t1 = new Thread(A);
            Thread t2 = new Thread(B);
            t1.Start();
            t2.Start();
        }
        private static void A()
        {
            Console.WriteLine("A非lock区域1测试");
            lock (o)
            {
                a = a + 2;
                Console.WriteLine("我是A方法，a=" + a);
                Thread.Sleep(5000);
                b = b + 2;
                Console.WriteLine("我是A方法，b=" + b);
            }
            //Thread.Sleep(5000);
            Console.WriteLine("A非lock区域2测试");
        }
        private static void B()
        {
            Console.WriteLine("B非lock区域1测试");
            lock (o)
            {
                b++;
                Console.WriteLine("我是B方法，b=" + b);
                Thread.Sleep(1000);
                a++;
                Console.WriteLine("我是B方法，a=" + a);
            }
            //Thread.Sleep(5000);
            Console.WriteLine("B非lock区域2测试");
        }

    }
}