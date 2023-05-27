using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Models;
using TicTacToeGame.Strategies.BotPlayingStrategies;

namespace TicTacToeGame.Strategies
{
	public class BotPlayingStrategyFactory
	{
		public static IBotPlayingStrategy GetBotPlayingStrategy(BotDifficultyLevel botDifficultylevel)
		{
			switch (botDifficultylevel)
			{
				case BotDifficultyLevel.EASY:
					return new EasyBotPlayingStrategy();
					
				case BotDifficultyLevel.HARD:
					return new HardBotPlayingStrategy();
				case BotDifficultyLevel.MEDIUM: return new MediumBotPlayingStrategy();
				default:
					return new EasyBotPlayingStrategy();
			}

		}
	}
}
