namespace ReadMe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MoodTextBox = new TextBox();
            GenreTextBox = new TextBox();
            lblBookkMood = new Label();
            label1 = new Label();
            listBox1 = new ListBox();
            SearchButton = new Button();
            TitleTextBox = new TextBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // MoodTextBox
            // 
            MoodTextBox.Location = new Point(238, 32);
            MoodTextBox.Name = "MoodTextBox";
            MoodTextBox.Size = new Size(100, 23);
            MoodTextBox.TabIndex = 0;
            // 
            // GenreTextBox
            // 
            GenreTextBox.Location = new Point(132, 32);
            GenreTextBox.Name = "GenreTextBox";
            GenreTextBox.Size = new Size(100, 23);
            GenreTextBox.TabIndex = 0;
            // 
            // lblBookkMood
            // 
            lblBookkMood.AutoSize = true;
            lblBookkMood.Location = new Point(238, 14);
            lblBookkMood.Name = "lblBookkMood";
            lblBookkMood.Size = new Size(42, 15);
            lblBookkMood.TabIndex = 1;
            lblBookkMood.Text = "Mood:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 14);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Genere:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(26, 61);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(743, 349);
            listBox1.TabIndex = 2;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(694, 32);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 23);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "Vai";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(26, 32);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(100, 23);
            TitleTextBox.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(26, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SearchButton);
            Controls.Add(listBox1);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(TitleTextBox);
            Controls.Add(lblBookkMood);
            Controls.Add(GenreTextBox);
            Controls.Add(MoodTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "ReadMe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MoodTextBox;
        private TextBox GenreTextBox;
        private Label lblBookkMood;
        private Label label1;
        private ListBox listBox1;
        private Button SearchButton;
        private TextBox TitleTextBox;
        private Label lblTitle;
    }
}
