namespace JobApplyOrganizer
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.textBoxWorkDir = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTemplateDirectory = new System.Windows.Forms.Label();
            this.buttonOpenDir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxWorkDir
            // 
            this.textBoxWorkDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWorkDir.Location = new System.Drawing.Point(6, 20);
            this.textBoxWorkDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWorkDir.Name = "textBoxWorkDir";
            this.textBoxWorkDir.Size = new System.Drawing.Size(764, 30);
            this.textBoxWorkDir.TabIndex = 1;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(6, 54);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(124, 43);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonUpdate.Location = new System.Drawing.Point(18, 217);
            this.ButtonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(124, 43);
            this.ButtonUpdate.TabIndex = 3;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(148, 217);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(124, 43);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxWorkDir);
            this.groupBox1.Controls.Add(this.buttonSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 107);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Working Directory";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOpenDir);
            this.groupBox2.Controls.Add(this.labelTemplateDirectory);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Open Template Directory";
            // 
            // labelTemplateDirectory
            // 
            this.labelTemplateDirectory.AutoSize = true;
            this.labelTemplateDirectory.Location = new System.Drawing.Point(149, 35);
            this.labelTemplateDirectory.Name = "labelTemplateDirectory";
            this.labelTemplateDirectory.Size = new System.Drawing.Size(186, 20);
            this.labelTemplateDirectory.TabIndex = 0;
            this.labelTemplateDirectory.Text = "labelTemplateDirectory";
            // 
            // buttonOpenDir
            // 
            this.buttonOpenDir.Location = new System.Drawing.Point(6, 22);
            this.buttonOpenDir.Name = "buttonOpenDir";
            this.buttonOpenDir.Size = new System.Drawing.Size(124, 43);
            this.buttonOpenDir.TabIndex = 1;
            this.buttonOpenDir.Text = "Open";
            this.buttonOpenDir.UseVisualStyleBackColor = true;
            this.buttonOpenDir.Click += new System.EventHandler(this.buttonOpenDir_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 277);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxWorkDir;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOpenDir;
        private System.Windows.Forms.Label labelTemplateDirectory;
    }
}