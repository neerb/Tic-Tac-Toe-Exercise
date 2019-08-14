using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            int decision = 0;

            while(decision != -1)
            {
                Console.WriteLine("Welcome to Tic-Tac-Toe!");
                Console.WriteLine("0 - Start a new game.");
                Console.WriteLine("-1 - Exit the program.");
                Console.WriteLine("Select a menu option: ");

                decision = Convert.ToInt32(Console.ReadLine());

                switch(decision)
                {
                    case 0:
                        while (!game.checkForWin() && !game.checkForTie())
                        {
                            game.printGameBoard();

                            int x, y;

                            if (game.isXTurn())
                            {
                                Console.WriteLine("X Player, enter your coordinates...");

                                Console.Write("Enter X coordinate: ");
                                x = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Y coordinate: ");
                                y = Convert.ToInt32(Console.ReadLine());

                                while (!game.makeMove(game.isXTurn(), x, y))
                                {
                                    Console.WriteLine("Invalid move: please try again: ");

                                    Console.Write("Enter X coordinate: ");
                                    x = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter Y coordinate: ");
                                    y = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            else
                            {
                                Console.WriteLine("O Player, enter your coordinates (x, y):");

                                Console.Write("Enter X coordinate: ");
                                x = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter Y coordinate: ");
                                y = Convert.ToInt32(Console.ReadLine());

                                while (!game.makeMove(game.isXTurn(), x, y))
                                {
                                    Console.WriteLine("Invalid move: please try again: ");

                                    Console.Write("Enter X coordinate: ");
                                    x = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter Y coordinate: ");
                                    y = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                        }

                        game.printGameBoard();

                        if (game.checkForTie())
                            Console.WriteLine("It's a tie!");
                        
                        if(game.checkForWin())
                        {
                            //Inverted because it defaults to next player
                            if (game.isXTurn())
                                Console.WriteLine("O is the winner!");
                            else
                                Console.WriteLine("X is the winner!");
                        }

                        game.reset();
                        break;
                    case 1:
                        break;

                    default:
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
