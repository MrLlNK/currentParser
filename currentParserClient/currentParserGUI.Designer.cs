namespace currentParserClient
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
            currentTextBox = new TextBox();
            buttonParse = new Button();
            dollarLabel = new Label();
            currentStringTextbox = new TextBox();
            textBox2 = new TextBox();
            currentTextLabel = new Label();
            labelInformation = new Label();
            SuspendLayout();
            // 
            // currentTextBox
            // 
            currentTextBox.Location = new Point(27, 27);
            currentTextBox.Name = "currentTextBox";
            currentTextBox.RightToLeft = RightToLeft.Yes;
            currentTextBox.Size = new Size(214, 26);
            currentTextBox.TabIndex = 0;
            currentTextBox.Text = "Please write the current";
            // 
            // buttonParse
            // 
            buttonParse.Location = new Point(310, 25);
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
            currentStringTextbox.Location = new Point(27, 94);
            currentStringTextbox.Multiline = true;
            currentStringTextbox.Name = "currentStringTextbox";
            currentStringTextbox.ReadOnly = true;
            currentStringTextbox.Size = new Size(429, 58);
            currentStringTextbox.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(27, 187);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(429, 78);
            textBox2.TabIndex = 4;
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
            // labelInformation
            // 
            labelInformation.AutoSize = true;
            labelInformation.Location = new Point(27, 164);
            labelInformation.Name = "labelInformation";
            labelInformation.Size = new Size(90, 20);
            labelInformation.TabIndex = 6;
            labelInformation.Text = "Information:";
            // 
            // currentParserGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 291);
            Controls.Add(labelInformation);
            Controls.Add(currentTextLabel);
            Controls.Add(textBox2);
            Controls.Add(currentStringTextbox);
            Controls.Add(dollarLabel);
            Controls.Add(buttonParse);
            Controls.Add(currentTextBox);
            Name = "currentParserGUI";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox currentTextBox;
        private Button buttonParse;
        private Label dollarLabel;
        private TextBox currentStringTextbox;
        private TextBox textBox2;
        private Label currentTextLabel;
        private Label labelInformation;
    }
}
