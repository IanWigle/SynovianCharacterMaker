namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    partial class DroidCompanionMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DroidCompanionMaker));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadpictureButton = new System.Windows.Forms.Button();
            this.droidCompanionPicture = new System.Windows.Forms.PictureBox();
            this.deleteCharButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.abilityList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.companionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadPictureDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.droidCompanionPicture)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 546);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadpictureButton);
            this.groupBox1.Controls.Add(this.droidCompanionPicture);
            this.groupBox1.Controls.Add(this.deleteCharButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 540);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // loadpictureButton
            // 
            this.loadpictureButton.Location = new System.Drawing.Point(208, 508);
            this.loadpictureButton.Name = "loadpictureButton";
            this.loadpictureButton.Size = new System.Drawing.Size(75, 23);
            this.loadpictureButton.TabIndex = 4;
            this.loadpictureButton.Text = "Load Picture";
            this.loadpictureButton.UseVisualStyleBackColor = true;
            this.loadpictureButton.Click += new System.EventHandler(this.loadpictureButton_Click);
            // 
            // droidCompanionPicture
            // 
            this.droidCompanionPicture.Location = new System.Drawing.Point(9, 261);
            this.droidCompanionPicture.Name = "droidCompanionPicture";
            this.droidCompanionPicture.Size = new System.Drawing.Size(274, 241);
            this.droidCompanionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.droidCompanionPicture.TabIndex = 3;
            this.droidCompanionPicture.TabStop = false;
            // 
            // deleteCharButton
            // 
            this.deleteCharButton.Location = new System.Drawing.Point(9, 508);
            this.deleteCharButton.Name = "deleteCharButton";
            this.deleteCharButton.Size = new System.Drawing.Size(110, 23);
            this.deleteCharButton.TabIndex = 2;
            this.deleteCharButton.Text = "Delete Character";
            this.deleteCharButton.UseVisualStyleBackColor = true;
            this.deleteCharButton.Click += new System.EventHandler(this.deleteCharButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.descriptionBox);
            this.groupBox3.Location = new System.Drawing.Point(9, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 165);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Companion History";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(10, 32);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(258, 127);
            this.descriptionBox.TabIndex = 0;
            this.descriptionBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nameBox);
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 65);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(10, 36);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.abilityList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.companionList);
            this.splitContainer2.Size = new System.Drawing.Size(868, 540);
            this.splitContainer2.SplitterDistance = 434;
            this.splitContainer2.TabIndex = 1;
            // 
            // abilityList
            // 
            this.abilityList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.descHeader});
            this.abilityList.HideSelection = false;
            this.abilityList.Location = new System.Drawing.Point(3, 3);
            this.abilityList.Name = "abilityList";
            this.abilityList.Size = new System.Drawing.Size(428, 534);
            this.abilityList.TabIndex = 0;
            this.abilityList.UseCompatibleStateImageBehavior = false;
            this.abilityList.View = System.Windows.Forms.View.Details;
            this.abilityList.Click += new System.EventHandler(this.abilityList_Click);
            this.abilityList.DoubleClick += new System.EventHandler(this.abilityList_DoubleClick);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 195;
            // 
            // descHeader
            // 
            this.descHeader.Text = "Description";
            this.descHeader.Width = 226;
            // 
            // companionList
            // 
            this.companionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.companionList.HideSelection = false;
            this.companionList.Location = new System.Drawing.Point(3, 3);
            this.companionList.Name = "companionList";
            this.companionList.Size = new System.Drawing.Size(428, 534);
            this.companionList.TabIndex = 1;
            this.companionList.UseCompatibleStateImageBehavior = false;
            this.companionList.View = System.Windows.Forms.View.Details;
            this.companionList.DoubleClick += new System.EventHandler(this.companionList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 226;
            // 
            // loadPictureDialog
            // 
            this.loadPictureDialog.FileName = "openFileDialog1";
            this.loadPictureDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadPictureDialog_FileOk);
            // 
            // DroidCompanionMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 546);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DroidCompanionMaker";
            this.Text = "Droid Companion Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DroidCompanionMaker_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanionMaker_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.droidCompanionPicture)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ListView abilityList;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader descHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView companionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button deleteCharButton;
        private System.Windows.Forms.Button loadpictureButton;
        private System.Windows.Forms.PictureBox droidCompanionPicture;
        private System.Windows.Forms.OpenFileDialog loadPictureDialog;
        private System.Windows.Forms.Label label2;
    }
}