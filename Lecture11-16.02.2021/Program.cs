using System;
using System.Threading.Tasks;
using System.Threading;

namespace Lecture12_16._02._2021
{
    class Program
    {

        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origRow + x, origCol + y);
                Console.WriteLine(s);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                string t = ex.Message.ToString();
            }
        }

        static void Main(string[] args)
        {
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            // 88 
            //Task startTask = new Task(ShowMatrix);
            //startTask.Start();


            Parallel.Invoke(MatrixLogic);

        }
        static void MatrixLogic()
        {
            while (true)
            {
                string textOut = "1234567890-=!@#$%^&*()_+QWERTYUIOP}{ASDFGHJKL:ZXCVBNM<>?qwertyuiop][asdfghjkl;zxcvbnm,./";
                Random rand = new Random();
                int posX = rand.Next(0, 103); // Size of terminal X 
                int posY = rand.Next(0, 30); // Size of terminal Y 
                int size = rand.Next(5, 10); // Size of Array
                int[] joins = new int[] { -5, -10, 5, 10 }; // difference btw ROWS
                int joinIndex = rand.Next(0, 3);
                if (joins[joinIndex] + posX >= 0)
                {
                    posX += joins[joinIndex];
                }
                int index;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                for (int i = 0; i < size - 2; i++)
                {
                    index = rand.Next(0, 87);
                    Console.CursorVisible = false;
                    WriteAt(textOut[index].ToString(), posX, posY + i);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                index = rand.Next(0, 87);
                WriteAt(textOut[index].ToString(), posX, posY + size - 1);
                Console.ForegroundColor = ConsoleColor.White;
                index = rand.Next(0, 87);
                WriteAt(textOut[index].ToString(), posX, posY + size);
                origCol = Console.CursorLeft;
                Thread.Sleep(5);
            }
        }
    }
}
