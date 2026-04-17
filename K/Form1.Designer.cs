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
            btnTake.Location = new Point(189, 296);
            btnTake.Name = "btnTake";
            btnTake.Size = new Size(94, 29);
            btnTake.TabIndex = 1;
            btnTake.Text = "Забрать";
            btnTake.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(477, 296);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(94, 29);
            btnFinish.TabIndex = 2;
            btnFinish.Text = "Бито";
            btnFinish.UseVisualStyleBackColor = true;
            // 
            // firstPlayerHand
            // 
            firstPlayerHand.FormattingEnabled = true;
            firstPlayerHand.Location = new Point(306, 343);
            firstPlayerHand.Name = "firstPlayerHand";
            firstPlayerHand.Size = new Size(150, 104);
            firstPlayerHand.TabIndex = 3;
            firstPlayerHand.SelectedIndexChanged += firstPlayerHand_SelectedIndexChanged;
            // 
            // firstComputerHand
            // 
            firstComputerHand.FormattingEnabled = true;
            firstComputerHand.Location = new Point(306, -1);
            firstComputerHand.Name = "firstComputerHand";
            firstComputerHand.Size = new Size(150, 104);
            firstComputerHand.TabIndex = 4;
            // 
            // firstTable
            // 
            firstTable.FormattingEnabled = true;
            firstTable.Location = new Point(306, 151);
            firstTable.Name = "firstTable";
            firstTable.Size = new Size(150, 104);
            firstTable.TabIndex = 5;
            firstTable.SelectedIndexChanged += firstTable_SelectedIndexChanged;
            // 
            // btnAttack
            // 
            btnAttack.Location = new Point(332, 296);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(94, 29);
            btnAttack.TabIndex = 6;
            btnAttack.Text = "Ход";
            btnAttack.UseVisualStyleBackColor = true;
            btnAttack.Click += btnAttack_Click;
            // 
            // lblTrump
            // 
            lblTrump.AutoSize = true;
            lblTrump.Location = new Point(716, 107);
            lblTrump.Name = "lblTrump";
            lblTrump.Size = new Size(62, 20);
            lblTrump.TabIndex = 7;
            lblTrump.Text = "Козырь";
            // 
            // lblDeck
            // 
            lblDeck.AutoSize = true;
            lblDeck.Location = new Point(716, 153);
            lblDeck.Name = "lblDeck";
            lblDeck.Size = new Size(60, 20);
            lblDeck.TabIndex = 8;
            lblDeck.Text = "Колода";
            lblDeck.Click += lblDeck_Click;
            // 
            // lblTurn
            // 
            lblTurn.AutoSize = true;
            lblTurn.Location = new Point(716, 198);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(50, 20);
            lblTurn.TabIndex = 9;
            lblTurn.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "Form1";
            Text = "Form1";
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
    }
}
