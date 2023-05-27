using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
	public interface WinningStrategy
	{
		Boolean CheckWinner(Board board,Move move);
		void HandleUndo(Board board, Move move);

	}
}
