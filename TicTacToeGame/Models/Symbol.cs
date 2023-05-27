using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Models
{
	public class Symbol
	{
		private char name { get; set; }
        public Symbol(char name)
        {
            this.name = name;
        }
        public char Name { get { return name; } }

    }
}
