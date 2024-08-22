using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
	public class Player
	{
		public string name;
		public string Name { get => name; set => name = value; }
		public Image mark;
		public Image Mark { get => mark; set => mark = value; }

		public Player(string name, Image mark) 
		{ 
			this.Name = name;
			this.Mark = mark;
		}
	}
}
