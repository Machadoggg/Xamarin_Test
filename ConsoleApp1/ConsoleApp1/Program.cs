using System;

public class Program
{
    static int[] myArray = new int[] { 1, 2, -1, 1, 0, 1, 2, -1, -1, -2 };

    public static void Main()
    {
        char[,] grid = new char[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                grid[i, j] = 'O';
            }
        }

        int x = 0;
        int y = 0;

        for (int i = 0; i < myArray.Length; i += 2)
        {
            int dx = myArray[i + 1];
            int dy = myArray[i];

            int newX = x + dx;
            int newY = y + dy;

            newX = Math.Max(0, Math.Min(3, newX));
            newY = Math.Max(0, Math.Min(3, newY));

            grid[x, y] = 'O';
            grid[newX, newY] = 'X';

            x = newX;
            y = newY;
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.WriteLine();
        }
    }
}

