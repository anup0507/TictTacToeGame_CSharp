using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;

namespace TicTacToeGame.Strategies
{
	public interface IBotPlayingStrategy
	{
		  Move makeMove(Board board);
	}
}
