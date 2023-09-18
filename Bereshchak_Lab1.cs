namespace Lab_1
{ 
    class Bereshchak_Lab1
    {
        public static int[,] array;
        public static int[,] matrix;
        public static int N;
        public static int M;
        public static int Scalar1 = 0;
        public static int Scalar2 = 0;
        public static int[,] CreateArray()
        {
            Console.WriteLine("Enter n: ");
            N = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter m: ");
            M = int.Parse(Console.ReadLine());
            array = new int[N, M];
            
            if (N % 2 == 0 && M % 2 != 0)
            {
                Random random = new Random();

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array[i, j] = random.Next(0, 5);
                        Console.Write(array[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            return array;
        }

        static void Main()
        {
            matrix = CreateArray();
            
            Thread thread1 = new Thread(ThreadFunction1); 	
            thread1.Start(); 
            
            Thread thread2 = new Thread(ThreadFunction2); 
            thread2.Start();

            while (thread1.IsAlive || thread2.IsAlive)
            {
                Thread.Sleep(50);
            }
            
            Console.WriteLine($"{Scalar1 + Scalar2}");
        }

        public static void ThreadFunction1()
        {
            int x = 0;
            
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    x = array[i, j] * array[i + 1, j];
                    Scalar1 += x;
                }
            }
        }

        static void ThreadFunction2()
        {
            int z = 0;
            for (int i = 1; i < N - 1; i++)
            {
                for (int j = i + 1; j < M; j++)
                {
                    z = matrix[i, j] * matrix[i + 1, j];
                    Scalar2 += z;
                }
            }
        }
    }
}