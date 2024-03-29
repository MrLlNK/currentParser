﻿namespace currentParserClient
{
    partial class currentParserGUI
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
            buttonParse = new Button();
            dollarLabel = new Label();
            currentStringTextbox = new TextBox();
            currentTextLabel = new Label();
            currentTextbox = new TextBox();
            SuspendLayout();
            // 
            // buttonParse
            // 
            buttonParse.Location = new Point(288, 29);
            buttonParse.Name = "buttonParse";
            buttonParse.Size = new Size(146, 28);
            buttonParse.TabIndex = 1;
            buttonParse.Text = "Translate to Text";
            buttonParse.UseVisualStyleBackColor = true;
            buttonParse.Click += buttonParse_Click;
            // 
            // dollarLabel
            // 
            dollarLabel.AutoSize = true;
            dollarLabel.Location = new Point(245, 32);
            dollarLabel.Name = "dollarLabel";
            dollarLabel.Size = new Size(17, 20);
            dollarLabel.TabIndex = 2;
            dollarLabel.Text = "$";
            // 
            // currentStringTextbox
            // 
            currentStringTextbox.Location = new Point(27, 88);
            currentStringTextbox.Multiline = true;
            currentStringTextbox.Name = "currentStringTextbox";
            currentStringTextbox.ReadOnly = true;
            currentStringTextbox.Size = new Size(429, 58);
            currentStringTextbox.TabIndex = 3;
            // 
            // currentTextLabel
            // 
            currentTextLabel.AutoSize = true;
            currentTextLabel.Location = new Point(27, 71);
            currentTextLabel.Name = "currentTextLabel";
            currentTextLabel.Size = new Size(107, 20);
            currentTextLabel.TabIndex = 5;
            currentTextLabel.Text = "Current in Text:";
            // 
            // currentTextbox
            // 
            currentTextbox.Location = new Point(27, 29);
            currentTextbox.Name = "currentTextbox";
            currentTextbox.Size = new Size(212, 26);
            currentTextbox.TabIndex = 7;
            currentTextbox.Text = "Please write the current";
            currentTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            // 
            // currentParserGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 166);
            Controls.Add(currentTextbox);
            Controls.Add(currentTextLabel);
            Controls.Add(currentStringTextbox);
            Controls.Add(dollarLabel);
            Controls.Add(buttonParse);
            Name = "currentParserGUI";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonParse;
        private Label dollarLabel;
        private TextBox currentStringTextbox;
        private Label currentTextLabel;
        private TextBox currentTextbox;
    }
}
