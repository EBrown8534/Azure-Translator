namespace AzureTranslator
{
    partial class MainForm
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
            this.lblSourceLanguage = new System.Windows.Forms.Label();
            this.cbSourceLanguage = new System.Windows.Forms.ComboBox();
            this.cbDestinationLanguage = new System.Windows.Forms.ComboBox();
            this.lblDestinationLanguage = new System.Windows.Forms.Label();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSourceLanguage
            // 
            this.lblSourceLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSourceLanguage.AutoSize = true;
            this.lblSourceLanguage.Location = new System.Drawing.Point(12, 94);
            this.lblSourceLanguage.Name = "lblSourceLanguage";
            this.lblSourceLanguage.Size = new System.Drawing.Size(44, 13);
            this.lblSourceLanguage.TabIndex = 0;
            this.lblSourceLanguage.Text = "Source:";
            this.lblSourceLanguage.Visible = false;
            // 
            // cbSourceLanguage
            // 
            this.cbSourceLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSourceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceLanguage.FormattingEnabled = true;
            this.cbSourceLanguage.Items.AddRange(new object[] {
            "Auto"});
            this.cbSourceLanguage.Location = new System.Drawing.Point(81, 91);
            this.cbSourceLanguage.Name = "cbSourceLanguage";
            this.cbSourceLanguage.Size = new System.Drawing.Size(265, 21);
            this.cbSourceLanguage.TabIndex = 1;
            this.cbSourceLanguage.Visible = false;
            // 
            // cbDestinationLanguage
            // 
            this.cbDestinationLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestinationLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationLanguage.FormattingEnabled = true;
            this.cbDestinationLanguage.Location = new System.Drawing.Point(81, 118);
            this.cbDestinationLanguage.Name = "cbDestinationLanguage";
            this.cbDestinationLanguage.Size = new System.Drawing.Size(265, 21);
            this.cbDestinationLanguage.TabIndex = 3;
            // 
            // lblDestinationLanguage
            // 
            this.lblDestinationLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDestinationLanguage.AutoSize = true;
            this.lblDestinationLanguage.Location = new System.Drawing.Point(12, 121);
            this.lblDestinationLanguage.Name = "lblDestinationLanguage";
            this.lblDestinationLanguage.Size = new System.Drawing.Size(63, 13);
            this.lblDestinationLanguage.TabIndex = 2;
            this.lblDestinationLanguage.Text = "Destination:";
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.Location = new System.Drawing.Point(15, 145);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(331, 23);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "Translate and Paste";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // tbText
            // 
            this.tbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbText.Location = new System.Drawing.Point(12, 12);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(334, 100);
            this.tbText.TabIndex = 5;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnTranslate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 180);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.cbDestinationLanguage);
            this.Controls.Add(this.lblDestinationLanguage);
            this.Controls.Add(this.cbSourceLanguage);
            this.Controls.Add(this.lblSourceLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Translate Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourceLanguage;
        private System.Windows.Forms.ComboBox cbSourceLanguage;
        private System.Windows.Forms.ComboBox cbDestinationLanguage;
        private System.Windows.Forms.Label lblDestinationLanguage;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.TextBox tbText;
    }
}

