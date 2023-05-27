using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Controllers;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;
using TicTacToeGame.Strategies.WinningStrategies;

namespace TicTacToeGame
    {
    class Program
        {
        static void Main(string[] args)
            {
                GameController controller = new GameController();
                try
                {
                    int dimensionofgame = 3;
                    List<Player> players = new List<Player>();
                    players.Add(new Player(
                        1,"Anup Agarwal",PlayerType.HUMAN,new Symbol('X')
                        ));
				    players.Add(new BotPlayer(
                        2,"BOT Mona",PlayerType.BOT,new Symbol('O'),BotDifficultyLevel.EASY
                        ));
                    
                    List<WinningStrategy> strategies = new List<WinningStrategy>();
				    strategies.Add(new RowWinningStrategy());
                    strategies.Add(new ColWinningStrategy());
                    strategies.Add(new DiagonalWinningStrategy());

				    Game game = controller.StartGame(
                                dimensionofgame,players, strategies
						);
                    while(game.gameState==GameState.INPROGRESS)
                    {
                        // 1. first we have to print board
                        // 2. whose turn is it
                        // 3. ask user to move
                        controller.DisplayBoard(game);
                        Console.WriteLine("Do you want to undo ?(y/n)");
                        string response=Console.ReadLine();
                        if(response=="y" || response=="Y")
                        {
                            controller.undo(game);
                            continue;
                        }
                        controller.MakeMove(game);

                    }
                    Console.WriteLine("Game is finished!!");

                    GameState state = game.gameState;
                    if (state == GameState.DRAWN)
                    {
                        Console.WriteLine("Game is Drawn!!");
                    }
                    else
                    {
                        Console.WriteLine("Game is won by " + game.getWinner().Name);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            Console.WriteLine("Press any key to exit!");
            Console.ReadLine();
		}
        }
    }
