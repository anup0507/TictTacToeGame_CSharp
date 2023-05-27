using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
	public enum CellState
	{
		EMPTY,
		FILLED,
		BLOCKED
	}
	public class Cell
	{
		int row;
		public int Row { get { return row; }set { row = value; } }
		int col;
		public int Col { get { return col; }set { col = value; } }
		Player player;
        public Cell(int row,int col)
        {
			this.Row = row;
			this.Col = col;
			this.setCellState(CellState.EMPTY);
			player = null;
        }

        public Player getPlayer() { return player; }

		public void setPlayer(Player p) { player = p; }

		CellState state;

		public CellState getCellState() { return state; }

		public void setCellState(CellState c) { state = c; }

        public Cell()
        {
            
        }
    }
}
