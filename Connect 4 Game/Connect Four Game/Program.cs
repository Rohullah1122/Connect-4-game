using System;
using System.Collections.Generic;
using System.Threading;

namespace ConnectFourOOP
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException(string message) : base(message) { }
    }

    class Board
    {
        private char[,] grid;
        public int Rows { get; } = 6;
        public int Cols { get; } = 7;

        public Board()
        {
            grid = new char[Rows, Cols];
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    grid[i, j] = '.';
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(grid[i, j] + " ");
                Console.WriteLine();
            }
            for (int j = 0; j < Cols; j++)
                Console.Write(j + " ");
            Console.WriteLine();
        }

        public bool DropDisc(int col, char symbol)
        {
            try
            {
                if (col < 0 || col >= Cols)
                    throw new OutOfRangeException("Column out of range!");

                for (int i = Rows - 1; i >= 0; i--)
                {
                    if (grid[i, col] == '.')
                    {
                        grid[i, col] = symbol;
                        return true;
                    }
                }

                throw new InvalidOperationException("Column is full!");
            }
            catch (OutOfRangeException ex)
            {
                Console.WriteLine($"❗ Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"❗ Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❗ Unexpected Error: {ex.Message}");
            }

            return false;
        }

        public bool IsFull()
        {
            for (int j = 0; j < Cols; j++)
                if (grid[0, j] == '.')
                    return false;
            return true;
        }

        public bool IsColumnAvailable(int col)
        {
            return grid[0, col] == '.';
        }

        public bool CheckWin(char p)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j <= Cols - 4; j++)
                    if (grid[i, j] == p && grid[i, j + 1] == p && grid[i, j + 2] == p && grid[i, j + 3] == p)
                        return true;

            for (int j = 0; j < Cols; j++)
                for (int i = 0; i <= Rows - 4; i++)
                    if (grid[i, j] == p && grid[i + 1, j] == p && grid[i + 2, j] == p && grid[i + 3, j] == p)
                        return true;

            for (int i = 3; i < Rows; i++)
                for (int j = 0; j <= Cols - 4; j++)
                    if (grid[i, j] == p && grid[i - 1, j + 1] == p && grid[i - 2, j + 2] == p && grid[i - 3, j + 3] == p)
                        return true;

            for (int i = 0; i <= Rows - 4; i++)
                for (int j = 0; j <= Cols - 4; j++)
                    if (grid[i, j] == p && grid[i + 1, j + 1] == p && grid[i + 2, j + 2] == p && grid[i + 3, j + 3] == p)
                        return true;

            return false;
        }
    }

    class Player
    {
        public string Name { get; }
        public char Symbol { get; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
