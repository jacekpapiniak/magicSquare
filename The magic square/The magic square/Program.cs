using System;
using System.Collections.Generic;

namespace The_magic_square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Hello in the magic square algorithm!");
            Console.WriteLine("Please specify the n value:");
            n = Convert.ToInt32(Console.ReadLine());
           
            DrawSquare(n);
        }

        private static void DrawSquare(int n)
        {
            if(n > 0)
            {
                List<List<int>> magicSquare = new List<List<int>>();
                InitialiseMagicSquare(n, magicSquare);

                int row = n / 2;
                int column = n - 1;
                PopulateSquare(ref magicSquare, row, column, 1, n);
            }
            else
            {
                Console.WriteLine("No magic square to being drawn");
            }
        }

        private static void InitialiseMagicSquare(int n, List<List<int>> magicSquare)
        {
            for (int i = 0; i < n; i++)
            {
                var col = new List<int>();
                for (int colVal = 0; colVal < n; colVal++)
                {
                    col.Add(0);
                }

                magicSquare.Add(col);
            }
        }

        private static void PopulateSquare(ref List<List<int>> magicSquare, int row, int column, int value, int n)
        {
            int maxNo = n * n;
            EvaluateRowXColumn(ref row, ref column, n);

            if (magicSquare[row][column] != 0)
            {
                row = row + 1;
                column = column - 2;               
            }

            EvaluateRowXColumn(ref row, ref column, n);

            if (magicSquare[row][column] == 0)
            {
                magicSquare[row][column] = value;
                if(value < maxNo)
                {
                    PopulateSquare(ref magicSquare, row - 1, column + 1, ++value, n);
                }
                else
                {
                    foreach (var r in magicSquare) 
                    {
                        string values = string.Empty;
                        foreach (var c in r)
                        {
                            values += c + " ";
                        }
                        Console.WriteLine(values);
                    }
                }
            }
        }

        private static void EvaluateRowXColumn(ref int row, ref int column, int n)
        {
            if (row == -1 && column == n)
            {
                row = 0;
                column = n - 2;
            }

            if (row == -1)
            {
                row = n - 1;
            }

            if (column == n)
            {
                column = 0;
            }
        }
    }
}
