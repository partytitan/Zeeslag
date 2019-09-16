namespace Zeeslag
{
    partial class Game
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
            this.placePlayer1 = new System.Windows.Forms.Button();
            this.placePlayer2 = new System.Windows.Forms.Button();
            this.lbResponse = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // placePlayer1
            // 
            this.placePlayer1.Location = new System.Drawing.Point(30, 22);
            this.placePlayer1.Name = "placePlayer1";
            this.placePlayer1.Size = new System.Drawing.Size(187, 46);
            this.placePlayer1.TabIndex = 0;
            this.placePlayer1.Text = "Place player 1";
            this.placePlayer1.UseVisualStyleBackColor = true;
            this.placePlayer1.Click += new System.EventHandler(this.btnPlacePlayer1_Click);
            // 
            // placePlayer2
            // 
            this.placePlayer2.Location = new System.Drawing.Point(250, 22);
            this.placePlayer2.Name = "placePlayer2";
            this.placePlayer2.Size = new System.Drawing.Size(193, 46);
            this.placePlayer2.TabIndex = 1;
            this.placePlayer2.Text = "Place player 2";
            this.placePlayer2.UseVisualStyleBackColor = true;
            this.placePlayer2.Click += new System.EventHandler(this.btnPlacePlayer2_Click);
            // 
            // Response
            // 
            this.lbResponse.AutoSize = true;
            this.lbResponse.Location = new System.Drawing.Point(711, 31);
            this.lbResponse.Name = "Response";
            this.lbResponse.Size = new System.Drawing.Size(0, 29);
            this.lbResponse.TabIndex = 4;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(460, 22);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(157, 46);
            this.start.TabIndex = 5;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2644, 1255);
            this.Controls.Add(this.start);
            this.Controls.Add(this.lbResponse);
            this.Controls.Add(this.placePlayer2);
            this.Controls.Add(this.placePlayer1);
            this.Name = "Game";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.btnGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button placePlayer1;
        private System.Windows.Forms.Button placePlayer2;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.Button start;
    }
}

