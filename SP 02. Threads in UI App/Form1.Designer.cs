namespace SP_02._Threads_in_UI_App
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
            components = new System.ComponentModel.Container();
            countLabel = new Label();
            startButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            changeBgButton = new Button();
            SuspendLayout();
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 204);
            countLabel.Location = new Point(122, 33);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(72, 86);
            countLabel.TabIndex = 0;
            countLabel.Text = "0";
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            startButton.Location = new Point(74, 179);
            startButton.Name = "startButton";
            startButton.Size = new Size(181, 80);
            startButton.TabIndex = 1;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // changeBgButton
            // 
            changeBgButton.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            changeBgButton.Location = new Point(74, 315);
            changeBgButton.Name = "changeBgButton";
            changeBgButton.Size = new Size(181, 85);
            changeBgButton.TabIndex = 2;
            changeBgButton.Text = "Change";
            changeBgButton.UseVisualStyleBackColor = true;
            changeBgButton.Click += changeBgButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 463);
            Controls.Add(changeBgButton);
            Controls.Add(startButton);
            Controls.Add(countLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label countLabel;
        private Button startButton;
        private System.Windows.Forms.Timer timer1;
        private Button changeBgButton;
    }
}
