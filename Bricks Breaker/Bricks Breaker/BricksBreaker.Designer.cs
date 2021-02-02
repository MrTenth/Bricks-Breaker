
namespace Bricks_Breaker
{
    partial class BricksBreaker
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BricksBreaker));
            this.GameTitle = new System.Windows.Forms.Label();
            this.GameStart = new System.Windows.Forms.Label();
            this.Hint = new System.Windows.Forms.Label();
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.Action = new System.Windows.Forms.Timer(this.components);
            this.Suggestion = new System.Windows.Forms.Label();
            this.ScoreBoard = new System.Windows.Forms.Label();
            this.ScoreRec = new System.Windows.Forms.Label();
            this.BestPlayers = new System.Windows.Forms.TextBox();
            this.PlayersTitle = new System.Windows.Forms.Label();
            this.GameTime = new System.Windows.Forms.Label();
            this.GameOverTitle = new System.Windows.Forms.Label();
            this.NameRecTitle = new System.Windows.Forms.Label();
            this.NameRec = new System.Windows.Forms.TextBox();
            this.NameConfirm = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTitle
            // 
            this.GameTitle.BackColor = System.Drawing.Color.Transparent;
            this.GameTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTitle.Location = new System.Drawing.Point(12, 80);
            this.GameTitle.Name = "GameTitle";
            this.GameTitle.Size = new System.Drawing.Size(408, 91);
            this.GameTitle.TabIndex = 0;
            this.GameTitle.Text = "Bricks Breaker";
            this.GameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameTitle.Visible = false;
            // 
            // GameStart
            // 
            this.GameStart.BackColor = System.Drawing.Color.Transparent;
            this.GameStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GameStart.Font = new System.Drawing.Font("Matura MT Script Capitals", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameStart.Location = new System.Drawing.Point(12, 418);
            this.GameStart.Name = "GameStart";
            this.GameStart.Size = new System.Drawing.Size(408, 40);
            this.GameStart.TabIndex = 1;
            this.GameStart.Text = "Game Start!";
            this.GameStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameStart.Visible = false;
            this.GameStart.Click += new System.EventHandler(this.GameStart_Click);
            // 
            // Hint
            // 
            this.Hint.BackColor = System.Drawing.Color.Transparent;
            this.Hint.Font = new System.Drawing.Font("Matura MT Script Capitals", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hint.Location = new System.Drawing.Point(12, 530);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(408, 23);
            this.Hint.TabIndex = 2;
            this.Hint.Text = "Hint: Use A and D to MOVE your board!";
            this.Hint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Hint.Visible = false;
            // 
            // GameBox
            // 
            this.GameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GameBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameBox.BackgroundImage")));
            this.GameBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameBox.Location = new System.Drawing.Point(0, 0);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(432, 573);
            this.GameBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameBox.TabIndex = 3;
            this.GameBox.TabStop = false;
            this.GameBox.Visible = false;
            this.GameBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBox_Paint);
            // 
            // Action
            // 
            this.Action.Tick += new System.EventHandler(this.Action_Tick);
            // 
            // Suggestion
            // 
            this.Suggestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Suggestion.Font = new System.Drawing.Font("Matura MT Script Capitals", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Suggestion.Location = new System.Drawing.Point(16, 296);
            this.Suggestion.Name = "Suggestion";
            this.Suggestion.Size = new System.Drawing.Size(404, 28);
            this.Suggestion.TabIndex = 4;
            this.Suggestion.Text = "Press SPACE to start BREAK bricks!!!";
            this.Suggestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ScoreBoard.Location = new System.Drawing.Point(24, 441);
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.Size = new System.Drawing.Size(105, 26);
            this.ScoreBoard.TabIndex = 5;
            this.ScoreBoard.Text = "SCORE";
            this.ScoreBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreRec
            // 
            this.ScoreRec.BackColor = System.Drawing.Color.Silver;
            this.ScoreRec.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreRec.Location = new System.Drawing.Point(24, 477);
            this.ScoreRec.Name = "ScoreRec";
            this.ScoreRec.Size = new System.Drawing.Size(105, 34);
            this.ScoreRec.TabIndex = 6;
            this.ScoreRec.Text = "00000";
            this.ScoreRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BestPlayers
            // 
            this.BestPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BestPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BestPlayers.Enabled = false;
            this.BestPlayers.Location = new System.Drawing.Point(167, 477);
            this.BestPlayers.Multiline = true;
            this.BestPlayers.Name = "BestPlayers";
            this.BestPlayers.ReadOnly = true;
            this.BestPlayers.Size = new System.Drawing.Size(243, 76);
            this.BestPlayers.TabIndex = 7;
            // 
            // PlayersTitle
            // 
            this.PlayersTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PlayersTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayersTitle.Location = new System.Drawing.Point(167, 434);
            this.PlayersTitle.Name = "PlayersTitle";
            this.PlayersTitle.Size = new System.Drawing.Size(243, 40);
            this.PlayersTitle.TabIndex = 8;
            this.PlayersTitle.Text = "BestPlayers";
            this.PlayersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameTime
            // 
            this.GameTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GameTime.Location = new System.Drawing.Point(24, 527);
            this.GameTime.Name = "GameTime";
            this.GameTime.Size = new System.Drawing.Size(105, 26);
            this.GameTime.TabIndex = 9;
            this.GameTime.Text = "0:00:00";
            this.GameTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameOverTitle
            // 
            this.GameOverTitle.BackColor = System.Drawing.Color.PapayaWhip;
            this.GameOverTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameOverTitle.Font = new System.Drawing.Font("Matura MT Script Capitals", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverTitle.Location = new System.Drawing.Point(24, 145);
            this.GameOverTitle.Name = "GameOverTitle";
            this.GameOverTitle.Size = new System.Drawing.Size(386, 123);
            this.GameOverTitle.TabIndex = 10;
            this.GameOverTitle.Text = "GAME OVER";
            this.GameOverTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameRecTitle
            // 
            this.NameRecTitle.BackColor = System.Drawing.Color.PapayaWhip;
            this.NameRecTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameRecTitle.Location = new System.Drawing.Point(24, 268);
            this.NameRecTitle.Name = "NameRecTitle";
            this.NameRecTitle.Size = new System.Drawing.Size(386, 85);
            this.NameRecTitle.TabIndex = 11;
            this.NameRecTitle.Text = "Congratulations! You have broken somebody\'s record. Would you like to leave your " +
    "name?";
            this.NameRecTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameRec
            // 
            this.NameRec.Location = new System.Drawing.Point(24, 356);
            this.NameRec.Name = "NameRec";
            this.NameRec.Size = new System.Drawing.Size(283, 34);
            this.NameRec.TabIndex = 12;
            // 
            // NameConfirm
            // 
            this.NameConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NameConfirm.Location = new System.Drawing.Point(313, 356);
            this.NameConfirm.Name = "NameConfirm";
            this.NameConfirm.Size = new System.Drawing.Size(97, 34);
            this.NameConfirm.TabIndex = 13;
            this.NameConfirm.Text = "Confirm";
            this.NameConfirm.UseVisualStyleBackColor = true;
            this.NameConfirm.Click += new System.EventHandler(this.NameConfirm_Click);
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.Location = new System.Drawing.Point(173, 318);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 32);
            this.Close.TabIndex = 15;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // BricksBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 573);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.NameConfirm);
            this.Controls.Add(this.NameRec);
            this.Controls.Add(this.NameRecTitle);
            this.Controls.Add(this.GameOverTitle);
            this.Controls.Add(this.GameTime);
            this.Controls.Add(this.PlayersTitle);
            this.Controls.Add(this.BestPlayers);
            this.Controls.Add(this.ScoreRec);
            this.Controls.Add(this.ScoreBoard);
            this.Controls.Add(this.Suggestion);
            this.Controls.Add(this.GameBox);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.GameStart);
            this.Controls.Add(this.GameTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "BricksBreaker";
            this.Text = "Bricks Breaker";
            this.Load += new System.EventHandler(this.BricksBreaker_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BricksBreaker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameTitle;
        private System.Windows.Forms.Label GameStart;
        private System.Windows.Forms.Label Hint;
        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Timer Action;
        private System.Windows.Forms.Label Suggestion;
        private System.Windows.Forms.Label ScoreBoard;
        private System.Windows.Forms.Label ScoreRec;
        private System.Windows.Forms.TextBox BestPlayers;
        private System.Windows.Forms.Label PlayersTitle;
        private System.Windows.Forms.Label GameTime;
        private System.Windows.Forms.Label GameOverTitle;
        private System.Windows.Forms.Label NameRecTitle;
        private System.Windows.Forms.TextBox NameRec;
        private System.Windows.Forms.Button NameConfirm;
        private System.Windows.Forms.Button Close;
    }
}

