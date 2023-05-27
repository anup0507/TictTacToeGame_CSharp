using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies.WinningStrategies
{
	public class RowWinningStrategy : WinningStrategy
	{
		Dictionary<int, Dictionary<Symbol, int>> symbolCountRowWise = new Dictionary<int, Dictionary<Symbol, int>>();
		public bool CheckWinner(Board board, Move move)
		{
			try
			{
				int row = move.Cell.Row;
				int col = move.Cell.Col;
				if (!symbolCountRowWise.ContainsKey(row))
				{
					symbolCountRowWise.Add(row, new Dictionary<Symbol, int>());
				}
				Dictionary<Symbol, int> rowMap = symbolCountRowWise[row];
				if (!rowMap.ContainsKey(move.getnSetPlayer.getSymbol))
				{
					rowMap.Add(move.getnSetPlayer.getSymbol, 0);
				}
				rowMap[move.getnSetPlayer.getSymbol]++;

				if (rowMap[move.getnSetPlayer.getSymbol] == board.getDimension())
					return true;
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		public void HandleUndo(Board board, Move move)
		{
			int row = move.Cell.Row;
			symbolCountRowWise[row][move.getnSetPlayer.getSymbol]--;
		}
	}
}
