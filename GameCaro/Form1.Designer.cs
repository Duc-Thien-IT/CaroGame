namespace GameCaro
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pnlChess = new Panel();
			panel2 = new Panel();
			txtNM = new TextBox();
			btnEnter = new Button();
			label1 = new Label();
			pg1 = new ProgressBar();
			pg2 = new ProgressBar();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// pnlChess
			// 
			pnlChess.Location = new Point(12, 11);
			pnlChess.Name = "pnlChess";
			pnlChess.Size = new Size(879, 900);
			pnlChess.TabIndex = 0;
			// 
			// panel2
			// 
			panel2.Controls.Add(txtNM);
			panel2.Controls.Add(btnEnter);
			panel2.Controls.Add(label1);
			panel2.Location = new Point(897, 11);
			panel2.Name = "panel2";
			panel2.Size = new Size(174, 455);
			panel2.TabIndex = 1;
			// 
			// txtNM
			// 
			txtNM.Location = new Point(26, 78);
			txtNM.Name = "txtNM";
			txtNM.Size = new Size(125, 27);
			txtNM.TabIndex = 2;
			// 
			// btnEnter
			// 
			btnEnter.Location = new Point(39, 127);
			btnEnter.Name = "btnEnter";
			btnEnter.Size = new Size(94, 29);
			btnEnter.TabIndex = 1;
			btnEnter.Text = "Enter";
			btnEnter.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 36);
			label1.Name = "label1";
			label1.Size = new Size(162, 20);
			label1.TabIndex = 0;
			label1.Text = "Choose Number Matrix";
			// 
			// pg1
			// 
			pg1.Location = new Point(12, 926);
			pg1.Name = "pg1";
			pg1.Size = new Size(240, 22);
			pg1.TabIndex = 2;
			// 
			// pg2
			// 
			pg2.Location = new Point(12, 954);
			pg2.Name = "pg2";
			pg2.Size = new Size(571, 21);
			pg2.TabIndex = 3;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1083, 1034);
			Controls.Add(pg2);
			Controls.Add(pg1);
			Controls.Add(panel2);
			Controls.Add(pnlChess);
			Name = "Form1";
			Text = "Form1";
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel pnlChess;
		private Panel panel2;
		private Button btnEnter;
		private Label label1;
		private ProgressBar pg1;
		private ProgressBar pg2;
		private TextBox txtNM;
	}
}
