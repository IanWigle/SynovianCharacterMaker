namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    partial class CreateCompanionBox
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.droidGroup = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.droidName = new System.Windows.Forms.TextBox();
            this.beastGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.beastName = new System.Windows.Forms.TextBox();
            this.makeButton = new System.Windows.Forms.Button();
            this.SpeciesCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.droidGroup.SuspendLayout();
            this.beastGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Companion Type";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Droid",
            "Beast"});
            this.comboBox1.Location = new System.Drawing.Point(96, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // droidGroup
            // 
            this.droidGroup.Controls.Add(this.comboBox2);
            this.droidGroup.Controls.Add(this.label2);
            this.droidGroup.Controls.Add(this.label1);
            this.droidGroup.Controls.Add(this.droidName);
            this.droidGroup.Location = new System.Drawing.Point(13, 72);
            this.droidGroup.Name = "droidGroup";
            this.droidGroup.Size = new System.Drawing.Size(183, 139);
            this.droidGroup.TabIndex = 1;
            this.droidGroup.TabStop = false;
            this.droidGroup.Text = "Droid Info";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "None",
            "Research Droid",
            "Medical Droid",
            "Engineering Droid",
            "Astromech Droid",
            "Protocol Droid",
            "Battle Droid",
            "Security Droid",
            "Assassin Droid"});
            this.comboBox2.Location = new System.Drawing.Point(7, 105);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(169, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Droid Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // droidName
            // 
            this.droidName.Location = new System.Drawing.Point(6, 48);
            this.droidName.Name = "droidName";
            this.droidName.Size = new System.Drawing.Size(170, 20);
            this.droidName.TabIndex = 0;
            // 
            // beastGroup
            // 
            this.beastGroup.Controls.Add(this.SpeciesCombo);
            this.beastGroup.Controls.Add(this.label4);
            this.beastGroup.Controls.Add(this.label3);
            this.beastGroup.Controls.Add(this.beastName);
            this.beastGroup.Location = new System.Drawing.Point(202, 72);
            this.beastGroup.Name = "beastGroup";
            this.beastGroup.Size = new System.Drawing.Size(163, 139);
            this.beastGroup.TabIndex = 2;
            this.beastGroup.TabStop = false;
            this.beastGroup.Text = "Beast Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Species";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // beastName
            // 
            this.beastName.Location = new System.Drawing.Point(6, 48);
            this.beastName.Name = "beastName";
            this.beastName.Size = new System.Drawing.Size(151, 20);
            this.beastName.TabIndex = 4;
            this.beastName.TextChanged += new System.EventHandler(this.beastName_TextChanged);
            this.beastName.Leave += new System.EventHandler(this.beastName_Leave);
            // 
            // makeButton
            // 
            this.makeButton.Enabled = false;
            this.makeButton.Location = new System.Drawing.Point(13, 217);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(353, 37);
            this.makeButton.TabIndex = 3;
            this.makeButton.Text = "Make Companion";
            this.makeButton.UseVisualStyleBackColor = true;
            this.makeButton.Click += new System.EventHandler(this.makeButton_Click);
            // 
            // SpeciesCombo
            // 
            this.SpeciesCombo.FormattingEnabled = true;
            this.SpeciesCombo.Location = new System.Drawing.Point(6, 104);
            this.SpeciesCombo.Name = "SpeciesCombo";
            this.SpeciesCombo.Size = new System.Drawing.Size(151, 21);
            this.SpeciesCombo.TabIndex = 6;
            this.SpeciesCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // CreateCompanionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 264);
            this.Controls.Add(this.makeButton);
            this.Controls.Add(this.beastGroup);
            this.Controls.Add(this.droidGroup);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateCompanionBox";
            this.Text = "Create Companion";
            this.groupBox1.ResumeLayout(false);
            this.droidGroup.ResumeLayout(false);
            this.droidGroup.PerformLayout();
            this.beastGroup.ResumeLayout(false);
            this.beastGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox droidGroup;
        private System.Windows.Forms.GroupBox beastGroup;
        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox droidName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox beastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SpeciesCombo;
    }
}