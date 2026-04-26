namespace K
{
    partial class Durak
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
            btnNewGame = new Button();
            btnTake = new Button();
            btnFinish = new Button();
            firstPlayerHand = new ListBox();
            firstComputerHand = new ListBox();
            firstTable = new ListBox();
            btnAttack = new Button();
            lblTrump = new Label();
            lblDeck = new Label();
            lblTurn = new Label();
            btnDefend = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(-5, -3);
            btnNewGame.Margin = new Padding(6);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(354, 54);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnTake
            // 
            btnTake.BackColor = Color.LightGoldenrodYellow;
            btnTake.FlatStyle = FlatStyle.Flat;
            btnTake.Location = new Point(827, 108);
            btnTake.Margin = new Padding(6);
            btnTake.Name = "btnTake";
            btnTake.Size = new Size(200, 74);
            btnTake.TabIndex = 1;
            btnTake.Text = "Забрать";
            btnTake.UseVisualStyleBackColor = false;
            btnTake.Click += btnTake_Click;
            // 
            // btnFinish
            // 
            btnFinish.BackColor = Color.LightGoldenrodYellow;
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Location = new Point(568, 108);
            btnFinish.Margin = new Padding(6);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(200, 74);
            btnFinish.TabIndex = 2;
            btnFinish.Text = "Бито";
            btnFinish.UseVisualStyleBackColor = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // firstPlayerHand
            // 
            firstPlayerHand.BackColor = Color.LightGray;
            firstPlayerHand.BorderStyle = BorderStyle.FixedSingle;
            firstPlayerHand.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            firstPlayerHand.FormattingEnabled = true;
            firstPlayerHand.Location = new Point(482, 322);
            firstPlayerHand.Margin = new Padding(6);
            firstPlayerHand.Name = "firstPlayerHand";
            firstPlayerHand.Size = new Size(95, 281);
            firstPlayerHand.TabIndex = 3;
            firstPlayerHand.SelectedIndexChanged += firstPlayerHand_SelectedIndexChanged;
            // 
            // firstComputerHand
            // 
            firstComputerHand.BackColor = Color.LightGray;
            firstComputerHand.BorderStyle = BorderStyle.FixedSingle;
            firstComputerHand.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            firstComputerHand.FormattingEnabled = true;
            firstComputerHand.Location = new Point(1102, 322);
            firstComputerHand.Margin = new Padding(6);
            firstComputerHand.Name = "firstComputerHand";
            firstComputerHand.Size = new Size(86, 281);
            firstComputerHand.TabIndex = 4;
            firstComputerHand.SelectedIndexChanged += firstComputerHand_SelectedIndexChanged;
            // 
            // firstTable
            // 
            firstTable.BackColor = Color.LightGray;
            firstTable.BorderStyle = BorderStyle.FixedSingle;
            firstTable.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            firstTable.FormattingEnabled = true;
            firstTable.Location = new Point(788, 322);
            firstTable.Margin = new Padding(6);
            firstTable.Name = "firstTable";
            firstTable.Size = new Size(104, 281);
            firstTable.TabIndex = 5;
            firstTable.SelectedIndexChanged += firstTable_SelectedIndexChanged;
            // 
            // btnAttack
            // 
            btnAttack.BackColor = Color.LightGoldenrodYellow;
            btnAttack.FlatStyle = FlatStyle.Flat;
            btnAttack.Location = new Point(568, 220);
            btnAttack.Margin = new Padding(6);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(200, 74);
            btnAttack.TabIndex = 6;
            btnAttack.Text = "Ход";
            btnAttack.UseVisualStyleBackColor = false;
            btnAttack.Click += btnAttack_Click;
            // 
            // lblTrump
            // 
            lblTrump.AutoSize = true;
            lblTrump.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTrump.ForeColor = Color.Gold;
            lblTrump.Location = new Point(405, 6);
            lblTrump.Margin = new Padding(6, 0, 6, 0);
            lblTrump.Name = "lblTrump";
            lblTrump.Size = new Size(121, 38);
            lblTrump.TabIndex = 7;
            lblTrump.Text = "Козырь";
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblDeck.ForeColor = Color.Gold;
            lblDeck.Location = new Point(774, 6);
            lblDeck.Margin = new Padding(6, 0, 6, 0);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(118, 38);
            lblDeck.TabIndex = 8;
            lblDeck.Text = "Колода";
            lblDeck.Click += lblDeck_Click;
            // 
            // lblTurn
            // 
            lblTurn.AutoSize = true;
            lblTurn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTurn.ForeColor = Color.Gold;
            lblTurn.Location = new Point(1190, 6);
            lblTurn.Margin = new Padding(6, 0, 6, 0);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(135, 38);
            lblTurn.TabIndex = 9;
            lblTurn.Text = "Очередь";
            // 
            // btnDefend
            // 
            btnDefend.BackColor = Color.LightGoldenrodYellow;
            btnDefend.FlatStyle = FlatStyle.Flat;
            btnDefend.Location = new Point(827, 220);
            btnDefend.Margin = new Padding(6);
            btnDefend.Name = "btnDefend";
            btnDefend.Size = new Size(200, 74);
            btnDefend.TabIndex = 10;
            btnDefend.Text = "Защита";
            btnDefend.UseVisualStyleBackColor = false;
            btnDefend.Click += btnDefend_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(24, 624);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(124, 47);
            btnExit.TabIndex = 11;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Durak
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1454, 691);
            Controls.Add(btnExit);
            Controls.Add(btnDefend);
            Controls.Add(lblTurn);
            Controls.Add(lblDeck);
            Controls.Add(lblTrump);
            Controls.Add(btnAttack);
            Controls.Add(firstTable);
            Controls.Add(firstComputerHand);
            Controls.Add(firstPlayerHand);
            Controls.Add(btnFinish);
            Controls.Add(btnTake);
            Controls.Add(btnNewGame);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6);
            Name = "Durak";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Дурак";
            Load += Durak_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewGame;
        private Button btnTake;
        private Button btnFinish;
        private ListBox firstPlayerHand;
        private ListBox firstComputerHand;
        private ListBox firstTable;
        private Button btnAttack;
        private Label lblTrump;
        private Label lblDeck;
        private Label lblTurn;
        private Button btnDefend;
        private Button btnExit;
    }
}
