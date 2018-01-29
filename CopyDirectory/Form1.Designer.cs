namespace CopyDirectory
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceDirectoryButton = new System.Windows.Forms.Button();
            this.targetDirectoryButton = new System.Windows.Forms.Button();
            this.sourceDirectoryLabel = new System.Windows.Forms.Label();
            this.targetDirectoryLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target directory";
            // 
            // sourceDirectoryButton
            // 
            this.sourceDirectoryButton.Location = new System.Drawing.Point(104, 13);
            this.sourceDirectoryButton.Name = "sourceDirectoryButton";
            this.sourceDirectoryButton.Size = new System.Drawing.Size(145, 23);
            this.sourceDirectoryButton.TabIndex = 2;
            this.sourceDirectoryButton.Text = "Pick Source Directory";
            this.sourceDirectoryButton.UseVisualStyleBackColor = true;
            this.sourceDirectoryButton.Click += new System.EventHandler(this.sourceDirectoryButton_Click);
            // 
            // targetDirectoryButton
            // 
            this.targetDirectoryButton.Location = new System.Drawing.Point(104, 43);
            this.targetDirectoryButton.Name = "targetDirectoryButton";
            this.targetDirectoryButton.Size = new System.Drawing.Size(145, 23);
            this.targetDirectoryButton.TabIndex = 3;
            this.targetDirectoryButton.Text = "Pick Target Directory";
            this.targetDirectoryButton.UseVisualStyleBackColor = true;
            this.targetDirectoryButton.Click += new System.EventHandler(this.targetDirectoryButton_Click);
            // 
            // sourceDirectoryLabel
            // 
            this.sourceDirectoryLabel.AutoSize = true;
            this.sourceDirectoryLabel.Location = new System.Drawing.Point(256, 18);
            this.sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            this.sourceDirectoryLabel.Size = new System.Drawing.Size(0, 13);
            this.sourceDirectoryLabel.TabIndex = 4;
            // 
            // targetDirectoryLabel
            // 
            this.targetDirectoryLabel.AutoSize = true;
            this.targetDirectoryLabel.Location = new System.Drawing.Point(256, 48);
            this.targetDirectoryLabel.Name = "targetDirectoryLabel";
            this.targetDirectoryLabel.Size = new System.Drawing.Size(0, 13);
            this.targetDirectoryLabel.TabIndex = 5;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(86, 87);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(16, 116);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(240, 186);
            this.listBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 322);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.targetDirectoryLabel);
            this.Controls.Add(this.sourceDirectoryLabel);
            this.Controls.Add(this.targetDirectoryButton);
            this.Controls.Add(this.sourceDirectoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sourceDirectoryButton;
        private System.Windows.Forms.Button targetDirectoryButton;
        private System.Windows.Forms.Label sourceDirectoryLabel;
        private System.Windows.Forms.Label targetDirectoryLabel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.ListBox listBox;
    }
}

