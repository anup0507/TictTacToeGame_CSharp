using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
	public class Move
	{
		Player player;
		Cell cell;
        public Move(Cell cell, Player player)
        {
            this.cell = cell;
            this.player = player;
        }
        public Player getnSetPlayer { get { return player; } set { player = value; } }
        public Cell Cell { get { return cell; }set { cell = value; } }
    }
}
