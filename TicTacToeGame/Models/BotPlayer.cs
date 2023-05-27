using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Models
{
	public enum BotDifficultyLevel
	{
		EASY,
		MEDIUM,
		HARD

	};
	internal class BotPlayer : Player
	{
		private BotDifficultyLevel botDifficultyLevel;
		IBotPlayingStrategy botStragegy;
		public BotPlayer(int id, string Name, PlayerType playerType, Symbol symbol,BotDifficultyLevel botDifficultyLevel
			):base(id,Name,playerType,symbol)
		{
			this.botDifficultyLevel = botDifficultyLevel;
			this.botStragegy =  BotPlayingStrategyFactory.GetBotPlayingStrategy(botDifficultyLevel);
		}

		public BotDifficultyLevel BotDifficultyLevel { get { return botDifficultyLevel; } }

		public override Move makeMove(Board board)
		{
			Move move = botStragegy.makeMove(board);
			move.getnSetPlayer = this;
			return move;
		}
	}
}
