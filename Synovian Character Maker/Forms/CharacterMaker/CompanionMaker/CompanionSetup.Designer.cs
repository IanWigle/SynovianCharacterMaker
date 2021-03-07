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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.assassinChoice = new System.Windows.Forms.Button();
            this.securityChoice = new System.Windows.Forms.Button();
            this.battleChoice = new System.Windows.Forms.Button();
            this.protocolChoice = new System.Windows.Forms.Button();
            this.astromechChoice = new System.Windows.Forms.Button();
            this.researchChoice = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.makeCompanion = new System.Windows.Forms.Button();
            this.compNameText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.83806F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.98381F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.583F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 247);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.droidSelection);
            this.groupBox1.Controls.Add(this.beastSelect);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Of Companion";
            // 
            // droidSelection
            // 
            this.droidSelection.AutoSize = true;
            this.droidSelection.Location = new System.Drawing.Point(309, 19);
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
            this.beastSelect.Location = new System.Drawing.Point(250, 19);
            this.beastSelect.Name = "beastSelect";
            this.beastSelect.Size = new System.Drawing.Size(53, 17);
            this.beastSelect.TabIndex = 0;
            this.beastSelect.Text = "Beast";
            this.beastSelect.UseVisualStyleBackColor = true;
            this.beastSelect.CheckedChanged += new System.EventHandler(this.beastSelect_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.assassinChoice, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.securityChoice, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.battleChoice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.protocolChoice, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.astromechChoice, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.researchChoice, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(616, 72);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // assassinChoice
            // 
            this.assassinChoice.Location = new System.Drawing.Point(513, 3);
            this.assassinChoice.Name = "assassinChoice";
            this.assassinChoice.Size = new System.Drawing.Size(98, 66);
            this.assassinChoice.TabIndex = 4;
            this.assassinChoice.Text = "Assassin Droid";
            this.assassinChoice.UseVisualStyleBackColor = true;
            this.assassinChoice.Click += new System.EventHandler(this.assassinChoice_Click);
            // 
            // securityChoice
            // 
            this.securityChoice.Location = new System.Drawing.Point(411, 3);
            this.securityChoice.Name = "securityChoice";
            this.securityChoice.Size = new System.Drawing.Size(96, 66);
            this.securityChoice.TabIndex = 4;
            this.securityChoice.Text = "Security Droid";
            this.securityChoice.UseVisualStyleBackColor = true;
            this.securityChoice.Click += new System.EventHandler(this.securityChoice_Click);
            // 
            // battleChoice
            // 
            this.battleChoice.Location = new System.Drawing.Point(309, 3);
            this.battleChoice.Name = "battleChoice";
            this.battleChoice.Size = new System.Drawing.Size(96, 66);
            this.battleChoice.TabIndex = 3;
            this.battleChoice.Text = "Battle Droid";
            this.battleChoice.UseVisualStyleBackColor = true;
            this.battleChoice.Click += new System.EventHandler(this.battleChoice_Click);
            // 
            // protocolChoice
            // 
            this.protocolChoice.Location = new System.Drawing.Point(207, 3);
            this.protocolChoice.Name = "protocolChoice";
            this.protocolChoice.Size = new System.Drawing.Size(96, 66);
            this.protocolChoice.TabIndex = 2;
            this.protocolChoice.Text = "Protocol Droid";
            this.protocolChoice.UseVisualStyleBackColor = true;
            this.protocolChoice.Click += new System.EventHandler(this.protocolChoice_Click);
            // 
            // astromechChoice
            // 
            this.astromechChoice.Location = new System.Drawing.Point(105, 3);
            this.astromechChoice.Name = "astromechChoice";
            this.astromechChoice.Size = new System.Drawing.Size(96, 66);
            this.astromechChoice.TabIndex = 1;
            this.astromechChoice.Text = "Astromech Droid";
            this.astromechChoice.UseVisualStyleBackColor = true;
            this.astromechChoice.Click += new System.EventHandler(this.astromechChoice_Click);
            // 
            // researchChoice
            // 
            this.researchChoice.Location = new System.Drawing.Point(3, 3);
            this.researchChoice.Name = "researchChoice";
            this.researchChoice.Size = new System.Drawing.Size(96, 66);
            this.researchChoice.TabIndex = 0;
            this.researchChoice.Text = "Research Droid";
            this.researchChoice.UseVisualStyleBackColor = true;
            this.researchChoice.Click += new System.EventHandler(this.researchChoice_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.makeCompanion);
            this.groupBox2.Controls.Add(this.compNameText);
            this.groupBox2.Location = new System.Drawing.Point(3, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // makeCompanion
            // 
            this.makeCompanion.Location = new System.Drawing.Point(484, 73);
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
            // CompanionSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 269);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompanionSetup";
            this.Text = "CompanionSetup";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox droidSelection;
        private System.Windows.Forms.CheckBox beastSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button assassinChoice;
        private System.Windows.Forms.Button securityChoice;
        private System.Windows.Forms.Button battleChoice;
        private System.Windows.Forms.Button protocolChoice;
        private System.Windows.Forms.Button astromechChoice;
        private System.Windows.Forms.Button researchChoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox compNameText;
        private System.Windows.Forms.Button makeCompanion;
    }
}