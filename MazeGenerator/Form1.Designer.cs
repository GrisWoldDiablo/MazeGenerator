
namespace MazeGenerator
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
            this.GenerateButton = new System.Windows.Forms.Button();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.WalkButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(12, 12);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // BoardPanel
            // 
            this.BoardPanel.Location = new System.Drawing.Point(12, 41);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(403, 432);
            this.BoardPanel.TabIndex = 2;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            // 
            // WalkButton
            // 
            this.WalkButton.Location = new System.Drawing.Point(93, 12);
            this.WalkButton.Name = "WalkButton";
            this.WalkButton.Size = new System.Drawing.Size(75, 23);
            this.WalkButton.TabIndex = 3;
            this.WalkButton.Text = "Walk";
            this.WalkButton.UseVisualStyleBackColor = true;
            this.WalkButton.Click += new System.EventHandler(this.WalkButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(340, 12);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 485);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.WalkButton);
            this.Controls.Add(this.BoardPanel);
            this.Controls.Add(this.GenerateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Button WalkButton;
        private System.Windows.Forms.Button ClearButton;
    }
}

