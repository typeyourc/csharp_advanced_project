namespace 测试专用2
{
    internal class Program
    {
        public void Update()
        {
            Thread thread1 = new Thread(shape.MoveDown);
            thread1.Start();
  
            Thread thread2 = new Thread(shape.MoveLeftOrRight);
            thread2.Start();
 

            if (isGameOver == true)
            {
                //thread1.Join();
                //thread2.Join();
                thread1 = null;
                thread2 = null;
                //isGameOver = false;
                //changingWalls.walls = null;
                Thread.Sleep(1000);
                Game.nowScene = null;
                Game.ChangeScene(E_SceneType.End);

                我举个例子：
                while ()
                {
                    Update();
                    int++;
                }
            }
        }
    }
}