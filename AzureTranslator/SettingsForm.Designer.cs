namespace AzureTranslator
{
    partial class SettingsForm
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
            this.txtAzureCognitiveServicesTextTranslationApiKey = new System.Windows.Forms.TextBox();
            this.lblAzureCognitiveServicesTextTranslationApiKey = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblIgnoredLanguages = new System.Windows.Forms.Label();
            this.lvDisabledLanguages = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtAzureCognitiveServicesTextTranslationApiKey
            // 
            this.txtAzureCognitiveServicesTextTranslationApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAzureCognitiveServicesTextTranslationApiKey.Location = new System.Drawing.Point(263, 12);
            this.txtAzureCognitiveServicesTextTranslationApiKey.Name = "txtAzureCognitiveServicesTextTranslationApiKey";
            this.txtAzureCognitiveServicesTextTranslationApiKey.Size = new System.Drawing.Size(223, 20);
            this.txtAzureCognitiveServicesTextTranslationApiKey.TabIndex = 0;
            // 
            // lblAzureCognitiveServicesTextTranslationApiKey
            // 
            this.lblAzureCognitiveServicesTextTranslationApiKey.AutoSize = true;
            this.lblAzureCognitiveServicesTextTranslationApiKey.Location = new System.Drawing.Point(12, 15);
            this.lblAzureCognitiveServicesTextTranslationApiKey.Name = "lblAzureCognitiveServicesTextTranslationApiKey";
            this.lblAzureCognitiveServicesTextTranslationApiKey.Size = new System.Drawing.Size(245, 13);
            this.lblAzureCognitiveServicesTextTranslationApiKey.TabIndex = 5;
            this.lblAzureCognitiveServicesTextTranslationApiKey.Text = "Azure Cognitive Services Text Translation API Key";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(12, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(474, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(12, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(474, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblIgnoredLanguages
            // 
            this.lblIgnoredLanguages.AutoSize = true;
            this.lblIgnoredLanguages.Location = new System.Drawing.Point(12, 41);
            this.lblIgnoredLanguages.Name = "lblIgnoredLanguages";
            this.lblIgnoredLanguages.Size = new System.Drawing.Size(99, 13);
            this.lblIgnoredLanguages.TabIndex = 4;
            this.lblIgnoredLanguages.Text = "Ignored Languages";
            // 
            // lvDisabledLanguages
            // 
            this.lvDisabledLanguages.Location = new System.Drawing.Point(117, 38);
            this.lvDisabledLanguages.Name = "lvDisabledLanguages";
            this.lvDisabledLanguages.Size = new System.Drawing.Size(369, 370);
            this.lvDisabledLanguages.TabIndex = 1;
            this.lvDisabledLanguages.UseCompatibleStateImageBehavior = false;
            this.lvDisabledLanguages.View = System.Windows.Forms.View.List;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 478);
            this.Controls.Add(this.lvDisabledLanguages);
            this.Controls.Add(this.lblIgnoredLanguages);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAzureCognitiveServicesTextTranslationApiKey);
            this.Controls.Add(this.txtAzureCognitiveServicesTextTranslationApiKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsForm";
            this.Text = "Settings Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAzureCognitiveServicesTextTranslationApiKey;
        private System.Windows.Forms.Label lblAzureCognitiveServicesTextTranslationApiKey;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblIgnoredLanguages;
        private System.Windows.Forms.ListView lvDisabledLanguages;
    }
}