using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exceptions;
using TicTacToeGame.Strategies;

namespace TicTacToeGame.Models
{
	public enum GameState
	{
		INPROGRESS,
		PAUSED,
		DRAWN,
		SUCCESS
	};
	public class Game
	{
		List<Player> _players=new List<Player>();
		List<Move> moves=new List<Move>();

		public List<Move> getListofAllMoves() { return moves; }
		Board  Board { get; set; }
		List<WinningStrategy> WinningStrategies=new List<WinningStrategy>();

		Player Winner;

		public Player getWinner() { return Winner; }
		public GameState gameState { get; set; }
		int nextMovePlayerIndex;
		public int NextMovePlayerIndex { get; set; }

		public void undo()
		{
			if (moves.Count == 0)
			{
				Console.WriteLine("There are no moves to undo!!");
				return;
			}
			// Implementing kuch kuch hota hai technique in undo as learnt from naman
			Move movetobeRemoved=moves.Last();
			moves.Remove(movetobeRemoved);
			Cell cellonBoard = Board.getBoard()[movetobeRemoved.Cell.Row][movetobeRemoved.Cell.Col];
			cellonBoard.setPlayer(null);
			cellonBoard.setCellState(CellState.EMPTY);

			foreach(var winningstrat in WinningStrategies)
			{
				winningstrat.HandleUndo(Board, movetobeRemoved);
			}

			nextMovePlayerIndex -= 1;
			nextMovePlayerIndex=(nextMovePlayerIndex+_players.Count)%_players.Count;

		}

		private bool validateMove(Move m)
		{
			int row = m.Cell.Row;
			int col = m.Cell.Col;
			if(row>=Board.getDimension())
			{
                Console.WriteLine($"The row given should be less than {Board.getDimension()}");
                return false;
			}
			if(col>=Board.getDimension())
			{
                Console.WriteLine($"The column given should be less than {Board.getDimension()}");
				return false;

            }
			if (Board.getBoard()[row][col].getCellState()!=CellState.EMPTY)
			{
                Console.WriteLine($"The given row and cell is already filled. Please provide a valid move.");
				return false;
            }
			return true;
		}

		private bool checkWinner(Move move)
		{
			foreach(var winningstrategy in WinningStrategies)
			{
				if (winningstrategy.CheckWinner(Board, move))
					return true;
			}
			return false;
		}
		public void makeMove()
		{
			Player currentplayer = _players[nextMovePlayerIndex];

			Console.WriteLine("It is "+currentplayer.Name+" 's turn. Please make your move.");
			Move m=currentplayer.makeMove(Board);
            Console.WriteLine("you made move at row: "+m.Cell.Row+", column: "+m.Cell.Col);
			if(!validateMove(m))
			{
                Console.WriteLine("Invalid Move. Please try again.");
				return;
            }
			nextMovePlayerIndex++;
			nextMovePlayerIndex=nextMovePlayerIndex%(_players.Count);

			int row = m.Cell.Row;
			int col = m.Cell.Col;

			Cell newCelltobeChanged = Board.getBoard()[row][col];
			newCelltobeChanged.setCellState(CellState.FILLED);
			newCelltobeChanged.setPlayer(currentplayer);
			moves.Add(new Move(newCelltobeChanged, currentplayer));

			if(checkWinner(m))
			{
				this.gameState = GameState.SUCCESS;
				this.Winner = currentplayer;
			}
			else if(moves.Count==(Board.getDimension()* (Board.getDimension())))
			{
				gameState = GameState.DRAWN;

			}

			return;
        }

		public void DisplayBoard()
		{
			Board.printBorad();
		}

		public Game(List<Player> listofPlayers,int dimension,List<WinningStrategy> winningStrategies)
		{
			
			this._players=listofPlayers;
			this.WinningStrategies=winningStrategies;
			this.gameState = GameState.INPROGRESS;
			this.nextMovePlayerIndex=0;
			this.Board=new Board(dimension);
		}
		public static Builder CreateBuilder()
		{
			return new Builder();
		}

		public  class Builder
		{
			private List<Player> _players=new List<Player>();	
			private List<WinningStrategy> WinningStrategies =new List<WinningStrategy>();
		
			private int dimension;

			public Builder SetListofPlayers(List<Player> players)
			{
				this._players = players;
				return this;
			}
			public Builder addPlayer(Player player)
			{
				this._players.Add(player);
				return this;
			}

			public Builder addWinningStrategy(WinningStrategy strategy)
			{
				this.WinningStrategies.Add(strategy);
				return this;
			}

			public Builder SetDimesnion(int dimension)
			{
				this.dimension = dimension;
				return this;
			}
			public Builder SetWinningStrategies(List<WinningStrategy> winningStrategies)
			{
				this.WinningStrategies = winningStrategies;
				return this;
			}

			private Boolean CheckifBotCountIsMoreThanOnOrNot()
			{
				int botCount = 0;
				foreach (var item in _players)
				{
					if (item.GetPlayerType == PlayerType.BOT)
						botCount++;
				}
				if (botCount > 1)
				{
					throw new MoreThanOneBotCountException();
				}
				return true;
			}

			private Boolean ValidateDimensionandPlayerCount()
			{
				if(dimension-1!=_players.Count)
				{
					throw new PlayersCountDimensionMismatchException();
				}
				return true;
			}
			private Boolean ValidateUniqueSymbolsForPlayers()
			{
				try
				{
					Dictionary<char, int> symbolCount = new Dictionary<char, int>();
					foreach (var player in _players)
					{
						if (!symbolCount.ContainsKey(player.getSymbol.Name))
						{
							symbolCount.Add(player.getSymbol.Name, 1);
						}
						else
							symbolCount[player.getSymbol.Name]++;
						if (symbolCount[player.getSymbol.Name] > 1)
						{
							throw new DuplicateSymbolException();
						}

					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				
				return true;
			}
			private void validate()
			{
				try
				{
					CheckifBotCountIsMoreThanOnOrNot();
					ValidateDimensionandPlayerCount();
					ValidateUniqueSymbolsForPlayers();
					
				}
				catch (Exception ex)
				{
					throw ex;
				}
				
			}

			public Game build()
			{
				try
				{
					validate();
				}
				catch (Exception ex)
				{
					throw ex;
				}
					
				return new Game(_players,dimension, WinningStrategies);

			}

		}
		public List<Player> GetPlayers()
		{
			return _players;
		}

	}
}
