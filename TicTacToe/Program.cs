using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();
            bool gameOver = false;

            while (!gameOver)
            {
                DrawBoard();
                Console.WriteLine($"Player {currentPlayer}'s turn. Enter the row (0-2):");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the column (0-2):");
                int col = int.Parse(Console.ReadLine());

                if (IsValidMove(row, col))
                {
                    MakeMove(row, col);
                    if (IsGameOver())
                    {
                        DrawBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void DrawBoard()
        {
            Console.WriteLine("---------");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"| {board[row, col]} ");
                }
                Console.WriteLine("|");
                Console.WriteLine("---------");
            }
        }

        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3)
            {
                return false;
            }

            return board[row, col] == ' ';
        }

        static void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
        }

        static bool IsGameOver()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != ' ' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != ' ' && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}