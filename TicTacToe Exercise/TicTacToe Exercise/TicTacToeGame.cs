using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Exercise
{
    class TicTacToeGame
    {
        private int sizeSquared = 3;
        private char[,] gameBoard;
        private bool xTurn = true;

        public TicTacToeGame()
        {
            gameBoard = new char[sizeSquared, sizeSquared];

            for(int x = 0; x < sizeSquared; x++)
            {
                for(int y = 0; y < sizeSquared; y++)
                {
                    gameBoard[x, y] = ' ';
                }
            }
        }

        public bool isXTurn()
        {
            return xTurn;
        }

        public bool makeMove(bool isX, int x, int y)
        {
            bool returnVal = true;

            if (gameBoard[x, y] == ' ')
            {
                if (isX)
                    gameBoard[x, y] = 'X';
                else
                    gameBoard[x, y] = 'O';

                xTurn = !xTurn;
            }
            else
                returnVal = false;

            return returnVal;
        }

        public bool checkForWin()
        {
            bool returnVal = false;

            //Check for horizontal wins
            for(int y = 0; y < sizeSquared; y++)
            {
                if (gameBoard[0, y] == gameBoard[1, y] && gameBoard[0, y] == gameBoard[2, y] && gameBoard[0, y] != ' ')
                    returnVal = true;
            }

            //Check for vertical wins
            for (int x = 0; x < sizeSquared; x++)
            {
                if (gameBoard[x, 0] == gameBoard[x, 1] && gameBoard[x, 0] == gameBoard[x, 2] && gameBoard[x, 0] != ' ')
                    returnVal = true;
            }

            //Diagonal negative wins
            if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[0, 0] == gameBoard[2, 2] && gameBoard[0, 0] != ' ')
                returnVal = true;

            //Diagonal positive wins
            if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[0, 2] == gameBoard[2, 0] && gameBoard[0, 2] != ' ')
                returnVal = true;

            return returnVal;
        }

        public bool checkForTie()
        {
            for(int y = 0; y < sizeSquared; y++)
            {
                for(int x = 0; x < sizeSquared; x++)
                {
                    if(gameBoard[x, y] == ' ')
                        return false;
                }
            }

            return true;
        }

        public void reset()
        {
            for (int x = 0; x < sizeSquared; x++)
            {
                for (int y = 0; y < sizeSquared; y++)
                {
                    gameBoard[x, y] = ' ';
                }
            }
        }


        public void printGameBoard()
        {
            Console.WriteLine("Current Game Board:");
            Console.WriteLine("   -0---1---2-X");
            for(int y = 0; y < sizeSquared; y++)
            {
                Console.Write(y);

                for(int x = 0; x < sizeSquared; x++)
                {
                    Console.Write(" | ");
                    Console.Write(gameBoard[x, y]);
                }
                Console.Write(" |");

                Console.WriteLine();

                if(y != sizeSquared - 1)
                    Console.WriteLine("  |-----------|");
                else
                    Console.WriteLine("Y  -----------");
            }

            Console.WriteLine();
        }
    }
}
