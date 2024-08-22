using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro
{
	public partial class Form1 : Form
	{
		#region Properties
		ManageChessBoard manageChessBoard;
		#endregion
		public Form1()
		{
			InitializeComponent();

			manageChessBoard = new ManageChessBoard(pnlChess);
			manageChessBoard.CreateChessBoard();
		}

	}
}
