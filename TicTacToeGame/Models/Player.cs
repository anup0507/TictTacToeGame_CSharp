using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
	public enum PlayerType
	{
		HUMAN,
		BOT
	};
	public class Player
	{
		string name;
		int id;
		public string Name { get { return name; }
		set { name = value; } }
		public int Id { get { return id; }
		set { id = value; } }

		PlayerType playertype;
		Symbol symbol;
		public Player(int id,string Name,PlayerType playerType,Symbol symbol) {
		
			this.id = id;
			this.Name = Name;
			this.playertype = playerType;
			this.symbol = symbol;

		}
		
		public PlayerType GetPlayerType { get {  return playertype; } set {  playertype = value; } }
		public Symbol getSymbol { get { return symbol; } set { symbol = value; } }

		public virtual Move makeMove(Board board)
		{
            Console.WriteLine("Please tell the row Count where you want to move, starting from 0.");
			int row, col;
			while(true)
			{
				string r = Console.ReadLine();

				if (Int32.TryParse(r, out int id))
				{
					row = Convert.ToInt32(r);
					break;
				}
				else
				{
					Console.WriteLine("Invalid row data given as input. it should be an integer starting from 0. Please give valid input.");
					
				}
			}
            Console.WriteLine("Please now tell the column count where you want to move , starting from 0.");
            while (true)
			{
				string c = Console.ReadLine();

				if (Int32.TryParse(c, out int id))
				{
					col = Convert.ToInt32(c);
					break;
				}
				else
				{
					Console.WriteLine("Invalid column data given as input. it should be an integer starting from 0. Please give valid input.");
					
				}
			}
			return new Move(new Cell(row, col),this);
			
        }

	}
}
