namespace pdbAndDllCopier
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
            this.buttonCopy = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxToPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkBoxCopyDll = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonAll = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(330, 48);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 0;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(37, 51);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(287, 20);
            this.textBoxFrom.TabIndex = 1;
            this.textBoxFrom.Text = "E:\\Dev\\Fenergo\\R7.1\\WebApp\\Src";
            // 
            // textBoxToPath
            // 
            this.textBoxToPath.Location = new System.Drawing.Point(37, 25);
            this.textBoxToPath.Name = "textBoxToPath";
            this.textBoxToPath.Size = new System.Drawing.Size(287, 20);
            this.textBoxToPath.TabIndex = 2;
            this.textBoxToPath.Text = "E:\\Dev\\HSBC\\PROJECT\\Src\\UI\\WebUI\\bin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(37, 81);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(638, 394);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // checkBoxCopyDll
            // 
            this.checkBoxCopyDll.AutoSize = true;
            this.checkBoxCopyDll.Checked = true;
            this.checkBoxCopyDll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCopyDll.Location = new System.Drawing.Point(411, 54);
            this.checkBoxCopyDll.Name = "checkBoxCopyDll";
            this.checkBoxCopyDll.Size = new System.Drawing.Size(63, 17);
            this.checkBoxCopyDll.TabIndex = 5;
            this.checkBoxCopyDll.Text = "Copy dll";
            this.checkBoxCopyDll.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(37, 581);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(638, 80);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAll.Location = new System.Drawing.Point(497, 481);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(75, 23);
            this.buttonAll.TabIndex = 10;
            this.buttonAll.Text = "Select All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click_1);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Location = new System.Drawing.Point(36, 484);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(455, 20);
            this.textBoxSearch.TabIndex = 9;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Location = new System.Drawing.Point(578, 481);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 695);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBoxCopyDll);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxToPath);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.buttonCopy);
            this.Name = "Form1";
            this.Text = "PDB and DLL Copier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxToPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBoxCopyDll;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonClear;
    }
}

