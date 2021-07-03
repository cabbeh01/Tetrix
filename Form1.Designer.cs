namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pMenu = new System.Windows.Forms.Panel();
            this.btnStarta = new System.Windows.Forms.PictureBox();
            this.btnAvsluta = new System.Windows.Forms.PictureBox();
            this.pGame = new System.Windows.Forms.DoubleBufferedPanel();
            this.pGameover = new System.Windows.Forms.Panel();
            this.pbxExitmenu = new System.Windows.Forms.PictureBox();
            this.pbxRestart = new System.Windows.Forms.PictureBox();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.lblScoreGameover = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStarta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvsluta)).BeginInit();
            this.pGame.SuspendLayout();
            this.pGameover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExitmenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // pMenu
            // 
            this.pMenu.BackgroundImage = global::Tetris.Properties.Resources.background;
            this.pMenu.Controls.Add(this.btnStarta);
            this.pMenu.Controls.Add(this.btnAvsluta);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(714, 712);
            this.pMenu.TabIndex = 4;
            // 
            // btnStarta
            // 
            this.btnStarta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStarta.Image = global::Tetris.Properties.Resources.starta;
            this.btnStarta.Location = new System.Drawing.Point(263, 327);
            this.btnStarta.Name = "btnStarta";
            this.btnStarta.Size = new System.Drawing.Size(200, 80);
            this.btnStarta.TabIndex = 4;
            this.btnStarta.TabStop = false;
            this.btnStarta.Click += new System.EventHandler(this.btnStarta_Click_1);
            // 
            // btnAvsluta
            // 
            this.btnAvsluta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvsluta.Image = global::Tetris.Properties.Resources.avsluta;
            this.btnAvsluta.Location = new System.Drawing.Point(263, 426);
            this.btnAvsluta.Name = "btnAvsluta";
            this.btnAvsluta.Size = new System.Drawing.Size(200, 80);
            this.btnAvsluta.TabIndex = 3;
            this.btnAvsluta.TabStop = false;
            this.btnAvsluta.Click += new System.EventHandler(this.btnAvsluta_Click);
            // 
            // pGame
            // 
            this.pGame.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pGame.BackgroundImage = global::Tetris.Properties.Resources.ingame;
            this.pGame.Controls.Add(this.pGameover);
            this.pGame.Controls.Add(this.lblLevel);
            this.pGame.Controls.Add(this.lblScore);
            this.pGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGame.Location = new System.Drawing.Point(0, 0);
            this.pGame.Name = "pGame";
            this.pGame.Size = new System.Drawing.Size(714, 712);
            this.pGame.TabIndex = 4;
            this.pGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pGame_Paint);
            // 
            // pGameover
            // 
            this.pGameover.BackgroundImage = global::Tetris.Properties.Resources.gameover;
            this.pGameover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGameover.Controls.Add(this.pbxExitmenu);
            this.pGameover.Controls.Add(this.pbxRestart);
            this.pGameover.Controls.Add(this.lblHighscore);
            this.pGameover.Controls.Add(this.lblScoreGameover);
            this.pGameover.Location = new System.Drawing.Point(180, 206);
            this.pGameover.Name = "pGameover";
            this.pGameover.Size = new System.Drawing.Size(400, 400);
            this.pGameover.TabIndex = 2;
            // 
            // pbxExitmenu
            // 
            this.pbxExitmenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxExitmenu.Image = global::Tetris.Properties.Resources.exit;
            this.pbxExitmenu.Location = new System.Drawing.Point(33, 305);
            this.pbxExitmenu.Name = "pbxExitmenu";
            this.pbxExitmenu.Size = new System.Drawing.Size(150, 80);
            this.pbxExitmenu.TabIndex = 6;
            this.pbxExitmenu.TabStop = false;
            this.pbxExitmenu.Click += new System.EventHandler(this.PbxExitmenu_Click);
            // 
            // pbxRestart
            // 
            this.pbxRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRestart.Image = global::Tetris.Properties.Resources.restart;
            this.pbxRestart.Location = new System.Drawing.Point(216, 305);
            this.pbxRestart.Name = "pbxRestart";
            this.pbxRestart.Size = new System.Drawing.Size(150, 80);
            this.pbxRestart.TabIndex = 5;
            this.pbxRestart.TabStop = false;
            this.pbxRestart.Click += new System.EventHandler(this.PbxRestart_Click);
            // 
            // lblHighscore
            // 
            this.lblHighscore.BackColor = System.Drawing.Color.Transparent;
            this.lblHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblHighscore.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHighscore.Location = new System.Drawing.Point(33, 241);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(332, 29);
            this.lblHighscore.TabIndex = 2;
            this.lblHighscore.Text = "0";
            this.lblHighscore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblScoreGameover
            // 
            this.lblScoreGameover.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreGameover.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.lblScoreGameover.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScoreGameover.Location = new System.Drawing.Point(33, 164);
            this.lblScoreGameover.Name = "lblScoreGameover";
            this.lblScoreGameover.Size = new System.Drawing.Size(333, 36);
            this.lblScoreGameover.TabIndex = 1;
            this.lblScoreGameover.Text = "0";
            this.lblScoreGameover.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblLevel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLevel.Location = new System.Drawing.Point(457, 467);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(26, 29);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblScore.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScore.Location = new System.Drawing.Point(457, 307);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(26, 29);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 712);
            this.Controls.Add(this.pGame);
            this.Controls.Add(this.pMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tetrix";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.pMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnStarta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAvsluta)).EndInit();
            this.pGame.ResumeLayout(false);
            this.pGame.PerformLayout();
            this.pGameover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxExitmenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRestart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnAvsluta;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.DoubleBufferedPanel pGame;
        private System.Windows.Forms.PictureBox btnStarta;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel pGameover;
        private System.Windows.Forms.Label lblHighscore;
        private System.Windows.Forms.Label lblScoreGameover;
        private System.Windows.Forms.PictureBox pbxExitmenu;
        private System.Windows.Forms.PictureBox pbxRestart;
    }
}

