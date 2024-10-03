namespace JobApplyOrganizer
{
    partial class MainJobApplyOrganizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainJobApplyOrganizer));
            this.listViewJobs = new System.Windows.Forms.ListView();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonMoveToArkiv = new System.Windows.Forms.Button();
            this.textBoxJobTitle = new System.Windows.Forms.TextBox();
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.ButtonSettings = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonOpenHTML = new System.Windows.Forms.Button();
            this.labelJobTitle = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelCreationDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewJobs
            // 
            this.listViewJobs.HideSelection = false;
            this.listViewJobs.Location = new System.Drawing.Point(187, 114);
            this.listViewJobs.Name = "listViewJobs";
            this.listViewJobs.Size = new System.Drawing.Size(597, 322);
            this.listViewJobs.TabIndex = 0;
            this.listViewJobs.UseCompatibleStateImageBehavior = false;
            // 
            // ButtonNew
            // 
            this.ButtonNew.Location = new System.Drawing.Point(12, 12);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(152, 48);
            this.ButtonNew.TabIndex = 1;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(12, 66);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(152, 48);
            this.ButtonUpdate.TabIndex = 2;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonMoveToArkiv
            // 
            this.ButtonMoveToArkiv.Location = new System.Drawing.Point(12, 280);
            this.ButtonMoveToArkiv.Name = "ButtonMoveToArkiv";
            this.ButtonMoveToArkiv.Size = new System.Drawing.Size(152, 48);
            this.ButtonMoveToArkiv.TabIndex = 3;
            this.ButtonMoveToArkiv.Text = "Move to archive";
            this.ButtonMoveToArkiv.UseVisualStyleBackColor = true;
            this.ButtonMoveToArkiv.Click += new System.EventHandler(this.ButtonMoveToArkiv_Click);
            // 
            // textBoxJobTitle
            // 
            this.textBoxJobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxJobTitle.Location = new System.Drawing.Point(187, 30);
            this.textBoxJobTitle.Name = "textBoxJobTitle";
            this.textBoxJobTitle.Size = new System.Drawing.Size(234, 30);
            this.textBoxJobTitle.TabIndex = 4;
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCompany.Location = new System.Drawing.Point(427, 30);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(357, 30);
            this.textBoxCompany.TabIndex = 5;
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Location = new System.Drawing.Point(12, 334);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(152, 48);
            this.ButtonSettings.TabIndex = 6;
            this.ButtonSettings.Text = "Settings";
            this.ButtonSettings.UseVisualStyleBackColor = true;
            this.ButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(12, 388);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(152, 48);
            this.ButtonExit.TabIndex = 7;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonOpenHTML
            // 
            this.ButtonOpenHTML.Location = new System.Drawing.Point(12, 120);
            this.ButtonOpenHTML.Name = "ButtonOpenHTML";
            this.ButtonOpenHTML.Size = new System.Drawing.Size(152, 48);
            this.ButtonOpenHTML.TabIndex = 8;
            this.ButtonOpenHTML.Text = "Open HTML";
            this.ButtonOpenHTML.UseVisualStyleBackColor = true;
            this.ButtonOpenHTML.Click += new System.EventHandler(this.ButtonOpenHTML_Click);
            // 
            // labelJobTitle
            // 
            this.labelJobTitle.AutoSize = true;
            this.labelJobTitle.Location = new System.Drawing.Point(184, 12);
            this.labelJobTitle.Name = "labelJobTitle";
            this.labelJobTitle.Size = new System.Drawing.Size(53, 16);
            this.labelJobTitle.TabIndex = 9;
            this.labelJobTitle.Text = "Job title";
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Location = new System.Drawing.Point(424, 12);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(65, 16);
            this.labelCompany.TabIndex = 10;
            this.labelCompany.Text = "Company";
            // 
            // labelCreationDate
            // 
            this.labelCreationDate.AutoSize = true;
            this.labelCreationDate.Location = new System.Drawing.Point(184, 91);
            this.labelCreationDate.Name = "labelCreationDate";
            this.labelCreationDate.Size = new System.Drawing.Size(87, 16);
            this.labelCreationDate.TabIndex = 11;
            this.labelCreationDate.Text = "Creation date";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(307, 91);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 16);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name";
            // 
            // MainJobApplyOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCreationDate);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelJobTitle);
            this.Controls.Add(this.ButtonOpenHTML);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSettings);
            this.Controls.Add(this.textBoxCompany);
            this.Controls.Add(this.textBoxJobTitle);
            this.Controls.Add(this.ButtonMoveToArkiv);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ButtonNew);
            this.Controls.Add(this.listViewJobs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainJobApplyOrganizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobApplyOrganizer";
            this.Load += new System.EventHandler(this.MainJobApplyOrganizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewJobs;
        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonMoveToArkiv;
        private System.Windows.Forms.TextBox textBoxJobTitle;
        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.Button ButtonSettings;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonOpenHTML;
        private System.Windows.Forms.Label labelJobTitle;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelCreationDate;
        private System.Windows.Forms.Label labelName;
    }
}

