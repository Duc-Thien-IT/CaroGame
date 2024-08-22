using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
	public class ManageChessBoard
	{
		//Properties
		#region Properties
		private Panel pnl;
		private List<Player> player;
		private int currentPlayer;
		private List<List<Button>> matrix;
		private ProgressBar pgRow;
		private ProgressBar pgColumn;

		public Panel Pnl
		{
			get { return pnl; }	
			set { pnl  = value; }	
		}
		public List<Player> Player { get => player; set => player = value; }
		public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
		public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

		#endregion


		//Initialize
		#region Initialize
		public ManageChessBoard(Panel pnl)
		{
			this.pnl = pnl;
			this.player = new List<Player>()
			{
				new Player("1", Image.FromFile(Application.StartupPath + "\\Resource\\close.png")),
				new Player("2", Image.FromFile(Application.StartupPath + "\\Resource\\circle-ring.png"))
			};

			CurrentPlayer = 0;

			pgRow = new ProgressBar()
			{
				Location = new Point(pnl.Width + 10, 10),
				Width = 200,
				Maximum = 30
			};

			pgColumn = new ProgressBar()
			{
				Location = new Point(pnl.Width + 10, 40),
				Width = 200,
				Maximum = 30
			};

			pnl.Parent.Controls.Add(pgRow);
			pnl.Parent.Controls.Add(pgColumn);
		}


		#endregion

		#region Methods
		public void CreateChessBoard()
		{
			pnl.Controls.Clear();
			Matrix = new List<List<Button>>();

			Button oldBtn = new Button()
			{
				Width = 0,
				Location = new Point(0, 0)
			};

			for (int i = 0; i < 30; i++)
			{
				Matrix.Add(new List<Button>());
				for (int j = 0; j < 30; j++)
				{
					Button btn = new Button()
					{
						Width = Cons.chess_width,
						Height = Cons.chess_heigt,
						Location = new Point(oldBtn.Width + oldBtn.Location.X, oldBtn.Location.Y),
						BackgroundImageLayout = ImageLayout.Stretch,
						Tag = i.ToString()
					};

					Matrix[i].Add(btn); 
					btn.Click += btn_Click;

					pnl.Controls.Add(btn);
					oldBtn = btn;
				}
				oldBtn.Location = new Point(0, oldBtn.Location.Y + Cons.chess_heigt);
				oldBtn.Width = 0;
				oldBtn.Height = 0;
			}
		}

		void btn_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;

			if(btn.BackgroundImage != null)
			{
				return;
			} 

			btn.BackgroundImage = Player[CurrentPlayer].Mark;
			CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

			UpdateProgressBarRow(btn);
			UpdateProgressBarColumn(btn);

			if (isEndGame(btn))
			{
				EndGame();
			}

		}

		private void EndGame()
		{
			MessageBox.Show("Kết thúc trò chơi");
		}

		private bool isEndGame(Button btn)
		{
			return isEndGameNgang(btn) || isEndGameDoc(btn) || isEndGameCheo(btn) || isEndGameSub(btn);
		}

		private bool isEndGameNgang(Button btn)
		{
			Point point = getChessPoint(btn);

			int countLeft = 0;
			int countRight = 0;
				
			for(int i = point.X; i >= 0; i--)
			{
				if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
				{
					countLeft++;
				}
				else
				{
					break;
				}
			}

			for (int i = point.X + 1; i < 30; i++)
			{
				if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
				{
					countRight++;
				}
				else
				{
					break;
				}
			}

			return countLeft + countRight == 5;
		}

		private bool isEndGameDoc(Button btn)
		{
			Point point = getChessPoint(btn);

			int countUp = 0;
			int countDown = 0;

			for (int i = point.Y; i >= 0; i--)
			{
				if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
				{
					countUp++;
				}
				else
				{
					break;
				}
			}

			for (int i = point.Y + 1; i < 30; i++)
			{
				if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
				{
					countDown++;
				}
				else
				{
					break;
				}
			}

			return countUp + countDown == 5;
		}

		private bool isEndGameCheo(Button btn)
		{
			Point point = getChessPoint(btn);

			int countUp = 0;
			int countDown = 0;

			for (int i = 0; i <= point.X; i++)
			{
				if (point.X - i < 0 || point.Y - i < 0)
					break;
				if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
				{
					countUp++;
				}
				else
				{
					break;
				}
			}

			for (int i = 1; i <= 30 - point.X; i++)
			{
				if (point.Y + i >= 30 || point.X + i >= 30)
					break;
				if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
				{
					countDown++;
				}
				else
				{
					break;
				}
			}

			return countUp + countDown == 5;
		}

		private bool isEndGameSub(Button btn)
		{
			Point point = getChessPoint(btn);

			int countUp = 0;
			int countDown = 0;

			for (int i = 0; i <= point.X; i++)
			{
				if (point.X + i > 30 || point.Y - i < 0)
					break;

				if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
				{
					countUp++;
				}
				else
				{
					break;
				}
			}

			for (int i = 1; i <= 30 - point.X; i++)
			{
				if (point.Y + i >= 30 || point.X - i < 0)
					break;

				if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
				{
					countDown++;
				}
				else
				{
					break;
				}
			}

			return countUp + countDown == 5;
		}

		private Point getChessPoint(Button btn)
		{
			int vertical = Convert.ToInt32(btn.Tag);
			int horizontal = Matrix[vertical].IndexOf(btn);
			Point point = new Point(horizontal, vertical);
			return point;
		}

		private void UpdateProgressBarRow(Button btn)
		{
			Point point = getChessPoint(btn);
			int rowIndex = point.Y;
			int filledButtonsInRow = Matrix[rowIndex].Count(b => b.BackgroundImage != null);

			pgRow.Value = filledButtonsInRow;
		}

		private void UpdateProgressBarColumn(Button btn)
		{
			Point point = getChessPoint(btn);
			int colIndex = point.X;
			int filledButtonsInColumn = 0;

			for (int i = 0; i < Matrix.Count; i++)
			{
				if (Matrix[i][colIndex].BackgroundImage != null)
				{
					filledButtonsInColumn++;
				}
			}

			pgColumn.Value = filledButtonsInColumn;
		}


		#endregion

	}
}
