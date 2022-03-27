namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    partial class CompanionEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.companionDescription = new System.Windows.Forms.RichTextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.CompanionName = new System.Windows.Forms.Label();
            this.availableAbilitiesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvailableAbilitiesLabel = new System.Windows.Forms.Label();
            this.CurrentAbilitiesLabel = new System.Windows.Forms.Label();
            this.currentAbilitiesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.companionDescription);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.CompanionName);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Companion History";
            // 
            // companionDescription
            // 
            this.companionDescription.Location = new System.Drawing.Point(6, 88);
            this.companionDescription.Name = "companionDescription";
            this.companionDescription.Size = new System.Drawing.Size(196, 331);
            this.companionDescription.TabIndex = 2;
            this.companionDescription.Text = "";
            this.companionDescription.Leave += new System.EventHandler(this.companionDescription_Leave);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(54, 40);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 13);
            this.nameLabel.TabIndex = 1;
            // 
            // CompanionName
            // 
            this.CompanionName.AutoSize = true;
            this.CompanionName.Location = new System.Drawing.Point(7, 40);
            this.CompanionName.Name = "CompanionName";
            this.CompanionName.Size = new System.Drawing.Size(41, 13);
            this.CompanionName.TabIndex = 0;
            this.CompanionName.Text = "Name :";
            // 
            // availableAbilitiesList
            // 
            this.availableAbilitiesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.availableAbilitiesList.HideSelection = false;
            this.availableAbilitiesList.Location = new System.Drawing.Point(228, 40);
            this.availableAbilitiesList.Name = "availableAbilitiesList";
            this.availableAbilitiesList.Size = new System.Drawing.Size(245, 398);
            this.availableAbilitiesList.TabIndex = 1;
            this.availableAbilitiesList.UseCompatibleStateImageBehavior = false;
            this.availableAbilitiesList.View = System.Windows.Forms.View.Details;
            this.availableAbilitiesList.DoubleClick += new System.EventHandler(this.availableAbilitiesList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 240;
            // 
            // AvailableAbilitiesLabel
            // 
            this.AvailableAbilitiesLabel.AutoSize = true;
            this.AvailableAbilitiesLabel.Location = new System.Drawing.Point(228, 21);
            this.AvailableAbilitiesLabel.Name = "AvailableAbilitiesLabel";
            this.AvailableAbilitiesLabel.Size = new System.Drawing.Size(88, 13);
            this.AvailableAbilitiesLabel.TabIndex = 2;
            this.AvailableAbilitiesLabel.Text = "Available Abilities";
            // 
            // CurrentAbilitiesLabel
            // 
            this.CurrentAbilitiesLabel.AutoSize = true;
            this.CurrentAbilitiesLabel.Location = new System.Drawing.Point(543, 21);
            this.CurrentAbilitiesLabel.Name = "CurrentAbilitiesLabel";
            this.CurrentAbilitiesLabel.Size = new System.Drawing.Size(79, 13);
            this.CurrentAbilitiesLabel.TabIndex = 4;
            this.CurrentAbilitiesLabel.Text = "Current Abilities";
            // 
            // currentAbilitiesList
            // 
            this.currentAbilitiesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.currentAbilitiesList.HideSelection = false;
            this.currentAbilitiesList.Location = new System.Drawing.Point(543, 40);
            this.currentAbilitiesList.Name = "currentAbilitiesList";
            this.currentAbilitiesList.Size = new System.Drawing.Size(245, 398);
            this.currentAbilitiesList.TabIndex = 3;
            this.currentAbilitiesList.UseCompatibleStateImageBehavior = false;
            this.currentAbilitiesList.View = System.Windows.Forms.View.Details;
            this.currentAbilitiesList.DoubleClick += new System.EventHandler(this.currentAbilitiesList_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 240;
            // 
            // CompanionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentAbilitiesLabel);
            this.Controls.Add(this.currentAbilitiesList);
            this.Controls.Add(this.AvailableAbilitiesLabel);
            this.Controls.Add(this.availableAbilitiesList);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompanionEditor";
            this.Text = "CompanionEditor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanionEditor_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label CompanionName;
        private System.Windows.Forms.RichTextBox companionDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView availableAbilitiesList;
        private System.Windows.Forms.Label AvailableAbilitiesLabel;
        private System.Windows.Forms.Label CurrentAbilitiesLabel;
        private System.Windows.Forms.ListView currentAbilitiesList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}