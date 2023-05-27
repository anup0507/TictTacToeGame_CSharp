using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies.WinningStrategies
{
	public class DiagonalWinningStrategy : WinningStrategy
	{
		Dictionary<Symbol, int> symbolCountDiagLeftWise = new Dictionary<Symbol, int>();
		Dictionary<Symbol, int> symbolCountDiagRightWise = new Dictionary<Symbol, int>();
		public bool CheckWinner(Board board, Move move)
		{
			try
			{
				int row = move.Cell.Row;
				int col = move.Cell.Col;
				if (row == col)// left diagnonal
				{
					if (!symbolCountDiagLeftWise.ContainsKey(move.getnSetPlayer.getSymbol))
					{
						symbolCountDiagLeftWise.Add(move.getnSetPlayer.getSymbol, 0);
					}
					symbolCountDiagLeftWise[move.getnSetPlayer.getSymbol]++;
					if (symbolCountDiagLeftWise[move.getnSetPlayer.getSymbol] == board.getDimension()) return true;

				}
				if (row + col == board.getDimension() - 1) // right diagonal
				{
					if (!symbolCountDiagRightWise.ContainsKey(move.getnSetPlayer.getSymbol))
					{
						symbolCountDiagRightWise.Add(move.getnSetPlayer.getSymbol, 0);
					}
					symbolCountDiagRightWise[move.getnSetPlayer.getSymbol]++;
					if (symbolCountDiagRightWise[move.getnSetPlayer.getSymbol] == board.getDimension()) return true;
				}
				return false;
			}
			catch(Exception ex) {
				throw ex;
			}
			
			
		}

		public void HandleUndo(Board board, Move move)
		{
			int row = move.Cell.Row;
			int col = move.Cell.Col;
			if(row==col)// left diagonal
			{
				symbolCountDiagLeftWise[move.getnSetPlayer.getSymbol]--;
			}
			if (row + col == board.getDimension() - 1) // right diagonal
			{
				symbolCountDiagRightWise[move.getnSetPlayer.getSymbol]--;
			}
		}
	}
}
