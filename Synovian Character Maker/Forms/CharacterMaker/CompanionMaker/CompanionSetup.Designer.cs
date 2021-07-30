namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    partial class CompanionSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanionSetup));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.droidSelection = new System.Windows.Forms.CheckBox();
            this.beastSelect = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.companionPreviewLabel = new System.Windows.Forms.Label();
            this.makeCompanion = new System.Windows.Forms.Button();
            this.compNameText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.beastSpeciesText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.droidComboOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.83806F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.98381F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.583F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 247);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.droidSelection);
            this.groupBox1.Controls.Add(this.beastSelect);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Of Companion";
            // 
            // droidSelection
            // 
            this.droidSelection.AutoSize = true;
            this.droidSelection.Location = new System.Drawing.Point(182, 19);
            this.droidSelection.Name = "droidSelection";
            this.droidSelection.Size = new System.Drawing.Size(51, 17);
            this.droidSelection.TabIndex = 1;
            this.droidSelection.Text = "Droid";
            this.droidSelection.UseVisualStyleBackColor = true;
            this.droidSelection.CheckedChanged += new System.EventHandler(this.droidSelection_CheckedChanged);
            // 
            // beastSelect
            // 
            this.beastSelect.AutoSize = true;
            this.beastSelect.Location = new System.Drawing.Point(123, 19);
            this.beastSelect.Name = "beastSelect";
            this.beastSelect.Size = new System.Drawing.Size(53, 17);
            this.beastSelect.TabIndex = 0;
            this.beastSelect.Text = "Beast";
            this.beastSelect.UseVisualStyleBackColor = true;
            this.beastSelect.CheckedChanged += new System.EventHandler(this.beastSelect_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.companionPreviewLabel);
            this.groupBox2.Controls.Add(this.makeCompanion);
            this.groupBox2.Controls.Add(this.compNameText);
            this.groupBox2.Location = new System.Drawing.Point(3, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // companionPreviewLabel
            // 
            this.companionPreviewLabel.AutoSize = true;
            this.companionPreviewLabel.Location = new System.Drawing.Point(6, 56);
            this.companionPreviewLabel.Name = "companionPreviewLabel";
            this.companionPreviewLabel.Size = new System.Drawing.Size(94, 13);
            this.companionPreviewLabel.TabIndex = 2;
            this.companionPreviewLabel.Text = "Current Selection: ";
            // 
            // makeCompanion
            // 
            this.makeCompanion.Location = new System.Drawing.Point(243, 73);
            this.makeCompanion.Name = "makeCompanion";
            this.makeCompanion.Size = new System.Drawing.Size(121, 36);
            this.makeCompanion.TabIndex = 1;
            this.makeCompanion.Text = "Make Companion";
            this.makeCompanion.UseVisualStyleBackColor = true;
            this.makeCompanion.Click += new System.EventHandler(this.makeCompanion_Click);
            // 
            // compNameText
            // 
            this.compNameText.Location = new System.Drawing.Point(7, 20);
            this.compNameText.Name = "compNameText";
            this.compNameText.Size = new System.Drawing.Size(194, 20);
            this.compNameText.TabIndex = 0;
            this.compNameText.Text = "Companion Name . . .";
            this.compNameText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.compNameText_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.beastSpeciesText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.droidComboOptions);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 72);
            this.panel1.TabIndex = 3;
            // 
            // beastSpeciesText
            // 
            this.beastSpeciesText.Location = new System.Drawing.Point(160, 26);
            this.beastSpeciesText.Name = "beastSpeciesText";
            this.beastSpeciesText.Size = new System.Drawing.Size(128, 20);
            this.beastSpeciesText.TabIndex = 3;
            this.beastSpeciesText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.beastSpeciesText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Beast Companion Species";
            // 
            // droidComboOptions
            // 
            this.droidComboOptions.FormattingEnabled = true;
            this.droidComboOptions.Items.AddRange(new object[] {
            "None",
            "Research Droid",
            "Engineering Droid",
            "Astromech Droid",
            "Protocol Droid",
            "Battledroid",
            "Security Droid",
            "Assassin Droid"});
            this.droidComboOptions.Location = new System.Drawing.Point(9, 26);
            this.droidComboOptions.Name = "droidComboOptions";
            this.droidComboOptions.Size = new System.Drawing.Size(121, 21);
            this.droidComboOptions.TabIndex = 1;
            this.droidComboOptions.SelectedIndexChanged += new System.EventHandler(this.droidComboOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specific Droid Types";
            // 
            // CompanionSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 269);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CompanionSetup";
            this.Text = "Companion Setup";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanionSetup_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox droidSelection;
        private System.Windows.Forms.CheckBox beastSelect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox compNameText;
        private System.Windows.Forms.Button makeCompanion;
        private System.Windows.Forms.Label companionPreviewLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox droidComboOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox beastSpeciesText;
        private System.Windows.Forms.Label label2;
    }
}