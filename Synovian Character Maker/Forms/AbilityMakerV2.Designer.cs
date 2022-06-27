namespace Synovian_Character_Maker.Forms
{
    partial class AbilityMakerV2
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RankBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AlignBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SchoolBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prereqBox = new System.Windows.Forms.RichTextBox();
            this.validationPrereqButton = new System.Windows.Forms.Button();
            this.makeAbilityButton = new System.Windows.Forms.Button();
            this.AbilityList = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.readOnlyAbilName = new System.Windows.Forms.TextBox();
            this.readOnlyAbilDescription = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.readonlyRank = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.readonlyAlignment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.readOnlySchool = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.readOnlyPrereqs = new System.Windows.Forms.RichTextBox();
            this.abiliColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.abiliColRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.abiliColAlignment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.abiliColSchool = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resetButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.isFeatCheck = new System.Windows.Forms.CheckBox();
            this.readOnlyIsFeat = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.skillCostBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillCostBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skillCostBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.isFeatCheck);
            this.groupBox1.Controls.Add(this.resetButton);
            this.groupBox1.Controls.Add(this.makeAbilityButton);
            this.groupBox1.Controls.Add(this.validationPrereqButton);
            this.groupBox1.Controls.Add(this.prereqBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SchoolBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.AlignBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RankBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.descriptionBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 584);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Ability Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ability Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(10, 62);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(179, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ability Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(6, 112);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(254, 136);
            this.descriptionBox.TabIndex = 3;
            this.descriptionBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ability Rank";
            // 
            // RankBox
            // 
            this.RankBox.FormattingEnabled = true;
            this.RankBox.Location = new System.Drawing.Point(13, 283);
            this.RankBox.Name = "RankBox";
            this.RankBox.Size = new System.Drawing.Size(121, 21);
            this.RankBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ability Alignment";
            // 
            // AlignBox
            // 
            this.AlignBox.FormattingEnabled = true;
            this.AlignBox.Location = new System.Drawing.Point(13, 348);
            this.AlignBox.Name = "AlignBox";
            this.AlignBox.Size = new System.Drawing.Size(121, 21);
            this.AlignBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ability School";
            // 
            // SchoolBox
            // 
            this.SchoolBox.FormattingEnabled = true;
            this.SchoolBox.Location = new System.Drawing.Point(13, 408);
            this.SchoolBox.Name = "SchoolBox";
            this.SchoolBox.Size = new System.Drawing.Size(121, 21);
            this.SchoolBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 449);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Preqeqs (Names)";
            // 
            // prereqBox
            // 
            this.prereqBox.Location = new System.Drawing.Point(6, 465);
            this.prereqBox.Name = "prereqBox";
            this.prereqBox.Size = new System.Drawing.Size(128, 64);
            this.prereqBox.TabIndex = 11;
            this.prereqBox.Text = "";
            // 
            // validationPrereqButton
            // 
            this.validationPrereqButton.Location = new System.Drawing.Point(161, 483);
            this.validationPrereqButton.Name = "validationPrereqButton";
            this.validationPrereqButton.Size = new System.Drawing.Size(75, 23);
            this.validationPrereqButton.TabIndex = 12;
            this.validationPrereqButton.Text = "Validate";
            this.validationPrereqButton.UseVisualStyleBackColor = true;
            this.validationPrereqButton.Click += new System.EventHandler(this.validationPrereqButton_Click);
            // 
            // makeAbilityButton
            // 
            this.makeAbilityButton.Location = new System.Drawing.Point(80, 555);
            this.makeAbilityButton.Name = "makeAbilityButton";
            this.makeAbilityButton.Size = new System.Drawing.Size(109, 23);
            this.makeAbilityButton.TabIndex = 13;
            this.makeAbilityButton.Text = "Make Ability";
            this.makeAbilityButton.UseVisualStyleBackColor = true;
            this.makeAbilityButton.Click += new System.EventHandler(this.makeAbilityButton_Click);
            // 
            // AbilityList
            // 
            this.AbilityList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.abiliColName,
            this.abiliColRank,
            this.abiliColAlignment,
            this.abiliColSchool});
            this.AbilityList.HideSelection = false;
            this.AbilityList.Location = new System.Drawing.Point(286, 13);
            this.AbilityList.Name = "AbilityList";
            this.AbilityList.Size = new System.Drawing.Size(627, 584);
            this.AbilityList.TabIndex = 1;
            this.AbilityList.UseCompatibleStateImageBehavior = false;
            this.AbilityList.View = System.Windows.Forms.View.Details;
            this.AbilityList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AbilityList_ColumnClick);
            this.AbilityList.Click += new System.EventHandler(this.AbilityList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readOnlyIsFeat);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.readOnlyPrereqs);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.readOnlySchool);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.readonlyAlignment);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.readonlyRank);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.readOnlyAbilDescription);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.readOnlyAbilName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(920, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 584);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ability Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ability Name";
            // 
            // readOnlyAbilName
            // 
            this.readOnlyAbilName.Location = new System.Drawing.Point(6, 51);
            this.readOnlyAbilName.Name = "readOnlyAbilName";
            this.readOnlyAbilName.ReadOnly = true;
            this.readOnlyAbilName.Size = new System.Drawing.Size(179, 20);
            this.readOnlyAbilName.TabIndex = 14;
            // 
            // readOnlyAbilDescription
            // 
            this.readOnlyAbilDescription.Location = new System.Drawing.Point(9, 112);
            this.readOnlyAbilDescription.Name = "readOnlyAbilDescription";
            this.readOnlyAbilDescription.ReadOnly = true;
            this.readOnlyAbilDescription.Size = new System.Drawing.Size(226, 136);
            this.readOnlyAbilDescription.TabIndex = 15;
            this.readOnlyAbilDescription.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ability Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ability Rank";
            // 
            // readonlyRank
            // 
            this.readonlyRank.Location = new System.Drawing.Point(6, 284);
            this.readonlyRank.Name = "readonlyRank";
            this.readonlyRank.ReadOnly = true;
            this.readonlyRank.Size = new System.Drawing.Size(97, 20);
            this.readonlyRank.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Ability Alignment";
            // 
            // readonlyAlignment
            // 
            this.readonlyAlignment.Location = new System.Drawing.Point(6, 338);
            this.readonlyAlignment.Name = "readonlyAlignment";
            this.readonlyAlignment.ReadOnly = true;
            this.readonlyAlignment.Size = new System.Drawing.Size(179, 20);
            this.readonlyAlignment.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Ability School";
            // 
            // readOnlySchool
            // 
            this.readOnlySchool.Location = new System.Drawing.Point(6, 395);
            this.readOnlySchool.Name = "readOnlySchool";
            this.readOnlySchool.ReadOnly = true;
            this.readOnlySchool.Size = new System.Drawing.Size(179, 20);
            this.readOnlySchool.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 433);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Preqeqs (Names)";
            // 
            // readOnlyPrereqs
            // 
            this.readOnlyPrereqs.Location = new System.Drawing.Point(6, 449);
            this.readOnlyPrereqs.Name = "readOnlyPrereqs";
            this.readOnlyPrereqs.ReadOnly = true;
            this.readOnlyPrereqs.Size = new System.Drawing.Size(229, 92);
            this.readOnlyPrereqs.TabIndex = 14;
            this.readOnlyPrereqs.Text = "";
            // 
            // abiliColName
            // 
            this.abiliColName.Text = "Name";
            this.abiliColName.Width = 200;
            // 
            // abiliColRank
            // 
            this.abiliColRank.Text = "Rank";
            this.abiliColRank.Width = 100;
            // 
            // abiliColAlignment
            // 
            this.abiliColAlignment.Text = "Alignment";
            this.abiliColAlignment.Width = 100;
            // 
            // abiliColSchool
            // 
            this.abiliColSchool.Text = "School";
            this.abiliColSchool.Width = 300;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(7, 555);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(67, 23);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(87, 555);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 16;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // isFeatCheck
            // 
            this.isFeatCheck.AutoSize = true;
            this.isFeatCheck.Location = new System.Drawing.Point(161, 286);
            this.isFeatCheck.Name = "isFeatCheck";
            this.isFeatCheck.Size = new System.Drawing.Size(58, 17);
            this.isFeatCheck.TabIndex = 15;
            this.isFeatCheck.Text = "Is Feat";
            this.isFeatCheck.UseVisualStyleBackColor = true;
            // 
            // readOnlyIsFeat
            // 
            this.readOnlyIsFeat.AutoSize = true;
            this.readOnlyIsFeat.Location = new System.Drawing.Point(127, 287);
            this.readOnlyIsFeat.Name = "readOnlyIsFeat";
            this.readOnlyIsFeat.Size = new System.Drawing.Size(58, 17);
            this.readOnlyIsFeat.TabIndex = 16;
            this.readOnlyIsFeat.Text = "Is Feat";
            this.readOnlyIsFeat.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(156, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Cost Override";
            // 
            // skillCostBox
            // 
            this.skillCostBox.Location = new System.Drawing.Point(155, 349);
            this.skillCostBox.Name = "skillCostBox";
            this.skillCostBox.Size = new System.Drawing.Size(72, 20);
            this.skillCostBox.TabIndex = 17;
            this.skillCostBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AbilityMakerV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.AbilityList);
            this.Controls.Add(this.groupBox1);
            this.Name = "AbilityMakerV2";
            this.Text = "AbilityMakerV2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillCostBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox AlignBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RankBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button makeAbilityButton;
        private System.Windows.Forms.Button validationPrereqButton;
        private System.Windows.Forms.RichTextBox prereqBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SchoolBox;
        private System.Windows.Forms.ListView AbilityList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox readonlyRank;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox readOnlyAbilDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox readOnlyAbilName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox readOnlySchool;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox readonlyAlignment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox readOnlyPrereqs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader abiliColName;
        private System.Windows.Forms.ColumnHeader abiliColRank;
        private System.Windows.Forms.ColumnHeader abiliColAlignment;
        private System.Windows.Forms.ColumnHeader abiliColSchool;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox isFeatCheck;
        private System.Windows.Forms.CheckBox readOnlyIsFeat;
        private System.Windows.Forms.NumericUpDown skillCostBox;
        private System.Windows.Forms.Label label13;
    }
}