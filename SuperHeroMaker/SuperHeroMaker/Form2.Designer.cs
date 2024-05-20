namespace SuperHeroMaker
{
    // Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBox1;
        private TextBox summaryTextBox;

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
            this.listBox1 = new ListBox();
            this.summaryTextBox = new TextBox();

            // listBox1
            this.listBox1.Location = new Point(20, 20);
            this.listBox1.Width = 200;
            this.listBox1.Height = 400;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new EventHandler(this.ListBox1_SelectedIndexChanged);

            // summaryTextBox
            this.summaryTextBox.Location = new Point(250, 20);
            this.summaryTextBox.Width = 300;
            this.summaryTextBox.Height = 400;
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.Name = "summaryTextBox";

            // Form2
            this.ClientSize = new Size(600, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.summaryTextBox);
            this.Text = "Hero List";
            this.FormClosed += new FormClosedEventHandler(this.Form2_FormClosed);
        }

        #endregion
    }
}
