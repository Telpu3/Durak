namespace K
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
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(-2, -1);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(177, 29);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnTake
            // 
            btnTake.BackColor = Color.LightGoldenrodYellow;
            btnTake.FlatStyle = FlatStyle.Flat;
            btnTake.Location = new Point(143, 151);
            btnTake.Name = "btnTake";
            btnTake.Size = new Size(100, 40);
            btnTake.TabIndex = 1;
            btnTake.Text = "Забрать";
            btnTake.UseVisualStyleBackColor = false;
            btnTake.Click += btnTake_Click;
            // 
            // btnFinish
            // 
            btnFinish.BackColor = Color.LightGoldenrodYellow;
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.Location = new Point(293, 151);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(100, 40);
            btnFinish.TabIndex = 2;
            btnFinish.Text = "Бито";
            btnFinish.UseVisualStyleBackColor = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // firstPlayerHand
            // 
            firstPlayerHand.BackColor = Color.LightGray;
            firstPlayerHand.BorderStyle = BorderStyle.FixedSingle;
            firstPlayerHand.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstPlayerHand.FormattingEnabled = true;
            firstPlayerHand.Location = new Point(43, 223);
            firstPlayerHand.Name = "firstPlayerHand";
            firstPlayerHand.Size = new Size(185, 177);
            firstPlayerHand.TabIndex = 3;
            firstPlayerHand.SelectedIndexChanged += firstPlayerHand_SelectedIndexChanged;
            // 
            // firstComputerHand
            // 
            firstComputerHand.BackColor = Color.LightGray;
            firstComputerHand.BorderStyle = BorderStyle.FixedSingle;
            firstComputerHand.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstComputerHand.FormattingEnabled = true;
            firstComputerHand.Location = new Point(580, 223);
            firstComputerHand.Name = "firstComputerHand";
            firstComputerHand.Size = new Size(185, 177);
            firstComputerHand.TabIndex = 4;
            firstComputerHand.SelectedIndexChanged += firstComputerHand_SelectedIndexChanged;
            // 
            // firstTable
            // 
            firstTable.BackColor = Color.LightGray;
            firstTable.BorderStyle = BorderStyle.FixedSingle;
            firstTable.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstTable.FormattingEnabled = true;
            firstTable.Location = new Point(313, 223);
            firstTable.Name = "firstTable";
            firstTable.Size = new Size(185, 177);
            firstTable.TabIndex = 5;
            firstTable.SelectedIndexChanged += firstTable_SelectedIndexChanged;
            // 
            // btnAttack
            // 
            btnAttack.BackColor = Color.LightGoldenrodYellow;
            btnAttack.FlatStyle = FlatStyle.Flat;
            btnAttack.Location = new Point(457, 151);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(100, 40);
            btnAttack.TabIndex = 6;
            btnAttack.Text = "Ход";
            btnAttack.UseVisualStyleBackColor = false;
            btnAttack.Click += btnAttack_Click;
            // 
            // lblTrump
            // 
            lblTrump.AutoSize = true;
            lblTrump.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTrump.ForeColor = Color.Gold;
            lblTrump.Location = new Point(202, 3);
            lblTrump.Name = "lblTrump";
            lblTrump.Size = new Size(80, 25);
            lblTrump.TabIndex = 7;
            lblTrump.Text = "Козырь";
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblDeck.ForeColor = Color.Gold;
            lblDeck.Location = new Point(387, 3);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(78, 25);
            lblDeck.TabIndex = 8;
            lblDeck.Text = "Колода";
            lblDeck.Click += lblDeck_Click;
            // 
            // lblTurn
            // 
            lblTurn.AutoSize = true;
            lblTurn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblTurn.ForeColor = Color.Gold;
            lblTurn.Location = new Point(595, 3);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(89, 25);
            lblTurn.TabIndex = 9;
            lblTurn.Text = "Очередь";
            // 
            // btnDefend
            // 
            btnDefend.BackColor = Color.LightGoldenrodYellow;
            btnDefend.FlatStyle = FlatStyle.Flat;
            btnDefend.Location = new Point(595, 151);
            btnDefend.Name = "btnDefend";
            btnDefend.Size = new Size(100, 40);
            btnDefend.TabIndex = 10;
            btnDefend.Text = "Защита";
            btnDefend.UseVisualStyleBackColor = false;
            btnDefend.Click += btnDefend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(800, 450);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Дурак";
            Load += Form1_Load;
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
    }
}
