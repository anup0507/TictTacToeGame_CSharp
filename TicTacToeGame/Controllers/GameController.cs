using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Controllers
{
	public class GameController
	{
		public  Game StartGame(int dimensionofboard,List<Player> players,List<WinningStrategy> winningStrategies)
		{
			return 
				Game.CreateBuilder()
				.SetListofPlayers(players)
				.SetDimesnion(dimensionofboard)
				.SetWinningStrategies(winningStrategies)
				.build();
		}
		public void MakeMove(Game game) {

			game.makeMove();
		}
		public void DisplayBoard(Game game) { 
			game.DisplayBoard();
		}

		public void undo(Game game) {
			 game.undo();
		}
		public Player getWinner(Game game) {
			return game.getWinner();
		}

		public GameState CheckState(Game game) {
			return game.gameState;
		}



		public GameController() { }

	}
}
