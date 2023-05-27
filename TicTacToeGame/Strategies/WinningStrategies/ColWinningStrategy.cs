using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies.WinningStrategies
{
	public class ColWinningStrategy:WinningStrategy
	{
		Dictionary<int, Dictionary<Symbol, int>> symbolCountColWise = new Dictionary<int, Dictionary<Symbol, int>>();

		public bool CheckWinner(Board board, Move move)
		{
			try
			{
				int row = move.Cell.Row;
				int col = move.Cell.Col;
				if (!symbolCountColWise.ContainsKey(col))
				{
					symbolCountColWise.Add(col, new Dictionary<Symbol, int>());
				}
				Dictionary<Symbol, int> colMap = symbolCountColWise[col];
				if (!colMap.ContainsKey(move.getnSetPlayer.getSymbol))
				{
					colMap.Add(move.getnSetPlayer.getSymbol, 0);
				}
				colMap[move.getnSetPlayer.getSymbol]++;

				if (colMap[move.getnSetPlayer.getSymbol] == board.getDimension())
					return true;
				return false;
			}
			catch (Exception e)
			{
				throw e;
			}
			

		}

		public void HandleUndo(Board board, Move move)
		{
			int col = move.Cell.Col;
			symbolCountColWise[col][move.getnSetPlayer.getSymbol]--;
		}
	}
}
