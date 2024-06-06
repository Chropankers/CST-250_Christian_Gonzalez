namespace FileIOApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxPeople;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxUrl;
        private Button buttonLoad;
        private Button buttonAdd;
        private Button buttonSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxPeople = new ListBox();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxUrl = new TextBox();
            buttonLoad = new Button();
            buttonAdd = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // listBoxPeople
            // 
            listBoxPeople.FormattingEnabled = true;
            listBoxPeople.ItemHeight = 20;
            listBoxPeople.Location = new Point(12, 12);
            listBoxPeople.Name = "listBoxPeople";
            listBoxPeople.Size = new Size(360, 164);
            listBoxPeople.TabIndex = 0;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(12, 210);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(100, 27);
            textBoxFirstName.TabIndex = 1;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(118, 210);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(100, 27);
            textBoxLastName.TabIndex = 2;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(224, 210);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(148, 27);
            textBoxUrl.TabIndex = 3;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 250);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 34);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(93, 250);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 34);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(174, 250);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 34);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(384, 311);
            Controls.Add(buttonSave);
            Controls.Add(buttonAdd);
            Controls.Add(buttonLoad);
            Controls.Add(textBoxUrl);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(listBoxPeople);
            Name = "MainForm";
            Text = "Text File Data Access Demo";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
