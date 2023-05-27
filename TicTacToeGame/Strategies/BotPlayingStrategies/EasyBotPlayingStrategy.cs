using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies.BotPlayingStrategies
{
	public class EasyBotPlayingStrategy : IBotPlayingStrategy
	{
		public Move makeMove(Board board)
		{
			for (int i=0;i < board.getBoard().Count;i++)
			{
				for(int j = 0; j < board.getBoard()[i].Count;j++)
				{
					if (board.getBoard()[i][j].getCellState()==CellState.EMPTY)
					{
						return new Move(new Cell(i, j), null);
					}
				}
			}
			return null;
			
		}

		
	}
}
