using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
	public class Board
	{
		int dimension;
		public int getDimension() { return dimension; }

        List<List<Cell>> board;

        public List<List<Cell>> getBoard() { return board; }
        public void setBoard(List<List<Cell>> board)
        { this.board = board; }

        public Board(int size)
        {
            board=new List<List<Cell>>();
            for(int i = 0; i < size; i++)
            {
                board.Add(new List<Cell>());
                for(int  j = 0; j < size; j++)
                {
                    board[i].Add(new Cell(i,j));
                }
            }
            dimension = size;
        }
        public void printBorad()
        {
            foreach(var cell in board)
            {
                foreach(Cell cell2 in cell)
                {
                    if(cell2.getPlayer() != null)
                        Console.Write(" "+cell2.getPlayer().getSymbol.Name+" ") ;
                    else
                        Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

    }
}
