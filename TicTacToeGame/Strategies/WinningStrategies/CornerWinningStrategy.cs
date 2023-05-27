using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies.WinningStrategies
{
	public class CornerWinningStrategy : WinningStrategy
	{
		Dictionary<Symbol, int> symbolCountCornerWise = new Dictionary<Symbol, int>();
		public bool CheckWinner(Board board, Move move)
		{
			try
			{
				int row = move.Cell.Row;
				int col = move.Cell.Col;
				if ((row == 0 && col == 0) || (row == 0 && col == board.getDimension() - 1) ||
					(row == board.getDimension() - 1 && col == 0) || (row == board.getDimension() - 1 && col == board.getDimension() - 1)
					)
				{
					if (!symbolCountCornerWise.ContainsKey(move.getnSetPlayer.getSymbol))
					{
						symbolCountCornerWise.Add(move.getnSetPlayer.getSymbol, 1);
					}
					symbolCountCornerWise[move.getnSetPlayer.getSymbol]++;
					if (symbolCountCornerWise[move.getnSetPlayer.getSymbol] == board.getDimension()) return true;

				}
				return false;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		
		public void HandleUndo(Board board, Move move)
		{
			int row = move.Cell.Row;
			int col = move.Cell.Col;
			if ((row == 0 && col == 0) || (row == 0 && col == board.getDimension() - 1) ||
				(row == board.getDimension() - 1 && col == 0) || (row == board.getDimension() - 1 && col == board.getDimension() - 1)
				)
			{
				symbolCountCornerWise[move.getnSetPlayer.getSymbol]--;
			}
		}
	}
}
