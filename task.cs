using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueCalculating = true;

        while (continueCalculating)
        {
            Console.WriteLine("Введіть розмірність матриці (рядки х стовпці):");
            Console.Write("Рядки: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Стовпці: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = GenerateMatrix(rows, cols);

            Console.WriteLine("Матриця:");
            PrintMatrix(matrix);

            Console.WriteLine("Введіть номер рядка матриці:");
            int selectedRow = int.Parse(Console.ReadLine());

            int rowProduct = Mult_row(matrix, selectedRow);
            Console.WriteLine($"Добуток елементів рядка {selectedRow}: {rowProduct}");

            Console.WriteLine("Продовжити обрахунки? (натисніть будь-яку клавішу, крім 'т')");

            // Перевірка, чи натиснута клавіша 'т'
            if (Console.ReadKey().KeyChar != 'т')
                continueCalculating = false;

            Console.WriteLine(); // Для відступу перед наступною ітерацією
        }
    }

    static int[,] GenerateMatrix(int rows, int cols)
    {
        Random random = new Random();
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(1, 10); // Генеруємо випадкові числа від 1 до 9
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int Mult_row(int[,] matrix, int row)
    {
        int product = 1;
        int cols = matrix.GetLength(1);

        for (int j = 0; j < cols; j++)
        {
            product *= matrix[row, j];
        }

        return product;
    }
}
